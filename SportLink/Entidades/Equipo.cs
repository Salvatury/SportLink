namespace SportLink.Entidades
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? LogoUrl { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<Partido>? PartidosComoLocal { get; set; }
        public ICollection<Partido>? PartidosComoVisitante { get; set; }
    }
}