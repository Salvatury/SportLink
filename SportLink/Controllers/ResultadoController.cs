using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportLink.Data;
using SportLink.Entidades;

namespace SportLink.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly AppDbContext _context;

        public ResultadoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var resultados = _context.Resultados.ToList();

            // TODO: más adelante mejorar este listado para mostrar datos relacionados,
            // por ejemplo nombre de equipos, partido y usuario que cargó el resultado,
            // en vez de trabajar solo con los datos básicos de Resultado.
            return View(resultados);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            CargarCombos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Resultado resultado)
        {
            if (!ModelState.IsValid)
            {
                CargarCombos(resultado);
                return View(resultado);
            }

            // TODO: validar que el partido seleccionado no tenga ya un resultado cargado,
            // porque la relación Partido-Resultado es 1 a 1.
            _context.Resultados.Add(resultado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var resultado = _context.Resultados.Find(id);

            if (resultado == null)
            {
                return NotFound();
            }

            CargarCombos(resultado);
            return View(resultado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Resultado resultado)
        {
            if (!ModelState.IsValid)
            {
                CargarCombos(resultado);
                return View(resultado);
            }

            var resultadoDb = _context.Resultados.Find(resultado.ResultadoId);

            if (resultadoDb == null)
            {
                return NotFound();
            }

            resultadoDb.GolesLocal = resultado.GolesLocal;
            resultadoDb.GolesVisitante = resultado.GolesVisitante;
            resultadoDb.Observaciones = resultado.Observaciones;
            resultadoDb.FechaCarga = resultado.FechaCarga;
            resultadoDb.PartidoId = resultado.PartidoId;
            resultadoDb.CargadoPorUsuarioId = resultado.CargadoPorUsuarioId;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var resultado = _context.Resultados.Find(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var resultado = _context.Resultados.Find(id);

            if (resultado == null)
            {
                return NotFound();
            }

            _context.Resultados.Remove(resultado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private void CargarCombos(Resultado? resultado = null)
        {
            // TODO: más adelante mostrar una descripción más útil del partido
            // (por ejemplo "Equipo Local vs Equipo Visitante - fecha/hora")
            // en vez de mostrar solo PartidoId.
            ViewBag.Partidos = new SelectList(_context.Partidos.ToList(), "PartidoId", "PartidoId", resultado?.PartidoId);

            // TODO: más adelante mostrar "Nombre + Apellido"
            // y filtrar usuarios según rol, por ejemplo solo árbitros o usuarios habilitados.
            ViewBag.Usuarios = new SelectList(_context.Usuarios.ToList(), "UsuarioId", "Nombre", resultado?.CargadoPorUsuarioId);
        }
    }
}