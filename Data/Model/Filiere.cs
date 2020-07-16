using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet.Data.Model
{
    public class Filiere
    {
        [Key]
        public int IdF { get; set; }
        public string Intitulee{ get; set; }
        

    }
}