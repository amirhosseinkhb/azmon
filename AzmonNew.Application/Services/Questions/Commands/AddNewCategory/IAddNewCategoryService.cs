using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using AzmonNew.Domain.Entities.Questions;


namespace Azmon.Application.Services.Question.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(string Name);
    }

    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext dataBaseContexts)
        {
            _context = dataBaseContexts;
        }
        public ResultDto Execute(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد کنید",
                };
            }

            Category category = new Category()
            {
                Name = Name,
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی اضافه شد"
            };
        }
    }
}
