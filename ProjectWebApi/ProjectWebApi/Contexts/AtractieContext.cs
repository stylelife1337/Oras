using Microsoft.EntityFrameworkCore;
using ProjectWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Contexts
{
    public class AtractieContext : DbContext
    {
        public AtractieContext(DbContextOptions<AtractieContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Atractie> Attractions { get; set; }

        public DbSet<Cazare> Bookings { get; set; }

        public DbSet<Tara> Countries { get; set; }

        public DbSet<Oras> Cities { get; set; }


            

    }
}
