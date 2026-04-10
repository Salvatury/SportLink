using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Resultado
    {
        public int ResultadoId { get; set; }

        [Range(0, int.MaxValue)]
        public int GolesLocal { get; set; }

        [Range(0, int.MaxValue)]
        public int GolesVisitante { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        public DateTime FechaCarga { get; set; } = DateTime.Now;

        public int PartidoId { get; set; }
        public Partido? Partido { get; set; }

        public int CargadoPorUsuarioId { get; set; }
        public Usuario? CargadoPorUsuario { get; set; }
    }
}