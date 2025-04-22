using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Grupo9_PA_Examen.Models
{
    public class Matricula
    {
        public int Id { get; set; }

        [Required]
        public int EstudianteId { get; set; }

        [Required]
        public int AsignaturaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relaciones
        [ForeignKey("EstudianteId")]
        public Estudiante Estudiante { get; set; }

        [ForeignKey("AsignaturaId")]
        public Asignatura Asignatura { get; set; }
    }
}
