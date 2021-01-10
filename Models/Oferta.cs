using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cosa_Cristina_Proiect.Models
{
    public class Oferta
    {
        public int ID { get; set; }
        public string NumeOferta { get; set; }
        
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(6, 2)")]
        //[DisplayFormat(DataFormatString = "{C3}", ApplyFormatInEditMode = true)]
        public decimal EuroCredit { get; set; }
        //[DataType(DataType.Currency.ToString("C3", EuroCredit))]
        public ICollection<OfertaReincarcare> OferteReincarcare { get; set; }
    }
}
