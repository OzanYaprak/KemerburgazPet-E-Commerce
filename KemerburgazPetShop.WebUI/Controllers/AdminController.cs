using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.Entities;
using KemerburgazPetShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KemerburgazPetShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModels()
            {
                
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel model)
        {
            var entity=new Product() 
            {
                ProductName = model.ProductName,
                ImageURL = model.ImageURL,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice
            };
            _productService.Create(entity);
            return Redirect("Index");
        }
    }
}
