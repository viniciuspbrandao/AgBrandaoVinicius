using AgBrandaoVinicius.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgBrandaoVinicius.Controllers
{
    public class HomeController : Controller
    {
     

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Destinos()
        {
            return View();
        }

        public IActionResult Promocoes()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }
    }
}