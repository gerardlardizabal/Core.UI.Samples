using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Base.Core.App.Interface.UserAccounts;
using Base.Core.App.Models.Generics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static Base.Core.App.Models.UserAccounts.UserAccountsModel;

namespace Base.Core.App.Controllers.UserAccounts
{
    [Route("/Account")]
    public class UserAccountsController : Controller
    {
        IUserService _userService;
        public UserAccountsController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [Route("LogoutUser")]
        public async Task<IActionResult> LogoutUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return Redirect("/");
        }

        [HttpPost]
        [Route("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser([FromForm]string username, string password, string returnUrl)
        {
            LoginResponse loginResponse = await _userService.Authenticate(new LoginRequest { password = password, username = username });
            if (loginResponse.allowedLogin)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,username)
                };

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    IssuedUtc = DateTime.Now,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = "/"
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                HttpContext.Session.SetString("User", loginResponse.user.FirstName);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
                
            }
            else
            {
                 ModelState.AddModelError("Error",loginResponse.message);
            }
            return View("Login");
        }
    }
}