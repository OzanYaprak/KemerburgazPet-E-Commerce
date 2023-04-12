using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.Entities;
using KemerburgazPetShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KemerburgazPetShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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
            return RedirectToAction("ProductList");
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

            return RedirectToAction("ProductList");
        }


        [HttpPost]
        public IActionResult DeleteProduct(int productID)
        {
            var entity = _productService.GetByID(productID);
            if (entity != null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("ProductList");

        }











        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetByIDWithProducts(id);

            return View(new CategoryViewModel()
            {
                CategoryName = entity.CategoryName,
                CategoryID = entity.CategoryID,
                Products = entity.ProductCategories.Select(a=>a.Product).ToList()
            });
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryViewModel model)
        {
            var entity = _categoryService.GetByID(model.CategoryID);
            if (entity == null)
            {
                return NotFound();
            }

            entity.CategoryName = model.CategoryName;
            _categoryService.Update(entity);

            return RedirectToAction("CategoryList");
        }


        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel model)
        {
            var entity = new Category()
            {
                CategoryName = model.CategoryName,
            };

            _categoryService.Create(entity);

            return RedirectToAction("CategoryList");
        }


        [HttpPost]
        public IActionResult DeleteCategory(int categoryID)
        {
            var entity = _categoryService.GetByID(categoryID);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }

            return RedirectToAction("CategoryList");

        }
    }
}
