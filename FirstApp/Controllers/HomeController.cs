using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstApp.Models;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult SayHi()
        {
            return View(new SayHiViewModel());
        }

        [HttpPost]
        public ActionResult SayHi(SayHiViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Hi", model);
            }

            return View(model);
        }


        public ActionResult Hi(HiViewModel model)
        {
            if (model == null)
            {
                model = new HiViewModel();
            }
            model.GreetingSuffix = DateTime.Now.Hour > 12 ? "Evening" : "Morning";

            return View(model);
        }

        public IActionResult Index()
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
