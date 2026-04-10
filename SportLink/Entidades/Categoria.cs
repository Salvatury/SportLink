using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        public bool Activa { get; set; } = true;

        public int LigaId { get; set; }
        public Liga? Liga { get; set; }

        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
        public ICollection<FechaTorneo> FechasTorneo { get; set; } = new List<FechaTorneo>();
    }
}