using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages.Presences
{
    [Authorize(Roles="Admin")]
    public class EditModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public EditModel(projet.Data.ApplicationDbContext context)
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
           ViewData["IdE"] = new SelectList(_context.Etudiants, "IdE", "IdE");
           ViewData["IdS"] = new SelectList(_context.Seances, "IdS", "IdS");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Presence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresenceExists(Presence.IdPres))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PresenceExists(int id)
        {
            return _context.Presences.Any(e => e.IdPres == id);
        }
    }
}
