using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet.Data.Model
{
    public class Seance
    {
        [Key]
        public int IdS { get; set; }


        
        public string H_debut { get; set; }
        public string H_fin { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int IdM { get; set; }
        
        [ForeignKey("IdM")]
        public Matiere Matiere { get; set; }

    }
}