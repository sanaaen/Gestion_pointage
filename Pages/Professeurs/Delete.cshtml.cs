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

namespace projet.Pages.Professeurs
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
        public Professeur Professeur { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Professeur = await _context.Professeurs.FirstOrDefaultAsync(m => m.Id == id);

            if (Professeur == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Professeur = await _context.Professeurs.FindAsync(id);

            if (Professeur != null)
            {
                _context.Professeurs.Remove(Professeur);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
