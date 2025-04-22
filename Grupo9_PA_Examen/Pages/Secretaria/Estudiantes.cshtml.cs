using Grupo9_PA_Examen.Data;
using Grupo9_PA_Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Grupo9_PA_Examen.Pages.Secretaria
{
    public class EstudiantesModel : PageModel
    {
        private readonly UniversidadContext _context;

        public EstudiantesModel(UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; }

        [BindProperty(SupportsGet = true)]
        public int NivelSeleccionado { get; set; } = 1;

        public List<SelectListItem> NivelesDisponibles { get; set; }

        public List<Asignatura> MateriasDelNivel { get; set; }

        public void OnGet()
        {
            CargarNiveles();
            CargarMaterias();
        }

        public void CargarNiveles()
        {
            NivelesDisponibles = Enumerable.Range(1, 10)
                .Select(n => new SelectListItem
                {
                    Value = n.ToString(),
                    Text = $"Nivel {n}",
                    Selected = (n == NivelSeleccionado)
                }).ToList();
        }

        public void CargarMaterias()
        {
            MateriasDelNivel = _context.Asignaturas
                .Where(a => a.Nivel == NivelSeleccionado)
                .ToList();
        }

        public IActionResult OnPost()
        {
            CargarNiveles();
            CargarMaterias();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Guardar estudiante
            _context.Estudiantes.Add(Estudiante);
            _context.SaveChanges();

            // Asignar materias
            foreach (var idAsignatura in Estudiante.MateriasSeleccionadas)
            {
                _context.Add(new Matricula
                {
                    EstudianteId = Estudiante.Id,
                    AsignaturaId = idAsignatura
                });
            }

            _context.SaveChanges();
            return RedirectToPage("/Secretaria/Index");
        }
    }
}