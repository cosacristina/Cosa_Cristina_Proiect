using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosa_Cristina_Proiect.Models
{
    public class OfertaReincarcare
    {
        public int ID { get; set; }
        public int ReincarcareID { get; set; }
        public Reincarcare Reincarcare { get; set; }
        public int OfertaID { get; set; }
        public Oferta Oferta { get; set; }
    }
}
