using Microsoft.AspNetCore.Mvc;

namespace SportLink.Controllers
{
    public class PartidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
