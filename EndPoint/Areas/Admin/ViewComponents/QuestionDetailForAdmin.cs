
using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Application.Interface.FacadPatterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EndPoint.Areas.Admin.ViewComponents
{
    public class QuestionDetailForAdmin : ViewComponent
    {
        private readonly IQuestionFacad _questionFacad;
        public QuestionDetailForAdmin(IQuestionFacad questionFacad)
        {
            _questionFacad = questionFacad;
        }

       
        public IViewComponentResult Invoke(int Id)
        {
            var question = _questionFacad.getQuestionDetailsForAdminServuce.Execute(Id); 
            return View(viewName: "QuestionForAdmin",question);
        }


    }
}
