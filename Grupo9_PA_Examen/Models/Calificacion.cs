using System.ComponentModel.DataAnnotations;

namespace Grupo9_PA_Examen.Models
{
    public class Calificacion
    {
        public int Id { get; set; }

        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

        [Range(0, 10)]
        public double Nota { get; set; }
    }
}
