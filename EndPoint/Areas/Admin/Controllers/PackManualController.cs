using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Application.Interface.FacadPatterns;
using AzmonNew.Application.Services.Questions.Commands.AddNewQuestionPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackManualController : Controller
    {
        private readonly IQuestionFacad _questionFacad;
        private readonly IDataBaseContext _dataBaseContext;

        public PackManualController(IQuestionFacad questionFacad, IDataBaseContext dataBaseContext)
        {
            _questionFacad = questionFacad;
            _dataBaseContext = dataBaseContext;

        }
        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_questionFacad.getAllAzmon.Execute(searchKey, page).Data);
        }







        //public IActionResult AddNewPack()
        //{
        //    //ViewBag.Categories = new SelectList(_questionFacad.getAllCategoriesService.Execute().Data, "Id", "Name");
        //    return View();
        //}
        //[HttpPost]
        public IActionResult AddNewPack()//RequestAddNewPackDto request, List<AddNewPack_Option> Options)
        {
            var request = new RequsetQP()
            {
                level = 1,
                name=DateTime.Now.ToString(),
                questionCount = 9,
                Categories = _dataBaseContext.Categories.ToList(),
            };
          
            return Json(_questionFacad.addNewQustionPackService.Execute(request).Data.Questions);
        }
    }
}
