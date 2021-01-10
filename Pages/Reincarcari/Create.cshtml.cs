using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cosa_Cristina_Proiect.Data;
using Cosa_Cristina_Proiect.Models;

namespace Cosa_Cristina_Proiect.Pages.Reincarcari
{
    public class CreateModel : OferteReincarcarePageModel
    {
        private readonly Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext _context;

        public CreateModel(Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "NumeClient");
            var reincarcare = new Reincarcare();
            reincarcare.OferteReincarcare = new List<OfertaReincarcare>();
            PopulareListaOfertaAsignata(_context, reincarcare);

            return Page();
        }

        [BindProperty]
        public Reincarcare Reincarcare { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] oferteSelectate)
        {
            var newReincarcare = new Reincarcare();
            if (oferteSelectate != null)
            {
                newReincarcare.OferteReincarcare = new List<OfertaReincarcare>();
                foreach (var cat in oferteSelectate)
                {
                    var catToAdd = new OfertaReincarcare
                    {
                        OfertaID = int.Parse(cat)
                    };
                    newReincarcare.OferteReincarcare.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Reincarcare>(
            newReincarcare,
            "Reincarcare",
            i => i.Numar, i => i.Data, i => i.ClientID))
            {
                _context.Reincarcare.Add(newReincarcare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulareListaOfertaAsignata(_context, newReincarcare);
            return Page();
        }
    }
}
