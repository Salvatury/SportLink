namespace SportLink.Entidades
{
    public class Cancha
    {
        public int CanchaId { get; set; }
        public string Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public bool Activo { get; set; } = true;

        public ICollection<Partido>? Partidos { get; set; }
    }
}