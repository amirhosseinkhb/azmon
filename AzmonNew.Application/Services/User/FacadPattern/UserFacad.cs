using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Application.Interface.FacadPatterns;
using AzmonNew.Application.Services.User.Command.DeleteUser;
using AzmonNew.Application.Services.User.Command.RegisterUser;
using AzmonNew.Application.Services.User.Queries.GetUsers;
using AzmonNew.Application.Services.User.Queries.UserLogin;
using Microsoft.AspNetCore.Hosting;

namespace AzmonNew.Application.Services.User.FacadPattern
{
    public class UserFacad : IUserFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public UserFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private RegisterUserService _registerUserService;
        public RegisterUserService registerUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserService(_context);
            }
        }


        private IGetUsersService _getUserService;
        public IGetUsersService getUsersService
        {
            get { return _getUserService = _getUserService ?? new GetUsersService(_context); }
        }

        private DeleteUser _deleteUser;
        public DeleteUser deleteUser
        {
            get
            {
                return _deleteUser = _deleteUser ?? new DeleteUser(_context);
            }
        }

        private IUserLoginService _userLoginService;
        public IUserLoginService userLoginService
        {
            get { return _userLoginService = _userLoginService ?? new UserLoginService(_context); }
        }
    }
}
