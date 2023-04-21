using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KemerburgazPetShop.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}
