using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Cancha
    {
        public int CanchaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(100)]
        public string? Localidad { get; set; }

        [StringLength(100)]
        public string? Provincia { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Partido> Partidos { get; set; } = new List<Partido>();
    }
}