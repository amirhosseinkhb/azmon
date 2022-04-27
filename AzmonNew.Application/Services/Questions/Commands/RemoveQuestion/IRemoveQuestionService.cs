using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using System;

namespace AzmonNew.Application.Services.Questions.Commands.RemoveQuestion
{
    public interface IRemoveQuestionService
    {
        ResultDto Execute(int Id);
    }
    public class RemoveQuestionService : IRemoveQuestionService
    {
        private readonly IDataBaseContext _context;

        public RemoveQuestionService(IDataBaseContext contexts)
        {
            _context = contexts;
        }
        public ResultDto Execute(int Id)
        {
            var question = _context.Questions
                 .Find(Id);

            if (question == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "سوال پیدا نشد",
                };
            }

            question.RemoveTime = DateTime.Now;
            question.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "سوال حذف شد",
            };
        }
    }
}
