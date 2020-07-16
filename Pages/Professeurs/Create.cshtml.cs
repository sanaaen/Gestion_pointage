using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages.Professeurs
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
            return Page();
        }

        [BindProperty]
        public Professeur Professeur { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Professeurs.Add(Professeur);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}