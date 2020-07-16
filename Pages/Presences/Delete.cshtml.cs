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

namespace projet.Pages.Presences
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
        public Presence Presence { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Presence = await _context.Presences
                .Include(p => p.Etudiant)
                .Include(p => p.Seance).FirstOrDefaultAsync(m => m.IdPres == id);

            if (Presence == null)
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

            Presence = await _context.Presences.FindAsync(id);

            if (Presence != null)
            {
                _context.Presences.Remove(Presence);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
