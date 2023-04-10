using KemerburgazPetShop.Entities;
using System.Drawing.Printing;

namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class IndexViewModels
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public PageInfo PageInfo { get; set; } 

    }
}
