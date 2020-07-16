using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet.Data.Model
{
    public class Classe
    {
        [Key]
        public int IdC { get; set; }
        public int Groupe {get; set;}

        public int IdF { get; set; }

        [ForeignKey("IdF")]
        public Filiere filiere { get; set; }

    }
}