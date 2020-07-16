using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages.Seances
{
    [Authorize(Roles="Admin")]
    public class CreateModel : PageModel
    {
        private readonly projet.Data.ApplicationDbContext _context;

        public CreateModel(projet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdM"] = new SelectList(_context.Matieres, "IdM", "IdM");
            return Page();
        }

        [BindProperty]
        public Seance Seance { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seances.Add(Seance);
            await _context.SaveChangesAsync();

            var idM=Seance.IdM;
            var idC=_context.Matieres.Where(p=>p.IdM==idM).FirstOrDefault().IdC;
            
            foreach (var item in _context.Etudiants.Where(p=>p.IdC==idC)   )
            {
                var et=new Presence(){
                    Present=false,
                    IdE=item.IdE,
                    IdS=Seance.IdS
                };
                 _context.Presences.Add(et);
            }
            _context.SaveChanges();
           


               



            return RedirectToPage("./Index");
        }
    }
}
