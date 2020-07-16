using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages.Seances
{
    [Authorize(Roles="Admin")]
    public class DetailsModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public DetailsModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Seance Seance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seance = await _context.Seances
                .Include(s => s.Matiere).FirstOrDefaultAsync(m => m.IdS == id);

            if (Seance == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
