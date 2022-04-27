using AzmonNew.Application.Interface.FacadPatterns;
using AzmonNew.Application.Services.User.Command.RegisterUser;
using AzmonNew.Application.Services.User.FacadPattern;
using AzmonNew.Application.Services.User.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserFacad _userFacad;
        public UserController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }
        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_userFacad.getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey
            }));
        }



        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, string Password, string RePassword, long NationalCode)
        {

             var result = _userFacad.registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                NationalCode = NationalCode,
                Password = Password,
                RePassword = RePassword,
            });
            return Json(result);
         }

        [HttpPost]
        public IActionResult Delete(int UserId)
        {
            return Json(_userFacad.deleteUser.Execute(UserId));
        }
    }
}
