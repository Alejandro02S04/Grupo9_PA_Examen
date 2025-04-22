using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grupo9_PA_Examen.Pages
{
    public class LoginModel : PageModel
    {
        public IActionResult OnPostAlumno()
        {
            // Redirige al alumno
            return RedirectToPage("/Alumno/Index");
        }

        public IActionResult OnPostDocente()
        {
            // Redirige al docente
            return RedirectToPage("/Maestro/Index");
        }

        public IActionResult OnPostSecretaria()
        {
            // Redirige a la secretaria
            return RedirectToPage("/Secretaria/Index");
        }

        public IActionResult OnPostAdmin()
        {
            // Redirige al administrador
            return RedirectToPage("/Administrador/Index");
        }
    }
}