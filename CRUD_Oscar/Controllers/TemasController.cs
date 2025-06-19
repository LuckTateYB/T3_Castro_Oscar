using Microsoft.AspNetCore.Mvc;

namespace CRUD_Oscar.Controllers
{
    public class TemasController : Controller
    {
        public IActionResult Arquitectura()
        {
            return View();
        }

        public IActionResult Diseno()
        {
            return View();
        }
    }
}
