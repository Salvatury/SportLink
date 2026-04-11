using Microsoft.AspNetCore.Mvc;
using SportLink.Data;
using SportLink.Entidades;

namespace SportLink.Controllers
{
    public class CanchaController : Controller
    {
        private readonly AppDbContext _context;

        public CanchaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var canchas = _context.Canchas.ToList();
            return View(canchas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cancha cancha)
        {
            if (!ModelState.IsValid)
            {
                return View(cancha);
            }

            _context.Canchas.Add(cancha);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cancha = _context.Canchas.Find(id);

            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cancha cancha)
        {
            if (!ModelState.IsValid)
            {
                return View(cancha);
            }

            var canchaDb = _context.Canchas.Find(cancha.CanchaId);

            if (canchaDb == null)
            {
                return NotFound();
            }

            canchaDb.Nombre = cancha.Nombre;
            canchaDb.Direccion = cancha.Direccion;
            canchaDb.Localidad = cancha.Localidad;
            canchaDb.Provincia = cancha.Provincia;
            canchaDb.Activo = cancha.Activo;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var cancha = _context.Canchas.Find(id);

            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var cancha = _context.Canchas.Find(id);

            if (cancha == null)
            {
                return NotFound();
            }

            _context.Canchas.Remove(cancha);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}