using Microsoft.AspNetCore.Identity;

namespace KemerburgazPetShop.WebUI.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
