using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NinjasApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjasApi.DAL
{
    public class NinjaContext :DbContext
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public NinjaContext(DbContextOptions<NinjaContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
