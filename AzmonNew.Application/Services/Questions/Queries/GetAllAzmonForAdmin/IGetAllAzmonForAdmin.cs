using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common;
using AzmonNew.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AzmonNew.Application.Services.Questions.Queries.GetAzmonForAdmin
{
    public interface IGetAllAzmonForAdmin
    {
        ResultDto<ResultAllAzmonAdmin> Execute(string searchKey, int page = 1);
    }
    public class GetAllAzmonForAdmin : IGetAllAzmonForAdmin
    {
        private readonly IDataBaseContext _context;

        public GetAllAzmonForAdmin(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultAllAzmonAdmin> Execute(string searchKey, int page = 1)
        {
            var azmon = _context.QuestionPacks
                  .Include(p => p.Questions)
                  .Include(p => p.Categories)
                  .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                azmon = azmon.Where(p => p.Name.Contains(searchKey) );
            }

            int rowCount = 0;
            var azmonList = azmon.ToPaged(page, 200, out rowCount).Select(p => new getAllAzmonAdmin
            {
                QuestionCount = p.QuestionCount,
                AzmonLevel = p.Level,
                Name = p.Name,
                Id = p.Id,
                Categories=p.Categories.Select(p=>p.Name).ToList(),
            }).ToList();

            return new ResultDto<ResultAllAzmonAdmin>()
            {
                Data = new ResultAllAzmonAdmin()
                {
                    AllAzmons=azmonList,
                    CurrentPage = page,
                    RowCount = rowCount,
                    PageSize = 20
                },
                IsSuccess = true,
                Message = ""
            };
        }
        

    }

    public class ResultAllAzmonAdmin
    {
        public IList<getAllAzmonAdmin> AllAzmons { get; set; }
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

    public class getAllAzmonAdmin
    {
        public int QuestionCount { get; set; }
        public int Id { get; set; }
        public int AzmonLevel { get; set; }
        public string Name { get; set; }
        public virtual List<string> Categories { get; set; }
    }
}
