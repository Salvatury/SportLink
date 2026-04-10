using Microsoft.AspNetCore.Mvc;
using SportLink.Data;
using SportLink.Entidades;

namespace SportLink.Controllers
{
    public class LigaController : Controller
    {
        private readonly AppDbContext _context;

        public LigaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ligas = _context.Ligas.ToList();
            return View(ligas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Liga liga)
        {
            if (!ModelState.IsValid)
            {
                return View(liga);
            }

            _context.Ligas.Add(liga);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var liga = _context.Ligas.Find(id);

            if (liga == null)
            {
                return NotFound();
            }

            return View(liga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Liga liga)
        {
            if (!ModelState.IsValid)
            {
                return View(liga);
            }

            var ligaDb = _context.Ligas.Find(liga.LigaId);

            if (ligaDb == null)
            {
                return NotFound();
            }

            ligaDb.Nombre = liga.Nombre;
            ligaDb.Descripcion = liga.Descripcion;
            ligaDb.Activa = liga.Activa;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var liga = _context.Ligas.Find(id);

            if (liga == null)
            {
                return NotFound();
            }

            return View(liga);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var liga = _context.Ligas.Find(id);

            if (liga == null)
            {
                return NotFound();
            }

            _context.Ligas.Remove(liga);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}