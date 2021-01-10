using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cosa_Cristina_Proiect.Data;


namespace Cosa_Cristina_Proiect.Models
{
    public class OferteReincarcarePageModel : PageModel
    {
        
        public List<OfertaAsignata> ListaOfertaAsignata;
        public void PopulareListaOfertaAsignata(Cosa_Cristina_ProiectContext context,
        Reincarcare reincarcare)
        {
            var toateOfertele = context.Oferta;
            var oferteReincarcare = new HashSet<int>(
            reincarcare.OferteReincarcare.Select(c => c.ReincarcareID));
            ListaOfertaAsignata = new List<OfertaAsignata>();
            foreach (var of in toateOfertele)
            {
                ListaOfertaAsignata.Add(new OfertaAsignata
                {
                    OfertaID = of.ID,
                    Nume = of.NumeOferta,
                    Asignata = oferteReincarcare.Contains(of.ID)
                });
            }
        }
        public void ModificareOferteReincarcare(Cosa_Cristina_ProiectContext context,
        string[] oferteSelectate, Reincarcare modificareReincarcare)
        {
            if (oferteSelectate == null)
            {
                modificareReincarcare.OferteReincarcare = new List<OfertaReincarcare>();
                return;
            }
            var oferteSelectateHS = new HashSet<string>(oferteSelectate);
            var oferteReincarcare = new HashSet<int>
            (modificareReincarcare.OferteReincarcare.Select(c => c.Oferta.ID));
            foreach (var of in context.Oferta)
            {
                if (oferteSelectateHS.Contains(of.ID.ToString()))
                {
                    if (!oferteReincarcare.Contains(of.ID))
                    {
                        modificareReincarcare.OferteReincarcare.Add(
                        new OfertaReincarcare
                        {
                            ReincarcareID = modificareReincarcare.ID,
                            OfertaID = of.ID
                        });
                    }
                }
                else
                {
                    if (oferteReincarcare.Contains(of.ID))
                    {
                        OfertaReincarcare courseToRemove
                            = modificareReincarcare
                                .OferteReincarcare
                                .SingleOrDefault(i => i.OfertaID == of.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    
    }
}
