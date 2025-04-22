using Grupo9_PA_Examen.Data;
using Grupo9_PA_Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Grupo9_PA_Examen.Pages.Docente
{
    public class CalificacionesModel : PageModel
    {
        private readonly UniversidadContext _context;

        public CalificacionesModel(UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int NivelSeleccionado { get; set; }

        [BindProperty]
        public int AsignaturaId { get; set; }

        [BindProperty]
        public int EstudianteId { get; set; }

        [BindProperty]
        public double Nota { get; set; }

        public List<SelectListItem> Niveles { get; set; }
        public List<SelectListItem> Asignaturas { get; set; }
        public List<SelectListItem> Estudiantes { get; set; }

        public void OnGet()
        {
            CargarNiveles();
            Asignaturas = new List<SelectListItem>();
            Estudiantes = new List<SelectListItem>();
        }

        public IActionResult OnPost()
        {
            CargarNiveles();

            // Cargar asignaturas del nivel seleccionado
            Asignaturas = _context.Asignaturas
                .Where(a => a.Nivel == NivelSeleccionado)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Nombre
                })
                .ToList();

            // Cargar estudiantes solo si hay asignatura seleccionada
            if (AsignaturaId > 0)
            {
                Estudiantes = _context.Matriculas
                    .Where(m => m.AsignaturaId == AsignaturaId)
                    .Select(m => new SelectListItem
                    {
                        Value = m.Estudiante.Id.ToString(),
                        Text = m.Estudiante.Nombres + " " + m.Estudiante.Apellidos
                    })
                    .Distinct()
                    .ToList();
            }

            // Si todo está lleno, guardar la nota
            if (NivelSeleccionado > 0 && AsignaturaId > 0 && EstudianteId > 0 && Nota >= 0)
            {
                var calificacion = new Calificacion
                {
                    EstudianteId = EstudianteId,
                    AsignaturaId = AsignaturaId,
                    Nota = Nota
                };

                _context.Calificaciones.Add(calificacion);
                _context.SaveChanges();

                return RedirectToPage("/Docente/Index");
            }

            return Page();
        }

        private void CargarNiveles()
        {
            Niveles = Enumerable.Range(1, 10)
                .Select(i => new SelectListItem
                {
                    Value = i.ToString(),
                    Text = $"Nivel {i}"
                }).ToList();
        }
    }
}