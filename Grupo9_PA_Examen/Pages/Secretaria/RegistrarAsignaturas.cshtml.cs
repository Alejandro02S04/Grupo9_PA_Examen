using Grupo9_PA_Examen.Data;
using Grupo9_PA_Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grupo9_PA_Examen.Pages.Secretaria
{
    public class RegistrarAsignaturasModel : PageModel
    {
        private readonly UniversidadContext _context;

        public RegistrarAsignaturasModel(UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asignatura Asignatura { get; set; }

        public void OnGet()
        {
            // Asegurar valor por defecto si aún no se establece
            if (Asignatura == null)
            {
                Asignatura = new Asignatura
                {
                    Carrera = "Tecnologías de la Información"
                };
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Asegurar valor por defecto en caso de que el input no lo devuelva
            if (string.IsNullOrEmpty(Asignatura.Carrera))
            {
                Asignatura.Carrera = "Tecnologías de la Información";
            }

            _context.Asignaturas.Add(Asignatura);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}