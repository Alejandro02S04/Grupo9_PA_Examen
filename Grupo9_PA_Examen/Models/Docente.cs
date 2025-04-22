using System.ComponentModel.DataAnnotations;

namespace Grupo9_PA_Examen.Models
{
    public class Docente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Especialidad { get; set; }

        public string Estado { get; set; } = "Activo";
    }
}
