using System.ComponentModel.DataAnnotations;

namespace Grupo9_PA_Examen.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Cedula { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Carrera { get; set; }

        [Required]
        public int Semestre { get; set; }  // Cambiar de string a int para funcionar con lógica

        public string Estado { get; set; }

        // Para recibir los IDs de las materias seleccionadas
        public List<int> MateriasSeleccionadas { get; set; } = new List<int>();

        // Navegación (si se usa EF Core para la relación)
        public List<Matricula> Matriculas { get; set; }
    }
}
