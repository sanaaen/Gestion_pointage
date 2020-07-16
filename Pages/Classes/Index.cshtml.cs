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
    public class IndexModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public IndexModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Classe> Classe { get;set; }

        public async Task OnGetAsync()
        {
            Classe = await _context.Classes
                .Include(c => c.filiere).ToListAsync();
              
        }
    }
}
