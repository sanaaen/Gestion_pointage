
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet.Data.Model
{
    public class Etudiant
    {
        [Key]
         public int IdE  { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateN { get; set; }
        public string Email { get; set; }
        public int IdF {get;set; }
        public int IdC{ get; set; }
       
        [ForeignKey("IdF")]
        public Filiere Filiere { get; set; }

        [ForeignKey("IdC")]
        public Classe Classe { get; set; }

    }
}