using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ProjektHaushaltsbuch.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorldController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int id, int numTimes = 1)
        {
            ViewData["Message"] = HtmlEncoder.Default.Encode($"Hello {name}, ID: {id}"); // prevents XSS attacks
            ViewData["NumTimes"] = numTimes;
            return View(); 
        }

    }
}
