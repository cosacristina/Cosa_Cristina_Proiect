using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cosa_Cristina_Proiect.Data;
using Cosa_Cristina_Proiect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;//
namespace Cosa_Cristina_Proiect.Pages.Oferte
{
    public class IndexModel : PageModel
    {
        private readonly Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext _context;

        public IndexModel(Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext context)
        {
            _context = context;
        }

        public IList<Oferta> Oferta { get;set; }

        public int OfertaID { get; set; }

        public async Task OnGetAsync(int? OfertaID)
        {
            
            Oferta = await _context.Oferta
                .OrderBy(b => b.EuroCredit)
                .ToListAsync();
           

        }
    }
}
