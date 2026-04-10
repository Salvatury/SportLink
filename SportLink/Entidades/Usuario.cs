namespace SportLink.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Telefono { get; set; }
        public string? Dni { get; set; }
        public bool Activo { get; set; } = true;
        public bool EmailVerificado { get; set; } = false;
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public int RolId { get; set; }
        public Rol? Rol { get; set; }

        public ICollection<Partido>? PartidosArbitrados { get; set; }
        public ICollection<Resultado>? ResultadosCargados { get; set; }
    }
}