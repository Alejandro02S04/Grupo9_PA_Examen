using Microsoft.EntityFrameworkCore;
using Grupo9_PA_Examen.Models;
using System.Security.Cryptography.Xml;
namespace Grupo9_PA_Examen.Data
{
    public class UniversidadContext : DbContext
    {
        

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }


        public UniversidadContext(DbContextOptions<UniversidadContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }


    }

}
