using Microsoft.AspNetCore.Mvc;

namespace KemerburgazPetShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
    }
}
