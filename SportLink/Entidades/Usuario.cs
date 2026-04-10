using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Phone]
        [StringLength(30)]
        public string? Telefono { get; set; }

        [StringLength(20)]
        public string? Dni { get; set; }

        public bool Activo { get; set; } = true;
        public bool EmailVerificado { get; set; } = false;
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public int RolId { get; set; }
        public Rol? Rol { get; set; }

        public ICollection<Partido> PartidosArbitrados { get; set; } = new List<Partido>();
        public ICollection<Resultado> ResultadosCargados { get; set; } = new List<Resultado>();
    }
}