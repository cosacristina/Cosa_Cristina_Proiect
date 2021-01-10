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

namespace Cosa_Cristina_Proiect.Pages.Reincarcari
{
    public class EditModel : OferteReincarcarePageModel
    {
        private readonly Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext _context;

        public EditModel(Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reincarcare Reincarcare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reincarcare = await _context.Reincarcare
                .Include(b => b.Client)
                .Include(b => b.OferteReincarcare).ThenInclude(b => b.Oferta)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Reincarcare == null)
            {
                return NotFound();
            }
            PopulareListaOfertaAsignata(_context, Reincarcare);

            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "NumeClient");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] oferteSelectate)
        {
            if (id == null)
            {
                return NotFound();
            }
            var modificareOferta = await _context.Reincarcare
            .Include(i => i.Client)
            .Include(i => i.OferteReincarcare)
            .ThenInclude(i => i.Oferta)
            .FirstOrDefaultAsync(s => s.ID == id);
 
            if (modificareOferta == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Reincarcare>(
            modificareOferta,
            "Reincarcare",
            i => i.Numar, i => i.Data, i => i.ClientID))
            {
                ModificareOferteReincarcare(_context, oferteSelectate, modificareOferta);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            ModificareOferteReincarcare(_context, oferteSelectate, modificareOferta);
            PopulareListaOfertaAsignata(_context, modificareOferta);
            return Page();
        }
    }

    /*private bool ReincarcareExists(int id)
        {
            return _context.Reincarcare.Any(e => e.ID == id);
        }*/
 }
