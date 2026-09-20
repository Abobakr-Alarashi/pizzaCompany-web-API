using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PizzaToppingRepository : IPizzaToppingRepository
    {
        private readonly AppDbContext _context;

        public PizzaToppingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(PizzaTopping pizzaTopping)
        {
            _context.PizzaToppings.Add(pizzaTopping);
            _context.SaveChanges();
        }

        public void Delete(int pizzaId,int toppingId)
        {
            var pizzaTopping = _context.PizzaToppings.Find(pizzaId,toppingId);
            if (pizzaTopping != null)
            {
                _context.PizzaToppings.Remove(pizzaTopping);
                _context.SaveChanges();
            }
        }

        public List<PizzaTopping> GetAll()
        {
            return _context.PizzaToppings.ToList();
        }

        public PizzaTopping GetById(int pizzaId,int toppingId)
        {
            return _context.PizzaToppings.Find(pizzaId,toppingId);
        }

        public List<PizzaTopping> GetByPizzaId(int pizzaId)
        {
            return _context.PizzaToppings.Where(x => x.PizzaId  == pizzaId).ToList();
        }

        public List<PizzaTopping> GetByToppingId(int toppingId)
        {
            return _context.PizzaToppings.Where(x => x.ToppingId   == toppingId).ToList();
        }

        public void Update(PizzaTopping pizzaTopping)
        {
            _context.PizzaToppings.Update(pizzaTopping);
            _context.SaveChanges();
        }
    }
}
