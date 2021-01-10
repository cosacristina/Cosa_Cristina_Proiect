using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosa_Cristina_Proiect.Models
{
    public class ReincarcareData
    {
        public IEnumerable<Reincarcare> Reincarcari { get; set; }
        public IEnumerable<Oferta> Oferte { get; set; }
        public IEnumerable<OfertaReincarcare> OferteReincarcare { get; set; }
    }
}
