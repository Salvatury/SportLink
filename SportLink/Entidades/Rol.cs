using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Rol
    {
        public int RolId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}