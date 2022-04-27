using AzmonNew.Application.Services.User.Command.DeleteUser;
using AzmonNew.Application.Services.User.Command.RegisterUser;
using AzmonNew.Application.Services.User.Queries.GetUsers;
using AzmonNew.Application.Services.User.Queries.UserLogin;

namespace AzmonNew.Application.Interface.FacadPatterns
{

    public interface IUserFacad
    {
        RegisterUserService registerUserService { get; }
        IGetUsersService getUsersService { get; }
        DeleteUser deleteUser { get; }
        IUserLoginService userLoginService { get; }
    }
}
