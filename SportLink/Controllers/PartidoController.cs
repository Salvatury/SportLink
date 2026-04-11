using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportLink.Data;
using SportLink.Entidades;

namespace SportLink.Controllers
{
    public class PartidoController : Controller
    {
        private readonly AppDbContext _context;

        public PartidoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var partidos = _context.Partidos.ToList();
            return View(partidos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            CargarCombos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Partido partido)
        {
            if (!ModelState.IsValid)
            {
                CargarCombos(partido);
                return View(partido);
            }

            _context.Partidos.Add(partido);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var partido = _context.Partidos.Find(id);

            if (partido == null)
            {
                return NotFound();
            }

            CargarCombos(partido);
            return View(partido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Partido partido)
        {
            if (!ModelState.IsValid)
            {
                CargarCombos(partido);
                return View(partido);
            }

            var partidoDb = _context.Partidos.Find(partido.PartidoId);

            if (partidoDb == null)
            {
                return NotFound();
            }

            partidoDb.FechaHora = partido.FechaHora;
            partidoDb.Estado = partido.Estado;
            partidoDb.Observaciones = partido.Observaciones;
            partidoDb.FechaTorneoId = partido.FechaTorneoId;
            partidoDb.EquipoLocalId = partido.EquipoLocalId;
            partidoDb.EquipoVisitanteId = partido.EquipoVisitanteId;
            partidoDb.CanchaId = partido.CanchaId;
            partidoDb.ArbitroId = partido.ArbitroId;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var partido = _context.Partidos.Find(id);

            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var partido = _context.Partidos.Find(id);

            if (partido == null)
            {
                return NotFound();
            }

            _context.Partidos.Remove(partido);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private void CargarCombos(Partido? partido = null)
        {
            ViewBag.FechasTorneo = new SelectList(_context.FechasTorneo.ToList(), "FechaTorneoId", "Numero", partido?.FechaTorneoId);
            ViewBag.EquiposLocal = new SelectList(_context.Equipos.ToList(), "EquipoId", "Nombre", partido?.EquipoLocalId);
            ViewBag.EquiposVisitante = new SelectList(_context.Equipos.ToList(), "EquipoId", "Nombre", partido?.EquipoVisitanteId);
            ViewBag.Canchas = new SelectList(_context.Canchas.ToList(), "CanchaId", "Nombre", partido?.CanchaId);
            ViewBag.Arbitros = new SelectList(_context.Usuarios.ToList(), "UsuarioId", "Nombre", partido?.ArbitroId);
        }
    }
}