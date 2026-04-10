using System.ComponentModel.DataAnnotations;

namespace SportLink.Entidades
{
    public class Liga
    {
        public int LigaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        public bool Activa { get; set; } = true;
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}