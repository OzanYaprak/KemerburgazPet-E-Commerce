using KemerburgazPetShop.Entities;
using System.ComponentModel.DataAnnotations;

namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Ürün Adı Girilmeli.")]
        [StringLength(60, MinimumLength = 10, ErrorMessage ="Ürün ismi Min. {2} Maks. {1} karakter aralığında olmalıdır.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ürün Açıklaması Girilmeli.")]
        [StringLength(240, MinimumLength = 20, ErrorMessage = "Ürün açıklaması Min. {2} Maks. {1} karakter aralığında olmalıdır.")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Ürün Resmi Girilmeli.")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage ="Ürün Fiyatı Girilmeli.")]
        public double? ProductPrice { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
