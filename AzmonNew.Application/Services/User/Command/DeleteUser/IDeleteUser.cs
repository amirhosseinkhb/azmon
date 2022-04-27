using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmonNew.Application.Services.User.Command.DeleteUser
{
    public interface IDeleteUser
    {
        ResultDto Execute(int UserId);
    }

    public class DeleteUser : IDeleteUser
    {
        private readonly IDataBaseContext _context;
        public DeleteUser(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int UserId)
        {
            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد",
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = " کاربر با موفقیت حذف شد",
            };
        }
    }
}
