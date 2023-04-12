using KemerburgazPetShop.Entities;

namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
