using System.ComponentModel.DataAnnotations;

namespace Grupo9_PA_Examen.Models
{
    public class Asignatura
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }

        [Required]
        [Range(1, 10)]
        public int Creditos { get; set; }

        [Required]
        public int Nivel { get; set; }  // Nivel o semestre en el que se imparte

        [StringLength(100)]
        public string Carrera { get; set; } = "Tecnologías de la Información";
    }
}
