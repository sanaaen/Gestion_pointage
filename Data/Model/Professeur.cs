using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace projet.Data.Model
{
    public class Professeur:IdentityUser
    {
        [Required]
        public string Name {get; set;}

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }
        [Required]
        public char Status { get; set; }
    }
}