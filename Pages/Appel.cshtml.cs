using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projet.Data;
using projet.Data.Model;

namespace projet.Pages
{
    public class AppelModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public AppelModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            
             ViewData["matOn"]=0;
            
          
        

        }
        public IActionResult OnPostEtudiantFinder(){
            int id ;
          id= int.Parse(Request.Form["id"]);
         
            if(FindMatieres (id))
             {
            ViewData["matOn"]=1;
            ViewData["et"]=id;
            }
            else
            ViewData["matOn"]=3;
            return Page();
        }

        public IActionResult OnPostM(){

        
         int IdE= int.Parse(Request.Form["IdE"]);

         
         int IdM= int.Parse(Request.Form["IdM"]);
        
       
            if(setPresence(IdM,IdE))
            {
            ViewData["matOn"]=2;

            }
            else
            ViewData["matOn"]=3;
            return Page();
        }
        public bool FindMatieres (int id){


            var etudiant =_context.Etudiants.Find(id);


            if(etudiant==null)
            return false;

            var classes = _context.Classes.Where(p=>   p.IdC==etudiant.IdC ).FirstOrDefault();

            if(classes==null)
            return false;

            var matieres =  _context.Matieres.Where(p=>   p.IdC==classes.IdC ).ToList();

             ViewData["List"]=new SelectList(matieres,"IdM","Nom");

            return true;
        }
        public bool setPresence (int IdM,int IdE){
            int IdS=-1;
            var seances=_context.Seances;
            foreach (var item in seances)
            {
                int dh=int.Parse(item.H_debut.Split(':')[0]);
                int dm=int.Parse(item.H_debut.Split(':')[1]);
                int fh=int.Parse(item.H_fin.Split(':')[0]);
                int fm=int.Parse(item.H_fin.Split(':')[1]);

                if(item.IdM==IdM){
                    if(item.date.Date==DateTime.Now.Date){
                        if (dh*100+dm<=DateTime.Now.Hour*100+DateTime.Now.Minute)
                        {
                            if (fh*100+fm>=DateTime.Now.Hour*100+DateTime.Now.Minute)
                            {
                                 IdS=item.IdS;
                            }
                        }
                    }
                }




               

                
            }
            if(IdS==-1)
            {
              
               return false; 
            }
           


            var presence =_context.Presences.Where(p=>  p.IdE==IdE  )
                                            .Where(p=>  p.IdS==IdS  ).First();
                                            presence.Present=true;


            _context.SaveChanges();

            return true;
        }
    }   
}
