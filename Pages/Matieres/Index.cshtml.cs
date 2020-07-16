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
    public class IndexModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public IndexModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Matiere> Matiere { get;set; }

        public async Task OnGetAsync()
        {
            Matiere = await _context.Matieres
                .Include(m => m.Classe)
                .Include(m => m.Filiere)
                .Include(m => m.Professeur).ToListAsync();
        }
    }
}
