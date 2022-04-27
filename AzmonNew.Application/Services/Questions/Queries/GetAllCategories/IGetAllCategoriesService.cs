using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using System.Collections.Generic;
using System.Linq;


namespace Azmon.Application.Services.Question.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }

    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetAllCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.Name}"
                }).ToList();



            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = true,
                Message = "",
            };
        }
    }

    public class AllCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
