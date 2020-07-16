using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages.Presences
{
   
    public class IndexModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;
        public IndexModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Presence> Presence { get;set; }
    public string nommatiere;
        public async Task OnGetAsync(int? Id)
        {
            if (Id==null)
            {
                ViewData["List"]=new SelectList(_context.Matieres.ToList(),"IdM","Nom");
                Presence = await _context.Presences.Include(p=>p.Etudiant)
                                               .Include(p=>p.Seance)
                                               .ToListAsync();
                nommatiere="Tous les matières";

            }else{
                ViewData["List"]=new SelectList(_context.Matieres.ToList(),"IdM","Nom");
                Presence = await _context.Presences.Include(p=>p.Etudiant)
                                                   .Include(p=>p.Seance)
                                                   .Where(p=>p.Seance.IdM==Id)
                                                   .ToListAsync();
                
                nommatiere=_context.Matieres.Find(Id).Nom;
                                                
            }
            
        }
    }
}
