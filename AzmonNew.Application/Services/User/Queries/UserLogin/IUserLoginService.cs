using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace AzmonNew.Application.Services.User.Queries.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultLoginDto> Execute(string fullname, string password);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;
        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultLoginDto> Execute(string fullname, string password)
        {
            var user = _context.Users.Where(p => p.FullName.Equals(fullname) || p.Email.Equals(fullname)).FirstOrDefault();
            if (user == null)
            {
                return new ResultDto<ResultLoginDto>()
                {
                    Data = new ResultLoginDto() { },
                    IsSuccess = false,
                    Message = "کاربری با این مشخصات یافت نشد"
                };
            }

            var passwordHasher = new PasswordHasher();
            var resultVerifyPassword = passwordHasher.VerifyHashedPassword(user.Password, password);

            if (resultVerifyPassword == PasswordVerificationResult.Failed)
            {
                return new ResultDto<ResultLoginDto>()
                {
                    Data = new ResultLoginDto() { },
                    IsSuccess = false,
                    Message = "رمز اشتباه است"
                };
            }
            return new ResultDto<ResultLoginDto>()
            {
                Data = new ResultLoginDto() {
                UserId = user.Id,
                Name=user.FullName,
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد"
            };

        }
    }
    public class ResultLoginDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
