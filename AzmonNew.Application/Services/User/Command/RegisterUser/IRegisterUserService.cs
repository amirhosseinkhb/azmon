using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using Microsoft.AspNet.Identity;
using System;

namespace AzmonNew.Application.Services.User.Command.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService(IDataBaseContext contexts)
        {
            _context = contexts;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                //fluent validation!!
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام خود را وارد کنید",
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "ایمیل خود را وارد کنید",
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پسورد خود را وارد کنید",
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پسورد و تکرار ان یکسان نمیباشند"
                    };
                }
                //?code meli check shod?
                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(request.Password);

                var user = new Domain.Entities.Users.User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    Password = hashedPassword,
                    NationalCode = request.NationalCode,

                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto() { UserId = user.Id },
                    IsSuccess = true,
                    Message = "",
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "خطا در ثبت نام"
                };
            }
        }
    }

    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public long NationalCode { get; set; }
    }

    public class ResultRegisterUserDto
    {
        public long UserId { set; get; }
    }
}
