using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cosa_Cristina_Proiect.Models
{
    public class Reincarcare
    {
        public int ID { get; set; }

        //[Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Numar Reincarcare")]
        public string Numar { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public ICollection<OfertaReincarcare> OferteReincarcare { get; set; }
    }
}
