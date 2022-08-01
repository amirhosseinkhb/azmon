
using AzmonNew.Application.Interface.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IQuestionFacad _questionFacad;

        public CategoryController(IQuestionFacad questionFacad)
        {
            _questionFacad = questionFacad;
        }



        public IActionResult Index()
        {
            return View(_questionFacad.getAllCategoriesService.Execute().Data);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return Json(_questionFacad.removeCategoryService.Execute(Id));
        }

        [HttpGet]
        public IActionResult AddNewCategory()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddNewCategory(string Name)
        {
            var result = _questionFacad.addNewCategoryService.Execute(Name);
            return Json(result);
        }
    }
}
