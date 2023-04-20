using KemerburgazPetShop.Entities;
using System.ComponentModel.DataAnnotations;


namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Bir İsim Giriniz.")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Girilen isim Min. {2} Maks. {1} karakter aralığında olmalıdır.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Kullanıcı Adı Giriniz.")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "Kullanıcı adı Min. {2} Maks. {1} karakter aralığında olmalıdır.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Geçerli Bir Parola Giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreler Uyumsuz, Tekrar Kontrol Edin.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Lütfen Geçerli Bir Mail Adresi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
