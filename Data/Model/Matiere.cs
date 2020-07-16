using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet.Data.Model
{
    public class Matiere
    {
        [Key]
        public int IdM { get; set; }
        public string Nom { get; set; }
        public string IdProf { get; set; }
        public int IdC { get; set; }
        public int IdF { get; set; }

        [ForeignKey("IdProf")]
        public Professeur Professeur { get; set; }

        [ForeignKey("IdC")]
        public Classe Classe { get; set; }

         [ForeignKey("IdF")]    
        public Filiere Filiere { get; set; }

    }
}