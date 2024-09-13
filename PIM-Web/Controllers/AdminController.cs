using Microsoft.AspNetCore.Mvc;
using PIM_Web.Services;

namespace PIM_Web.Controllers
{
   
        public class AdminController : Controller
        {

        public IActionResult Index()
            {
                return View();
            }

            public IActionResult EditarUsuarios()
            {
                return View();
            }

            public IActionResult ExcluirUsuarios()
            {
                return View();
            }

            public IActionResult EnviarEmail()
            {
                return View();
            }
       
    }
    
}
