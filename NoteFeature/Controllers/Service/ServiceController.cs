using Microsoft.AspNetCore.Mvc;

namespace NoteFeature.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
