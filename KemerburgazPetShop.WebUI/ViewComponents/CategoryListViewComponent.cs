using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KemerburgazPetShop.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke() 
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            }); 
        }
    }
}
