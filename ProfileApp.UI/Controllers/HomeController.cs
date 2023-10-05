using Microsoft.AspNetCore.Mvc;
using ProfileApp.Business.Interfaces;

namespace ProfileApp.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {

            var model = await _userService.GetAllAsync();
            return View(model);
        }

        //public IActionResult Error(int? statusCode = null)
        //{
        //    if (statusCode.HasValue)
        //    {
        //        if (statusCode.Value == 404)
        //        {
        //            // 404 hatası özel işleme
        //            return View("NotFound");
        //        }
        //        // Diğer hata durumlarına yönlendirme
        //    }

        //    return View();
        //}

        public IActionResult NotFound(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404)
                {
                    // 404 hatası özel işleme
                    return View("NotFound");
                }
                // Diğer hata durumlarına yönlendirme
            }

            return View();
        }



    }
}