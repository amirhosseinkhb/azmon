using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using AzmonNew.Domain.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzmonNew.Application.Services.Questions.Commands.AddNewQuestionPack
{
    public interface IAddNewQuestionPackService
    {
        ResultDto<QuestionPacks> Execute(RequsetQP requset);
    }

    public class AddNewQuestionPackService : IAddNewQuestionPackService
    {

        private readonly IDataBaseContext _context;
        public AddNewQuestionPackService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<QuestionPacks> Execute(RequsetQP requset)
        {
            try
            {
                int questionCountCategory = requset.questionCount / requset.Categories.Count();//5

                var questionList = new List<Question>();

                foreach (var item in requset.Categories)
                {
                    questionList.AddRange(_context.Questions.Where(p => p.Category.Equals(item)).OrderBy(r => Guid.NewGuid()).Take(5).ToList());
                    //_context.Questions.Where(p => p.Category.Equals(item)).Select(p => p).OrderBy(Random());
                    //.OrderBy(x => rnd.Next()).Take(5)
                }
                QuestionPacks questionPacks;
                _context.QuestionPacks.Add(questionPacks= new QuestionPacks()
                {
                    Questions = questionList.ToArray(),
                    Categories = requset.Categories,
                    Level = requset.level,
                    Name = requset.name,
                    QuestionCount = requset.questionCount,
                });
                _context.SaveChanges();
                return new ResultDto<QuestionPacks> {Data=questionPacks,IsSuccess = true, Message = "question pack was made" };
            }
            catch (Exception ex)
            {
                return new ResultDto<QuestionPacks> {Data=null, IsSuccess = false, Message = ex.Message };
            }
        }
    }


    public class RequsetQP
    {
        public int level { get; set; }
        public string name { get; set; }
        public int questionCount { get; set; }
        public virtual List<Category> Categories { get; set; }

        
    }
}