namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class CartModel
    {
        public int CartID { get; set; }
        public List<CartItemModel> CartItems { get; set; }

        public decimal TotalPrice()
        {
            return CartItems.Sum(a => a.ProductPrice * a.Quantity);
        }
    }

    public class CartItemModel
    {
        public int CartItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
    }

}
