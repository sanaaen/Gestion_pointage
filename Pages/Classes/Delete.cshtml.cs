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

namespace projet.Pages.Classes
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classe = await _context.Classes.FindAsync(id);

            if (Classe != null)
            {
                _context.Classes.Remove(Classe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
