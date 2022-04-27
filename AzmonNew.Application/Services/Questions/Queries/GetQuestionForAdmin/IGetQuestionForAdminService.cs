using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common;
using AzmonNew.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AzmonNew.Application.Services.Questions.Queries.GetQuestionForAdmin
{
    public interface IGetQuestionForAdminService
    {
        ResultDto<QuestionForAdminDto> Execute(string searchKey, int page = 1);
    }

    public class GetQuestionForAdminService : IGetQuestionForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetQuestionForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<QuestionForAdminDto> Execute(string searchKey, int page = 1)
        {
            var questions = _context.Questions
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                questions = questions.Where(p => p.QuestionText.Contains(searchKey) || p.Category.Name.Contains(searchKey));
            }

            int rowCount = 0;
            var questionList = questions.ToPaged(page, 200, out rowCount).Select(p => new GetQuestionDto
            {
                QuestionText = p.QuestionText,
                CategoryName = p.Category.Name,
                Id = p.Id,
                QuestionLevel = p.level,

            }).ToList();

            return new ResultDto<QuestionForAdminDto>()
            {
                Data = new QuestionForAdminDto()
                {
                    Questions = questionList,
                    CurrentPage = page,
                    RowCount = rowCount,
                    PageSize = 20
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class GetQuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string CategoryName { get; set; }
        public int QuestionLevel { get; set; }
    }

    public class QuestionForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<GetQuestionDto> Questions { get; set; }
    }

}
