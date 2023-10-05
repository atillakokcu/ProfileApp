using Microsoft.AspNetCore.Mvc;
using ProfileApp.Business.Interfaces;
using ProfileApp.Dto.TblUserDtos;
using ProfileApp.Entity;
using ProfileApp.UI.Models;

namespace ProfileApp.UI.Controllers
{
	public class UserProfileController : Controller
	{
		private readonly IUserService _userService;
		private readonly IUserAccountService _userAccountService;

		public UserProfileController(IUserService userService, IUserAccountService userAccountService)
		{
			_userService = userService;
			_userAccountService = userAccountService;
		}


		//public IActionResult Profile()
		//{

		//	return View();
		//}



		public async Task<IActionResult> Profile(Guid Id)
		{

			var UserData = await _userService.UserInformationGuid(Id);
			

			if (UserData.Data != null )
			{
                var AccountList = _userService.UserAccountList(UserData.Data.Id);
                return View(new UserProfileModel
                {
                    Name = UserData.Data.Name,
                    ImageUrl = UserData.Data.ImageUrl,
                    Surname = UserData.Data.Surname,
                    UserAccounts = AccountList.Result,
                    UserNamGuidId = UserData.Data.UserNamGuidId
                });
            }


			return RedirectToAction("NotFound", "Home");
		}




	}
}
