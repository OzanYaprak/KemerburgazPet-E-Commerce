using KemerburgazPetShop.Entities;

namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class OrderListViewModel
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }


        public EnumOrderState OrderState { get; set; }
        public EnumPaymentTypes PaymentTypes { get; set; }


        public List<OrderItemModel> OrderItems { get; set; }
        public decimal TotalPrice()
        {
            return OrderItems.Sum(a => a.OrderPrice * a.Quantity);
        }
    }

    public class OrderItemModel
    {
        public int OrderItemID { get; set; }
        public decimal OrderPrice { get; set; }
        public string OrderName { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
    }

}
