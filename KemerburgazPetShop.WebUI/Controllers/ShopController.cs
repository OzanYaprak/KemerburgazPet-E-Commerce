using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.Entities;
using KemerburgazPetShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KemerburgazPetShop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string category, int page=1)
        {
            const int pageSize = 12;
            return View(new IndexViewModels()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems=_productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory= category
                },

                Products= _productService.GetProductsByCategory(category, page, pageSize)
            });
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails((int)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(new DetailsViewModels()
            {
                Product = product,
                Categories = product.ProductCategories.Select(a => a.Category).ToList()
            });
        }



    }
}
