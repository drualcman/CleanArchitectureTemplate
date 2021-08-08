using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Infraestructure.EF
{
    public class ZionDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ZionDbContext(DbContextOptions<ZionDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //invoice OnModelCreating from the base class
            base.OnModelCreating(modelBuilder);
        }
    }
}
