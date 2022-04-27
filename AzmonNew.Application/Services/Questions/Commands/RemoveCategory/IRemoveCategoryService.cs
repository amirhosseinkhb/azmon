using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AzmonNew.Application.Services.Questions.Commands.RemoveCategory
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(int Id);
    }
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _context;

        public RemoveCategoryService(IDataBaseContext contexts)
        {
            _context = contexts;
        }

        public ResultDto Execute(int Id)
        {
            var category = _context.Categories.Find(Id);
            if (category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی پیدا نشد",
                };
            }

            var questions = _context
                .Questions.Include(p => p.Category)
                .Where(p => p.Category.Id == Id).ToList();

            foreach (var item in questions)
            {
                item.RemoveTime = DateTime.Now;
                item.IsRemoved = true;
            }

            category.RemoveTime = DateTime.Now;
            category.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقت حذف شد",
            };
        }
    }
}
