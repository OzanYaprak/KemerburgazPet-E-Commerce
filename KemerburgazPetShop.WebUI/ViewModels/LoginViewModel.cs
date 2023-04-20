using System.ComponentModel.DataAnnotations;

namespace KemerburgazPetShop.WebUI.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Geçerli Bir Parola Giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnURL { get; set; }
    }
}
