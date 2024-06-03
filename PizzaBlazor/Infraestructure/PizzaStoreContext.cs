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
        public DbSet<PizzaTopping> PizzaToppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring a many-to-many special -> topping relationship that is friendly for serialization
            modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
            modelBuilder.Entity<PizzaTopping>()
                                .HasOne(pst => pst.Pizza)
                                .WithMany(p => p.Toppings)
                                .HasForeignKey(pst => pst.PizzaId);

            // Configurar la relación entre Topping y PizzaTopping
            modelBuilder.Entity<PizzaTopping>()
                                .HasOne(pst => pst.Topping)
                                .WithMany() 
                                .HasForeignKey(pst => pst.ToppingId);
        }
    }
}
