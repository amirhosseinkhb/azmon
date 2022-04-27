using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;

namespace AzmonNew.Application.Services.Questions.Commands.EditQuestion
{
    public interface IEditQuestionService
    {
        ResultDto Execute(RequestEditQuestionDto request);
    }
    public class EditQuestionService : IEditQuestionService
    {

        private readonly IDataBaseContext _context;

        public EditQuestionService(IDataBaseContext dataBaseContexts)
        {
            _context = dataBaseContexts;
        }
        public ResultDto Execute(RequestEditQuestionDto request)
        {
            var question = _context.Questions.Find(request.Id);
            if (question == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "سوال پیدا نشد:("
                };
            }

            question.QuestionText = request.Text;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "متن سوال با موفقت تغییر یافت"
            };
        }
    }



    public class RequestEditQuestionDto
    {
        public string Text { get; set; }
        public int Id { get; set; }
    }
}
