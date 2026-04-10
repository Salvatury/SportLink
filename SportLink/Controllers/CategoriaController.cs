using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportLink.Data;
using SportLink.Entidades;

namespace SportLink.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Ligas = new SelectList(_context.Ligas.ToList(), "LigaId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Ligas = new SelectList(_context.Ligas.ToList(), "LigaId", "Nombre", categoria.LigaId);
                return View(categoria);
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            ViewBag.Ligas = new SelectList(_context.Ligas.ToList(), "LigaId", "Nombre", categoria.LigaId);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Ligas = new SelectList(_context.Ligas.ToList(), "LigaId", "Nombre", categoria.LigaId);
                return View(categoria);
            }

            var categoriaDb = _context.Categorias.Find(categoria.CategoriaId);

            if (categoriaDb == null)
            {
                return NotFound();
            }

            categoriaDb.Nombre = categoria.Nombre;
            categoriaDb.Descripcion = categoria.Descripcion;
            categoriaDb.Activa = categoria.Activa;
            categoriaDb.LigaId = categoria.LigaId;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}