using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProfileApp.Business.Interfaces;
using ProfileApp.Business.ValidationRules;
using ProfileApp.Common;
using ProfileApp.Dto.TblActivationDtos;
using ProfileApp.Dto.TblUserAccountDtos;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.UI.Models;
using System.Security.Claims;

namespace ProfileApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserAccountService _userAccountService;
        private readonly IActivaitonService _activaitonService;
        private readonly IValidator<TblUserCreateDto> _Usercreatevalidator;
        private readonly IValidator<UserLoginDto> _UserLoginvalidator;
        private readonly IValidator<TblUserUpdateDto> _TblUserUpdateDtovalidator;
        private readonly IValidator<TblUserAccountCreateDto> _TblUserAccountCreateDtovalidator;

        public AccountController(IUserService userService, IUserAccountService userAccountService, IActivaitonService activaitonService, IValidator<TblUserCreateDto> usercreatevalidator, IValidator<UserLoginDto> userLoginvalidator, IValidator<TblUserUpdateDto> tblUserUpdateDtovalidator, IValidator<TblUserAccountCreateDto> tblUserAccountCreateDtovalidator)
        {
            _userService = userService;
            _userAccountService = userAccountService;
            _activaitonService = activaitonService;
            _Usercreatevalidator = usercreatevalidator;
            _UserLoginvalidator = userLoginvalidator;
            _TblUserUpdateDtovalidator = tblUserUpdateDtovalidator;
            _TblUserAccountCreateDtovalidator = tblUserAccountCreateDtovalidator;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterModel model)
        {
            var check = await _userService.UserControl(model.Username);
            if (check == true)
            {
                var data = new TblActivationListDto();
                data.ActivationCode = model.ActivaitonCode;

                var user = new TblUserCreateDto();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Username = model.Username;
                user.Password = model.Password;
                user.MailAdress = model.MailAdress;
                user.UserNamGuidId = new Guid(Guid.NewGuid().ToString());
                user.StatusId = 1;
                user.ImageUrl = "https://bootdey.com/img/Content/avatar/avatar1.png";

                var data2 = await _activaitonService.ActivaitonCheck(data);
                if (data2 == true)
                {
                    await _userService.CreateWithRoleAsync(user, 2);
                    return RedirectToAction("Login", "Account");
                }
				ViewBag.CustomError= "Activation Code Incorrect";
                return View();
            }
            ViewBag.CustomError2 = "Username is used. Try another username";
            return View();
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {

            var result = await _userService.CheckUserAsync(dto);
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
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authproperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authproperties);

                return RedirectToAction("AccountProfile", "Account");
            }

            ModelState.AddModelError("Username or password incorrect", result.Message);

            return View(dto);
        }


        [HttpGet]
        public async Task<IActionResult> AccountProfile()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            int Id = Convert.ToInt32(user.Value);
            var data = await _userService.GetByIdAsync<TblUserListDto>(Id);
            return View(new TblUserListDto
            {
                Id = data.Data.Id,
                Name = data.Data.Name,
                MailAdress = data.Data.MailAdress,
                Username = data.Data.Username,
                Surname = data.Data.Surname,
                Password = data.Data.Password,
                StatusId = data.Data.StatusId,
                UserNamGuidId = data.Data.UserNamGuidId,
                ImageUrl = data.Data.ImageUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> AccountProfile(TblUserUpdateDto dto, IFormFile formfile)
        {
            var Validate = _TblUserUpdateDtovalidator.Validate(dto);
            if (Validate.IsValid)
            {
                var data = await _userService.GetByIdAsync<TblUserListDto>(dto.Id);
                dto.StatusId = data.Data.StatusId;
                dto.UserNamGuidId = data.Data.UserNamGuidId;

                if (formfile != null)
                {
                    var newName = dto.UserNamGuidId + "." + formfile.FileName;
                    var path = Path.Combine("wwwroot", "Image", newName).Replace("\\", "/");
                    var pathImage = Path.Combine("~/Image", newName).Replace("\\", "/");


                    var stream = new FileStream(path, FileMode.Create);
                    await formfile.CopyToAsync(stream);
                    dto.ImageUrl = pathImage;
                }
                else
                {
                    if (data.Data.ImageUrl == null)
                    {
                        dto.ImageUrl = "https://bootdey.com/img/Content/avatar/avatar1.png";
                    }
                    else
                    {
                        dto.ImageUrl = data.Data.ImageUrl;
                    }

                }

                await _userService.UpdateAsync(dto);

                return View(new TblUserListDto
                {
                    ImageUrl = dto.ImageUrl,
                    StatusId = dto.StatusId,
                    Id = dto.Id,
                    MailAdress = dto.MailAdress,
                    Name = dto.Name,
                    Password = dto.Password,
                    Surname = dto.Surname,
                    Username = dto.Username,
                    UserNamGuidId = dto.UserNamGuidId
                });
            }
            return View(new TblUserListDto
            {
                ImageUrl = dto.ImageUrl,
                StatusId = dto.StatusId,
                Id = dto.Id,
                MailAdress = dto.MailAdress,
                Name = dto.Name,
                Password = dto.Password,
                Surname = dto.Surname,
                Username = dto.Username,
                UserNamGuidId = dto.UserNamGuidId
            });
        }





        [HttpGet]
        public async Task<IActionResult> SocialLink()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            int Id = Convert.ToInt32(user.Value);
            var data = await _userService.UserAccountList(Id);
            var Createdata = new TblUserAccountCreateDto();
            Createdata.UserId = Id;
            var ListData = new List<TblUserAccountListDto>();
            ListData.AddRange(data);


            return View(Tuple.Create(Createdata, ListData));

        }

        [HttpPost]
        public async Task<IActionResult> SocialLink(TblUserAccountCreateDto dto)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            int Id = Convert.ToInt32(user.Value);
            dto.UserId = Id;
            var Validate = _TblUserAccountCreateDtovalidator.Validate(dto);
            if (Validate.IsValid)
            {
                
                await _userAccountService.CreateAsync(dto);
                return RedirectToAction("SocialLink", "Account");
            }
            
            return RedirectToAction("SocialLink", "Account");
        }

        public async Task<IActionResult> Delete(int DeleteId)
        {
            await _userAccountService.RemoveAsync(DeleteId);
            return RedirectToAction("SocialLink", "Account");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSocialAccount(int Id)
        {
            var data = await _userAccountService.GetByIdAsync<TblUserAccountUpdateDto>(Id);

            return View(new TblUserAccountUpdateDto
            {
                Id = data.Data.Id,
                UserId = data.Data.UserId,
                AccountName = data.Data.AccountName,
                AccountUrl = data.Data.AccountUrl,
            });
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSocialAccount(TblUserAccountUpdateDto dto)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            int Id = Convert.ToInt32(user.Value);
            dto.UserId = Id;
            await _userAccountService.UpdateAsync(dto);
            return RedirectToAction("SocialLink", "Account");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}
