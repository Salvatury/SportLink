namespace SportLink.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activa { get; set; } = true;

        public int LigaId { get; set; }
        public Liga? Liga { get; set; }

        public ICollection<Equipo>? Equipos { get; set; }
        public ICollection<FechaTorneo>? FechasTorneo { get; set; }
    }
}