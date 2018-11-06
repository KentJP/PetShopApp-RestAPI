using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entity;
using System;

namespace PetShop.ConsoleApp.Infrastructure
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt)
          : base(opt)
        {

        }


        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne(p => p.previousOwner).WithMany(o => o.Pets).OnDelete(DeleteBehavior.SetNull);
        }

    }
}
