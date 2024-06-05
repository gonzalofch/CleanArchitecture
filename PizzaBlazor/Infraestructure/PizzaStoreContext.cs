using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaSpecial> PizzaSpecials { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        //public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                                .HasMany(e => e.Pizzas)
                                .WithOne()
                                .IsRequired();

            modelBuilder.Entity<Pizza>()
                                .HasMany(p => p.Toppings)
                                .WithMany();

            //modelBuilder.Entity<UserInfo>(usr =>
            //{
            //    usr.HasKey(u => u.UserId);
            //    usr.HasIndex(u => u.Email)
            //        .IsUnique();
            //    usr.HasIndex(u => u.UserName)
            //        .IsUnique();
            //});
        }
    }
}
