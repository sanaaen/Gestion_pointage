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
    public class IndexModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public IndexModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Filiere> Filiere { get;set; }

        public async Task OnGetAsync()
        {
            Filiere = await _context.Filieres.ToListAsync();
        }
    }
}
