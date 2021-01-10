using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cosa_Cristina_Proiect.Data;
using Cosa_Cristina_Proiect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cosa_Cristina_Proiect.Pages.Reincarcari
{
    public class IndexModel : PageModel
    {
        private readonly Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext _context;

        public IndexModel(Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext context)
        {
            _context = context;
        }

        public IList<Reincarcare> Reincarcare { get;set; }
        [BindProperty(SupportsGet = true)]
        public ReincarcareData ReincarcareD { get; set; }
        public int ReincarcareID { get; set; }
        public int OfertaID { get; set; }
        //
       
        public async Task OnGetAsync(int? id, int? OfertaID)
        {
            ReincarcareD = new ReincarcareData();

            ReincarcareD.Reincarcari = await _context.Reincarcare
            .Include(b => b.Client)
            .Include(b => b.OferteReincarcare)
            .ThenInclude(b => b.Oferta)
            .AsNoTracking()
            .ToListAsync();
            if (id != null)
            {
                ReincarcareID = id.Value;
                Reincarcare reincarcare = ReincarcareD.Reincarcari
                .Where(i => i.ID == id.Value).Single();
                ReincarcareD.Oferte = reincarcare.OferteReincarcare.Select(s => s.Oferta);
            }

      
        }
        

    }
}
