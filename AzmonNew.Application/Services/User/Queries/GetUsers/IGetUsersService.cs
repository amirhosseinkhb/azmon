using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common;
using AzmonNew.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmonNew.Application.Services.User.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }

    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        ResultGetUserDto IGetUsersService.Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();


            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;

            var userList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                Fullname = p.FullName,
                Id = p.Id,
                
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = userList,
            };
            //var userList=_context.Users.ToList()
            //    .Select(x => new GetUsersDto
            //    {
            //        Email = x.Email,
            //        Fullname=x.FullName,
            //        Id = x.Id,
            //    }).ToList();

            //return new ResultDto<List<GetUsersDto>>()
            //{
            //    Data = userList,
            //    IsSuccess = true,
            //    Message = "user sent"
            //};

        }
    }
    public class GetUsersDto
    {
        public string Fullname { get; set; }
        public string Email{ get; set; }
        public int Id { get; set; }
    }

    public class ResultGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int Rows { get; set; }

    }

    public class RequestGetUserDto
    {
        public string SearchKey { get; set; }
        public int Page { get; set; }
    }


}
