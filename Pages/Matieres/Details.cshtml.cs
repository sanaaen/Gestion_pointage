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

namespace projet.Pages.Matieres
{
    [Authorize(Roles="Admin")]
    public class DetailsModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public DetailsModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
