using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using AzmonNew.Domain.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmonNew.Application.Services.Questions.Commands.EmptyAzmon
{
    public interface IEmptyAzmonService
    {
        ResultDto<EmptyAzmonDto> Execute(string Name);
    }
    public class EmptyAzmonService : IEmptyAzmonService
    {
        private readonly IDataBaseContext _context;
        public EmptyAzmonService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<EmptyAzmonDto> Execute(string Name)
        {
            var azmon = new QuestionPacks()
            {
                Name = Name,
            };
            _context.QuestionPacks.Add(azmon);
            _context.SaveChanges();
            return new ResultDto<EmptyAzmonDto>()
            {
                Data =new EmptyAzmonDto()
                {
                    AzmonId = azmon.Id,
                },
                IsSuccess = true,
                Message = "empty made"
            };
        }
    }

    public class EmptyAzmonDto
    {
        public int AzmonId { get; set; }
    }
}
