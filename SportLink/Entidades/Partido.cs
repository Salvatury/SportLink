using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Partido
    {
        public int PartidoId { get; set; }

        public DateTime FechaHora { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Observaciones { get; set; }

        public int FechaTorneoId { get; set; }
        public FechaTorneo? FechaTorneo { get; set; }

        public int EquipoLocalId { get; set; }
        public Equipo? EquipoLocal { get; set; }

        public int EquipoVisitanteId { get; set; }
        public Equipo? EquipoVisitante { get; set; }

        public int? CanchaId { get; set; }
        public Cancha? Cancha { get; set; }

        public int? ArbitroId { get; set; }
        public Usuario? Arbitro { get; set; }

        public Resultado? Resultado { get; set; }
    }
}