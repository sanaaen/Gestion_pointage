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

namespace projet.Pages.Filieres
{
    [Authorize(Roles="Admin")]
    public class DetailsModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public DetailsModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Filiere Filiere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filiere = await _context.Filieres.FirstOrDefaultAsync(m => m.IdF == id);

            if (Filiere == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
