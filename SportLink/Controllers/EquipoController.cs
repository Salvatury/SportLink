using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportLink.Data;
using SportLink.Entidades;

namespace SportLink.Controllers
{
    public class EquipoController : Controller
    {
        private readonly AppDbContext _context;

        public EquipoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var equipos = _context.Equipos.ToList();
            return View(equipos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre", equipo.CategoriaId);
                return View(equipo);
            }

            _context.Equipos.Add(equipo);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var equipo = _context.Equipos.Find(id);

            if (equipo == null)
            {
                return NotFound();
            }

            ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre", equipo.CategoriaId);
            return View(equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(_context.Categorias.ToList(), "CategoriaId", "Nombre", equipo.CategoriaId);
                return View(equipo);
            }

            var equipoDb = _context.Equipos.Find(equipo.EquipoId);

            if (equipoDb == null)
            {
                return NotFound();
            }

            equipoDb.Nombre = equipo.Nombre;
            equipoDb.Descripcion = equipo.Descripcion;
            equipoDb.LogoPath = equipo.LogoPath;
            equipoDb.Activo = equipo.Activo;
            equipoDb.CategoriaId = equipo.CategoriaId;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var equipo = _context.Equipos.Find(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var equipo = _context.Equipos.Find(id);

            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipo);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}