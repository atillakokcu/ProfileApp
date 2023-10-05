using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProfileApp.Business.Interfaces;
using ProfileApp.Common;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.UI.Areas.Admin.Models;
using System.Security.Claims;

namespace ProfileApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult AdminGiris()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AdminGiris(AdminLoginDto dto)
        {
            var adminlogindto = new UserLoginDto();
            adminlogindto.Username = dto.Username;
            adminlogindto.Password = dto.Password;
            adminlogindto.RememberMe = false;

            var result = await _userService.CheckUserAsync(adminlogindto);

            var ctr = await _userService.AdminCheckControl(result.Data.Username);
            if (ctr == true)
            {
                if (result.ResponseType == ResponseType.Success)
                {
                    var roleResult = await _userService.GetRolesByUserIdAsync(result.Data.Id);
                    var claims = new List<Claim> { };
                    if (roleResult.ResponseType == ResponseType.Success)
                    {
                        foreach (var role in roleResult.Data)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.Defination));
                            
                        }
                    }
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authproperties = new AuthenticationProperties
                    {
                        IsPersistent = adminlogindto.RememberMe,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authproperties);

                    return RedirectToAction("List", "User");
                }
            }
            

            return View();
        }

        
        public async Task<IActionResult> AdminLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AdminGiris", "Account");
        }
    }
}
