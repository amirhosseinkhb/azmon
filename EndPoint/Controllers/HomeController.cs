using AzmonNew.Application.Interface.FacadPatterns;
using EndPoint.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserFacad _userFacad;
 

        public HomeController(ILogger<HomeController> logger, IUserFacad userFacad)
        {
            _logger = logger;
            _userFacad = userFacad;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string fullname,string password)
        {
            var result=_userFacad.userLoginService.Execute(fullname, password);
            if (result.IsSuccess)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,result.Data.UserId.ToString()),
                //new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, fullname),
                new Claim(ClaimTypes.Email, result.Data.UserId.ToString()),
               
                
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
