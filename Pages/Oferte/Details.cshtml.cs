using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cosa_Cristina_Proiect.Data;
using Cosa_Cristina_Proiect.Models;

namespace Cosa_Cristina_Proiect.Pages.Oferte
{
    public class DetailsModel : PageModel
    {
        private readonly Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext _context;

        public DetailsModel(Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext context)
        {
            _context = context;
        }

        public Oferta Oferta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oferta = await _context.Oferta.FirstOrDefaultAsync(m => m.ID == id);

            if (Oferta == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
