namespace Grupo9_PA_Examen.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }

        public Rol Rol { get; set; }
    }
}
