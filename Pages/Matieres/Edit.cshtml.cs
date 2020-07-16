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

namespace projet.Pages.Matieres
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
           ViewData["IdC"] = new SelectList(_context.Classes, "IdC", "IdC");
           ViewData["IdF"] = new SelectList(_context.Filieres, "IdF", "IdF");
           ViewData["IdProf"] = new SelectList(_context.Professeurs, "Id", "Id");
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

            _context.Attach(Matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(Matiere.IdM))
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

        private bool MatiereExists(int id)
        {
            return _context.Matieres.Any(e => e.IdM == id);
        }
    }
}
