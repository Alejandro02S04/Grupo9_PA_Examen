using Grupo9_PA_Examen.Data;
using Grupo9_PA_Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


    public class RegistrarDocenteModel : PageModel
    {
        private readonly UniversidadContext _context;

        public RegistrarDocenteModel(UniversidadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Docente Docente { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Docentes.Add(Docente);
            _context.SaveChanges();

            return RedirectToPage("./DocentesList");
        }
    }
