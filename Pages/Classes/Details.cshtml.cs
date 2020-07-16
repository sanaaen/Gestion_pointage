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
    public class DetailsModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public DetailsModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
