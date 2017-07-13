using Microsoft.AspNetCore.Mvc;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("/Error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            return View("Error", statusCode);
        }
    }
}
