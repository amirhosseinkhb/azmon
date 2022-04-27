using Azmon.Application.Services.Question.Commands.AddNewQuestion;
using AzmonNew.Application.Interface.FacadPatterns;
using AzmonNew.Application.Services.Questions.Commands.EditQuestion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionFacad _questionFacad;
        public QuestionController(IQuestionFacad questionFacad)
        {
            _questionFacad = questionFacad;
        }
        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_questionFacad.getQuestionForAdminService.Execute(searchKey, page).Data);
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Text)
        {
            return Json(_questionFacad.editQuestionService.Execute(new RequestEditQuestionDto
            {
                Id = Id,
                Text = Text,
            }));
        }


        [HttpGet]
        public IActionResult AddNewQuestion()
        {
            ViewBag.Categories = new SelectList(_questionFacad.getAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewQuestion(RequestAddNewQuestonDto request, List<AddNewQuestion_Option> Options)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Options = Options;
            return Json(_questionFacad.addNewQuestionService.Execute(request));
        }


        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return Json(_questionFacad.removeQuestionService.Execute(Id));
        }
    
    
        public IActionResult QuestionDetailViewComponent(int id)
        {
            return ViewComponent("QuestionDetailForAdmin", new { Id = id });
        }
    }
}
