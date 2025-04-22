using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Grupo9_PA_Examen.Models
{
    public class Horario
    {
        public int Id { get; set; }

        [Required]
        public int DocenteId { get; set; }

        [Required]
        public int AsignaturaId { get; set; }

        [Required]
        [StringLength(20)]
        public string DiaSemana { get; set; } // Lunes, Martes, etc.

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        [ForeignKey("DocenteId")]
        public Docente Docente { get; set; }

        [ForeignKey("AsignaturaId")]
        public Asignatura Asignatura { get; set; }
    }
}
