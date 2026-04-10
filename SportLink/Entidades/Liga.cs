namespace SportLink.Entidades
{
    public class Liga
    {
        public int LigaId { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activa { get; set; } = true;
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public ICollection<Categoria>? Categorias { get; set; }
    }
}