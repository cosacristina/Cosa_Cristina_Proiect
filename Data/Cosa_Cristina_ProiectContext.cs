using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cosa_Cristina_Proiect.Models;

namespace Cosa_Cristina_Proiect.Data
{
    public class Cosa_Cristina_ProiectContext : DbContext
    {
        public Cosa_Cristina_ProiectContext (DbContextOptions<Cosa_Cristina_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Cosa_Cristina_Proiect.Models.Reincarcare> Reincarcare { get; set; }

        public DbSet<Cosa_Cristina_Proiect.Models.Client> Client { get; set; }

        public DbSet<Cosa_Cristina_Proiect.Models.Oferta> Oferta { get; set; }
    }
}
