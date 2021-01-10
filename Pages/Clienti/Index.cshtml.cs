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

namespace Cosa_Cristina_Proiect.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext _context;

        public IndexModel(Cosa_Cristina_Proiect.Data.Cosa_Cristina_ProiectContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Orase { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NumeClientt { get; set; }
       
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Client
                                            orderby m.Oras
                                            select m.Oras;
            var movies = from m in _context.Client
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.NumeClient.Contains(SearchString));
            }
            if(!string.IsNullOrEmpty(NumeClientt))
    {
                movies = movies.Where(x => x.Oras == NumeClientt);
            }
            Orase = new SelectList(await genreQuery.Distinct().ToListAsync());
            Client = await movies
                .OrderBy(b => b.NumeClient)
                .ToListAsync();
            //Client = await _context.Client.ToListAsync();
            
        }
    }
}
