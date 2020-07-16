using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages.Matieres
{
    [Authorize(Roles="Admin")]
    public class DeleteModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public DeleteModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Matiere Matiere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Matiere = await _context.Matieres
                .Include(m => m.Classe)
                .Include(m => m.Filiere)
                .Include(m => m.Professeur).FirstOrDefaultAsync(m => m.IdM == id);

            if (Matiere == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Matiere = await _context.Matieres.FindAsync(id);

            if (Matiere != null)
            {
                _context.Matieres.Remove(Matiere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
