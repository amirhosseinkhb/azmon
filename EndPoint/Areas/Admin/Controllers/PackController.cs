using AzmonNew.Application.Interface.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackController : Controller
    {
        private readonly IQuestionFacad _questionFacad;
        public PackController(IQuestionFacad questionFacad)
        {
            _questionFacad = questionFacad;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Manual()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Manual(string Name)
        {
            var x=_questionFacad.EmptyAzmon.Execute(Name);
            return Json(x);
        }
    }
}
