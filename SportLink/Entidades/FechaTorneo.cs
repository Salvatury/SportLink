namespace SportLink.Entidades
{
    public class FechaTorneo
    {
        public int FechaTorneoId { get; set; }
        public int Numero { get; set; }
        public DateTime? FechaProgramada { get; set; }
        public bool Cerrada { get; set; } = false;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<Partido>? Partidos { get; set; }
    }
}