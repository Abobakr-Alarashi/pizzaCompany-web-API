using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ItemTopping> ItemToppings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemTopping>().HasKey(itemTopping => new { itemTopping.OrderItemId, itemTopping.ToppingId });
            modelBuilder.Entity<PizzaTopping>().HasKey(pizzaTopping => new { pizzaTopping.PizzaId, pizzaTopping.ToppingId });


            modelBuilder.Entity<Category>().HasIndex(category => category.Name).IsUnique();
            modelBuilder.Entity<Category>().Property(category => category.Name).IsRequired();
            
            modelBuilder.Entity<Customer>().Property(customer => customer.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(customer => customer.LastName).IsRequired();
            modelBuilder.Entity<Customer>().Property(customer => customer.Email).IsRequired();
            modelBuilder.Entity<Customer>().HasIndex(customer => customer.Email).IsUnique();
            modelBuilder.Entity<Customer>().Property(customer => customer.PhoneNumber).IsRequired();

            modelBuilder.Entity<Pizza>().HasIndex(pizza => pizza.Name).IsUnique();
            modelBuilder.Entity<Pizza>().Property(pizza => pizza.Name).IsRequired();
            modelBuilder.Entity<Pizza>().Property(pizza => pizza.Price).HasPrecision(18, 2);
            
            
            modelBuilder.Entity<Topping>().HasIndex(topping => topping.Name).IsUnique();
            modelBuilder.Entity<Topping>().Property(topping => topping.Name).IsRequired();
            modelBuilder.Entity<Topping>().Property(topping => topping.Price).HasPrecision(18, 2);

        }
    }
}
