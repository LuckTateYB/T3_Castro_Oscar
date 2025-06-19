using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CRUD_Oscar.Models;
using CRUD_Oscar.Datos;

namespace CRUD_Oscar.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LibroController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> listaCategorias = _db.Libros;
            return View(listaCategorias);
        }

        [Authorize]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Libro libro)
        {
            _db.Libros.Add(libro);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        //get Editar

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Libros.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libros.Update(libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        [Authorize]
        //get Eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Libros.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
