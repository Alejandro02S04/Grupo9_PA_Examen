
using Grupo9_PA_Examen.Data;  // Importa el contexto de la base de datos
using Grupo9_PA_Examen.Models; // Importa el modelo de Docente
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // Para usar las consultas de Entity Framework


    public class DocentesListModel : PageModel
    {
        private readonly UniversidadContext _context;

        // Constructor que recibe el contexto de la base de datos
        public DocentesListModel(UniversidadContext context)
        {
            _context = context;
        }

        // Propiedad que contendrá la lista de docentes
        public List<Docente> Docentes { get; set; }

        // Método OnGet que se ejecuta cuando se accede a la página
        public void OnGet()
        {
            // Obtiene la lista de docentes de la base de datos
            Docentes = _context.Docentes.ToList();
        }
    }

