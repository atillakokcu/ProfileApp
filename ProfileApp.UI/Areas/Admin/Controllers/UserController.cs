using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileApp.Business.Interfaces;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.Entity;
using ProfileApp.UI.Areas.Admin.Models;
using System.Data;
using System.Linq;

namespace ProfileApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAppRoleService _appRoleService;

        public UserController(IUserService userService, IAppRoleService appRoleService)
        {
            _userService = userService;
            _appRoleService = appRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string p)
        {
            var userwithrole = await _userService.UserListWithRoleStatus();
            if (p==null)
            {
                
                // kullanıcı role bilgisinide göndermem gerekli
                return View(userwithrole);
            }
           
            var datam = userwithrole.FindAll(x=>x.TblUser.Username.Contains(p));


            // kullanıcı role bilgisinide göndermem gerekli
            return View(datam);

        }

        

        public async Task< IActionResult> UserDetails(int Id)
        {
            var data = await _userService.GetByIdAsync<TblUser>(Id);
            var Userdata = new UpdateUserDetail();
            Userdata.Username = data.Data.Username;
            Userdata.Surname = data.Data.Surname;
            Userdata.Name = data.Data.Name;
            Userdata.Password = data.Data.Password;
            Userdata.StatusId = data.Data.StatusId;
            Userdata.UserNamGuidId = data.Data.UserNamGuidId;
            Userdata.Id = data.Data.Id;
            Userdata.MailAdress = data.Data.MailAdress;
            Userdata.ImageUrl = data.Data.ImageUrl;

            var Roledata = await _appRoleService.FindUserId(Userdata.Id);
            Userdata.RoleId = Roledata.RoleId;




            return View(Userdata);
        }

        [HttpPost]
        public async Task<IActionResult> UserDetails(UpdateUserDetail dto)
        {
            var tblupdateusedto = new TblUserUpdateDto();
            tblupdateusedto.Username = dto.Username;
            tblupdateusedto.UserNamGuidId = dto.UserNamGuidId;
            tblupdateusedto.StatusId = dto.StatusId;
            tblupdateusedto.Id = dto.Id;
            tblupdateusedto.ImageUrl = dto.ImageUrl;
            tblupdateusedto.MailAdress = dto.MailAdress;
            tblupdateusedto.Name = dto.Name;
            tblupdateusedto.Password = dto.Password;
            tblupdateusedto.Surname = dto.Surname;
            
            if (tblupdateusedto.ImageUrl == null)
            {
                tblupdateusedto.ImageUrl = "https://bootdey.com/img/Content/avatar/avatar1.png";
            }
            await _userService.UpdateAsync(tblupdateusedto);

            return RedirectToAction("List", "User");
        }


    }
}
