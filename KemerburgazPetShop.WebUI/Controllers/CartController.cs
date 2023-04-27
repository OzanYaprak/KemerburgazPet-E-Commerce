using IyzipayCore;
using IyzipayCore.Model;
using IyzipayCore.Request;
using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.Entities;
using KemerburgazPetShop.WebUI.Identity;
using KemerburgazPetShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;

namespace KemerburgazPetShop.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IOrderService _orderService;
        private UserManager<ApplicationUser> _userManager;
        public CartController(IOrderService orderService, ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserID(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartID = cart.CartID,
                CartItems = cart.CartItems.Select(a => new CartItemModel()
                {
                    CartItemID = a.CartItemID,
                    ProductID = a.Product.ProductID,
                    ProductName = a.Product.ProductName,
                    ProductPrice = (decimal)a.Product.ProductPrice,
                    ImageURL = a.Product.ImageURL,
                    Quantity = a.Quantity

                }).ToList()

            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productID, int quantity)
        {
            _cartService.AddToCart(_userManager.GetUserId(User), productID, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productID)
        {
            _cartService.DeleteFromCart(_userManager.GetUserId(User), productID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserID(_userManager.GetUserId(User));

            var ordermodel = new OrderViewModel();

            ordermodel.CartModel = new CartModel()
            {
                CartID = cart.CartID,
                CartItems = cart.CartItems.Select(a => new CartItemModel()
                {
                    CartItemID = a.CartItemID,
                    ProductID = a.Product.ProductID,
                    ProductName = a.Product.ProductName,
                    ProductPrice = (decimal)a.Product.ProductPrice,
                    ImageURL = a.Product.ImageURL,
                    Quantity = a.Quantity

                }).ToList()
            };

            return View(ordermodel);


        }

        [HttpPost]
        public IActionResult Checkout(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userID = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserID(userID);

                model.CartModel = new CartModel()
                {
                    CartID = cart.CartID,
                    CartItems = cart.CartItems.Select(a => new CartItemModel()
                    {
                        CartItemID = a.CartItemID,
                        ProductID = a.Product.ProductID,
                        ProductName = a.Product.ProductName,
                        ProductPrice = (decimal)a.Product.ProductPrice,
                        ImageURL = a.Product.ImageURL,
                        Quantity = a.Quantity

                    }).ToList()
                };

                var payment = PaymentProcess(model);

                if (payment.Status == "success")
                {
                    SaveOrder(model, payment, userID);
                    ClearCart(cart.CartID.ToString());
                    return View("Success");
                }

            }
            return View(model);
        }

        private void ClearCart(string cartID)
        {
            _cartService.ClearCart(cartID);
        }

        private void SaveOrder(OrderViewModel model, Payment payment, string userID)
        {
            var order = new Order();

            order.OrderNumber = new Random().Next(111111, 999999).ToString();
            order.OrderState = EnumOrderState.Completed;
            order.PaymentTypes = EnumPaymentTypes.CreditCart;
            order.PaymentID = payment.PaymentId;
            order.ConversationID = payment.ConversationId;
            order.OrderDate = new DateTime();
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.Email = model.Email;
            order.Phone = model.Phone;
            order.Address = model.Address;
            order.City = model.City;
            order.UserID = userID;

            foreach (var item in model.CartModel.CartItems)
            {
                var orderitem = new OrderItem()
                {
                    ProductPrice = item.ProductPrice,
                    Quantity = item.Quantity,
                    ProductID = item.ProductID
                };
                order.OrderItems.Add(orderitem);
            }
            _orderService.Create(order);
        }

        private Payment PaymentProcess(OrderViewModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-D3WkHLEmOJGSgtt8To9Ine9JERooqQ0q";
            options.SecretKey = "sandbox-g1gvUIoQEHVZqgaQaqMmcoyZS5xfUmXM";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";



            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = Guid.NewGuid().ToString();
            request.Price = model.CartModel.TotalPrice().ToString().Split(",")[0];
            request.PaidPrice = model.CartModel.TotalPrice().ToString().Split(",")[0];
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = model.CartModel.CartID.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CreditCardName;
            paymentCard.CardNumber = model.CreditCardNumber;
            paymentCard.ExpireMonth = model.CreditCardExpMount;
            paymentCard.ExpireYear = model.CreditCardExpYear;
            paymentCard.Cvc = model.CreditCardCvv;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;


            //paymentCard.CardHolderName = "John Doe";
            //paymentCard.CardNumber = "5528790000000008";
            //paymentCard.ExpireMonth = "12";
            //paymentCard.ExpireYear = "2030";
            //paymentCard.Cvc = "123";


            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.CartModel.CartItems)
            {
                basketItem = new BasketItem();

                basketItem.Id = item.ProductID.ToString();
                basketItem.Name = item.ProductName;
                basketItem.Category1 = "Kuru Mama";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = item.ProductPrice.ToString().Split(",")[0];

                basketItems.Add(basketItem);
            }

            request.BasketItems = basketItems;

            return Payment.Create(request, options);

        }

        public IActionResult GetOrders() 
        {
            var orders = _orderService.GetOrders(_userManager.GetUserId(User));
            var orderListModel = new List<OrderListViewModel>();
            OrderListViewModel orderModel;

            foreach (var order in orders)
            {
                orderModel = new OrderListViewModel();
                orderModel.OrderID = order.OrderID;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.OrderNote = order.OrderNote;
                orderModel.Phone = order.Phone;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.Email = order.Email;
                orderModel.Address = order.Address;
                orderModel.City = order.City;

                orderModel.OrderItems = order.OrderItems.Select(a => new OrderItemModel()
                {
                    OrderItemID = a.OrderItemID,
                    OrderName = a.Product.ProductName,
                    OrderPrice = a.ProductPrice,
                    Quantity = a.Quantity,
                    ImageURL = a.Product.ImageURL

                }).ToList();

                orderListModel.Add(orderModel);
            }
            return View(orderListModel); 
        }
    }
}
