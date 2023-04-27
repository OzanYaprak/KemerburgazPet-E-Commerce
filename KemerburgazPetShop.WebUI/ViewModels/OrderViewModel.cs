using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class OrderViewModel
    {
        public CartModel CartModel { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olmalıdır.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olmalıdır.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adres alanı gereklidir.")]
        [StringLength(100, ErrorMessage = "Adres en fazla 100 karakter olmalıdır.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Şehir alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Şehir en fazla 50 karakter olmalıdır.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Telefon alanı gereklidir.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Geçersiz telefon numarası.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "E-posta alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Kart üzerinde bulunan isim alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Kart üzerinde bulunan isim en fazla 50 karakter olmalıdır.")]
        public string CreditCardName { get; set; }

        [Required(ErrorMessage = "Kart numarası alanı gereklidir.")]
        [CreditCard(ErrorMessage = "Geçersiz kredi kartı numarası.")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Kartın son kullanma ayı alanı gereklidir.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])$", ErrorMessage = "Geçersiz ay formatı.")]
        public string CreditCardExpMount { get; set; }

        [Required(ErrorMessage = "Kartın son kullanma yılı alanı gereklidir.")]
        [RegularExpression(@"^(20)\d{2}$", ErrorMessage = "Geçersiz yıl formatı.")]
        public string CreditCardExpYear { get; set; }

        [Required(ErrorMessage = "CVV alanı gereklidir.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Geçersiz CVV formatı.")]
        public string CreditCardCvv { get; set; }
    }
}
