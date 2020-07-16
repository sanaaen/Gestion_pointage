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

namespace projet.Pages.Etudiants
{
     [Authorize(Roles="Admin")]
    public class IndexModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public IndexModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get;set; }

        public async Task OnGetAsync()
        {
            Etudiant = await _context.Etudiants
                .Include(e => e.Classe)
                .Include(e => e.Filiere).ToListAsync();
        }
    }
}
