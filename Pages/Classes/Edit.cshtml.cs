using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages.Classes
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
        public Classe Classe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classe = await _context.Classes
                .Include(c => c.filiere).FirstOrDefaultAsync(m => m.IdC == id);

            if (Classe == null)
            {
                return NotFound();
            }
           ViewData["IdF"] = new SelectList(_context.Filieres, "IdF", "IdF");
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

            _context.Attach(Classe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasseExists(Classe.IdC))
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

        private bool ClasseExists(int id)
        {
            return _context.Classes.Any(e => e.IdC == id);
        }
    }
}
