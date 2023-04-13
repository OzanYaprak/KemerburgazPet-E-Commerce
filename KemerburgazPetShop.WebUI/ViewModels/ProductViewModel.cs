using KemerburgazPetShop.Entities;

namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageURL { get; set; }
        public decimal ProductPrice { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
