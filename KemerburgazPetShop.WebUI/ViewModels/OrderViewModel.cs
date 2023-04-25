namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class OrderViewModel
    {
        public CartModel CartModel { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string CreditCardName { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardExpMount { get; set; }
        public string CreditCardExpYear { get; set; }
        public string CreditCardCvv { get; set; }
    }
}
