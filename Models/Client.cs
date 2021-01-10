using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cosa_Cristina_Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }
     
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele clientului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string NumeClient { get; set; }
        public string Oras { get; set; }
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid Email Format"), Required]
        public string Email { get; set; }
        [Required, StringLength(10, MinimumLength = 10)]
        public string NumarTelefon { get; set; }
        public ICollection<Reincarcare> Reincarcari { get; set; }
    }
}
