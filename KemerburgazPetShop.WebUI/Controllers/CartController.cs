using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.WebUI.Identity;
using KemerburgazPetShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KemerburgazPetShop.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<ApplicationUser> _userManager;
        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
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
    }
}
