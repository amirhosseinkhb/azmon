using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmonNew.Application.Services.Questions.Commands.DeleteAzmon
{
    public interface IDeleteAzmonService
    {
        ResultDto Execute(int Id);
    }
    public class DeleteAzmonService : IDeleteAzmonService
    {
        private readonly IDataBaseContext _context;
        public DeleteAzmonService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var azmon = _context.QuestionPacks
                    .Find(Id);

            if (azmon == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "آزمون پیدا نشد",
                };
            }

            azmon.RemoveTime = DateTime.Now;
            azmon.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "آزمون حذف شد",
            };
        }
    }
}
