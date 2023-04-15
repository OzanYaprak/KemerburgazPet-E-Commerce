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
            return View(new ProductViewModel());
        }



        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
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

            return View(model);

        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productService.GetByIDWithCategories((int)id);

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
                ProductPrice = entity.ProductPrice,
                SelectedCategories = entity.ProductCategories.Select(c => c.Category).ToList()

            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel model, int[] categoryIDs, IFormFile file)
        {
            if (ModelState.IsValid)
            {




                var entity = _productService.GetByID(model.ProductID);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.ProductName = model.ProductName;
                entity.ProductDescription = model.ProductDescription;
                entity.ProductPrice = model.ProductPrice;

                if (file != null)
                {
                    entity.ImageURL = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Bisum\\assets\\img\\products\\hills",file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                       await file.CopyToAsync(stream);
                    }
                }

                _productService.Update(entity, categoryIDs);

                return RedirectToAction("ProductList");
            }

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);

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
                Products = entity.ProductCategories.Select(a => a.Product).ToList()
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

        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryID, int productID)
        {
            _categoryService.DeleteFromCategory(categoryID, productID);

            return Redirect("/admin/editcategory/" + categoryID);
        }
    }
}
