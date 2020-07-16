using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projet.Data.Model;

namespace projet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

         public DbSet<Etudiant> Etudiants { get; set; }
         public DbSet<Seance> Seances { get; set; }
         public DbSet<Matiere> Matieres { get; set; }
         public DbSet<Professeur> Professeurs { get; set; }
         public DbSet<Classe> Classes { get; set; }
         public DbSet<Filiere> Filieres { get; set; }
         public DbSet<Presence> Presences { get; set; }
        

      

    }
}
