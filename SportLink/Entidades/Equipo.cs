using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Equipo
    {
        public int EquipoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        [StringLength(255)]
        public string? LogoPath { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<Partido> PartidosComoLocal { get; set; } = new List<Partido>();
        public ICollection<Partido> PartidosComoVisitante { get; set; } = new List<Partido>();
    }
}