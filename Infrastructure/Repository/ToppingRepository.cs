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
    public class ToppingRepository : IToppingRepository
    {
        private readonly AppDbContext _context;

        public ToppingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Topping topping)
        {
            _context.Toppings.Add(topping);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var topping = _context.Toppings.Find(id);
            if (topping != null)
            {
                _context.Toppings.Remove(topping);
                _context.SaveChanges();
            }
        }

        public List<Topping> GetAll()
        {
            return _context.Toppings.ToList();
        }

        public Topping GetById(int id)
        {
            return _context.Toppings.Find(id);
        }

        public void Update(Topping topping)
        {
            _context.Toppings.Update(topping);
            _context.SaveChanges();
        }
    }
}
