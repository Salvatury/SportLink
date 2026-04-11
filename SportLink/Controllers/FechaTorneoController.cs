using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportLink.Data;
using SportLink.Entidades;

namespace SportLink.Controllers
{
    public class FechaTorneoController : Controller
    {
        private readonly AppDbContext _context;

        public FechaTorneoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var fechas = _context.FechasTorneo.ToList();
            return View(fechas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(FechaTorneo fechaTorneo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre", fechaTorneo.CategoriaId);
                return View(fechaTorneo);
            }

            _context.FechasTorneo.Add(fechaTorneo);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var fechaTorneo = _context.FechasTorneo.Find(id);

            if (fechaTorneo == null)
            {
                return NotFound();
            }

            ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre", fechaTorneo.CategoriaId);
            return View(fechaTorneo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(FechaTorneo fechaTorneo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre", fechaTorneo.CategoriaId);
                return View(fechaTorneo);
            }

            var fechaDb = _context.FechasTorneo.Find(fechaTorneo.FechaTorneoId);

            if (fechaDb == null)
            {
                return NotFound();
            }

            fechaDb.Numero = fechaTorneo.Numero;
            fechaDb.FechaProgramada = fechaTorneo.FechaProgramada;
            fechaDb.Cerrada = fechaTorneo.Cerrada;
            fechaDb.CategoriaId = fechaTorneo.CategoriaId;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var fechaTorneo = _context.FechasTorneo.Find(id);

            if (fechaTorneo == null)
            {
                return NotFound();
            }

            return View(fechaTorneo);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var fechaTorneo = _context.FechasTorneo.Find(id);

            if (fechaTorneo == null)
            {
                return NotFound();
            }

            _context.FechasTorneo.Remove(fechaTorneo);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}