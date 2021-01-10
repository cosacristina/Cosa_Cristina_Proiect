using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cosa_Cristina_Proiect.Data;
using Cosa_Cristina_Proiect.Models;

namespace Cosa_Cristina_Proiect.Pages.Oferte
{
    public class EditModel : PageModel
    {
        private readonly Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext _context;

        public EditModel(Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Oferta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaExists(Oferta.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OfertaExists(int id)
        {
            return _context.Oferta.Any(e => e.ID == id);
        }
    }
}
