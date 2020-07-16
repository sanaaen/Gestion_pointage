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

namespace projet.Pages.Professeurs
{
    [Authorize(Roles="Admin")]
    public class DetailsModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public DetailsModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
