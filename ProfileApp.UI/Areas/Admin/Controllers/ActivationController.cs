using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using ProfileApp.Business.Interfaces;
using ProfileApp.Dto.TblActivationDtos;
using ProfileApp.Dto.TblUserDtos;

namespace ProfileApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    
    public class ActivationController : Controller
    {
        private readonly IActivaitonService _activaitonService;

        public ActivationController(IActivaitonService activaitonService)
        {
            _activaitonService = activaitonService;
        }

        
        public async Task< IActionResult> List()
        {
            var data = await _activaitonService.GetAllAsync();
            var ActivationList = new List<TblActivationListDto>();
            ActivationList.AddRange(data.Data);
            return View(ActivationList);
        }

        
        [HttpGet]
        public async Task< IActionResult> ReserveActivaitonCode(int Id)
        {
           var control= await _activaitonService.ActivatonStattusReserve(Id);
            if (control==true)
            {
                return RedirectToAction("List", "Activation");
            }

            return RedirectToAction("List", "Activation");
        }

        [HttpGet]
        public IActionResult ActivaitonAdd()
        {
            return View(new TblActivationCreateDto());
        }



        [HttpPost]
        public async Task<IActionResult> ActivaitonAdd(TblActivationCreateDto dto)
        {
            await _activaitonService.CreateAsync(dto);
            return RedirectToAction("List", "Activation");
        }


    }
}
