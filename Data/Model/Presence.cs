using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet.Data.Model
{
    public class Presence
    {
        [Key]
        public int IdPres { get; set; }
        public bool Present { get; set; }

        public int IdE { get; set; }
        public int IdS { get; set; }

         [ForeignKey("IdE")]
         public Etudiant Etudiant { get; set; }

        [ForeignKey("IdS")]
        public Seance Seance { get; set; }


        
    }
}