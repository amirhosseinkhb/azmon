using AzmonNew.Application.Interface.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AzmonNew.Application.Services.Questions.Queries.GetQuestionDetailForAdmin
{
    public interface IGetQuestionDetailsForAdminServuce
    {
        ResultQuestionDetailDto Execute(int Id);
    }
    public class GetQuestionDetailsForAdminServuce : IGetQuestionDetailsForAdminServuce
    {
        private readonly IDataBaseContext _context;
        public GetQuestionDetailsForAdminServuce(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultQuestionDetailDto Execute(int Id)
        {
            var x = _context.Questions
                .Include(p => p.Category)
                .Include(p => p.QuestionImages)
                .Include(p => p.Options)
                .FirstOrDefault(p => p.Id == Id);

            var options = new List<OptionDetailDto>();
            //behtar nmishodesh
            foreach (var item in x.Options)
            {
                options.Add(new OptionDetailDto
                {
                    Text = item.text,
                    isTrue = item.isTrue,
                    Id=item.Id,
                });
            }
            return new ResultQuestionDetailDto
            {
                QuestionText = x.QuestionText,
                QuestionCategory = x.Category.Name,
                QuestionId = x.Id,
                Options = options,
            };
        }
    }

    public class ResultQuestionDetailDto
    {
        public int QuestionId { get; set; }
        public int Level { get; set; }
        public string QuestionText { get; set; }
        public string QuestionCategory { get; set; }
        public virtual ICollection<OptionDetailDto> Options { get; set; }

    }

    public class OptionDetailDto
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public bool isTrue { get; set; }
    }
}
