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

        public IActionResult ProductList()
        {
            return View(new IndexViewModels()
            {
                Products = _productService.GetAll()
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
            var entity = new Product()
            {
                ProductName = model.ProductName,
                ImageURL = model.ImageURL,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice
            };
            _productService.Create(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productService.GetByID((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductViewModel()
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                ImageURL = entity.ImageURL,
                ProductDescription = entity.ProductDescription,
                ProductPrice = entity.ProductPrice

            };

            return View(model);
        }


        [HttpPost]
        public IActionResult EditProduct(ProductViewModel model)
        {
            var entity = _productService.GetByID(model.ProductID);

            if (entity == null)
            {
                return NotFound();
            }

            entity.ProductName = model.ProductName;
            entity.ImageURL = model.ImageURL;
            entity.ProductDescription = model.ProductDescription;
            entity.ProductPrice = model.ProductPrice;

            _productService.Update(entity);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DeleteProduct(int productID)
        {
            var entity = _productService.GetByID(productID);
            if (entity != null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("Index");

        }
    }
}
