using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmonNew.Application.Services.Questions.Commands.AddQuestionToAzmon
{
    public interface IAddQuestionToAzmonService
    {
        ResultDto Execute(RequestDto request);
    }

    public class AddQuestionToAzmonService : IAddQuestionToAzmonService
    {
        private readonly IDataBaseContext _context;
        public AddQuestionToAzmonService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDto request)
        {
            var azmon = _context.QuestionPacks
                .Include(x => x.Questions)
                .Include(x => x.Categories)
                .FirstOrDefault(p => p.Id == request.AzmonId);
            if (azmon == null)
            {
                return new ResultDto { IsSuccess=false,Message="azmon not found"};
            }
            var question=_context.Questions.Include(p=>p.Options).Include(p=>p.QuestionImages).FirstOrDefault(p=>p.Id==request.QuestionId);

            if (question == null)
            {
                return new ResultDto { IsSuccess = false, Message = "question not found" };
            }

            azmon.Questions.Add(question);
            azmon.QuestionCount++;
            azmon.Level = (azmon.Level + question.level) / 2;
            if (!azmon.Categories.Contains(question.Category)){
                azmon.Categories.Add(question.Category);
            }

            
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "سوال به ازمون اضافه شد",
            };
        }
    }

    public class RequestDto
    {
        public int QuestionId { get; set; }
        public int AzmonId { get; set; }
    }
}
