namespace SportLink.Entidades
{
    public class Resultado
    {
        public int ResultadoId { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaCarga { get; set; } = DateTime.Now;

        public int PartidoId { get; set; }
        public Partido? Partido { get; set; }

        public int CargadoPorUsuarioId { get; set; }
        public Usuario? CargadoPorUsuario { get; set; }
    }
}