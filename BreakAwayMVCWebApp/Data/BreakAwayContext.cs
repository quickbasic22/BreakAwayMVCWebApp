using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BreakAwayMVCWebApp.Models;

namespace BreakAwayMVCWebApp.Data
{
    public class BreakAwayContext : DbContext
    {
        public BreakAwayContext (DbContextOptions<BreakAwayContext> options)
            : base(options)
        {
        }

        public DbSet<BreakAwayMVCWebApp.Models.Destination> Destination { get; set; } = default!;

        public DbSet<BreakAwayMVCWebApp.Models.Lodging>? Lodging { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>().HasData(new Destination
            {
                DestinationId = 1,
                DestinationName = "Indonesia",
                Country = "USA",
                Description = "Eco Tourism at it's best in the exquite Bali",
                Photo = new byte[] { 0 }
            });
        }
    }
}
