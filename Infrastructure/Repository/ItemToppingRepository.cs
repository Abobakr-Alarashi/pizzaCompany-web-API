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
    public class ItemToppingRepository : IItemToppingRepository
    {
        private readonly AppDbContext _context;

        public ItemToppingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ItemTopping itemTopping)
        {
            _context.ItemToppings.Add(itemTopping);
            _context.SaveChanges();
        }

        public void Delete(int orderId, int toppingId)
        {
            var itemTopping = _context.ItemToppings.Find(orderId,toppingId);
            if (itemTopping != null)
            {
                _context.ItemToppings.Remove(itemTopping);
                _context.SaveChanges();
            }
        }

        public List<ItemTopping> GetAll()
        {
            return _context.ItemToppings.ToList();
        }

        public void Update(ItemTopping itemTopping)
        {
            _context.ItemToppings.Update(itemTopping);
            _context.SaveChanges();
        }

        public ItemTopping GetById(int orderId, int toppingId)
        {
            return _context.ItemToppings.Find(orderId,toppingId);
        }

        public List<ItemTopping> GetByOrderId(int orderId)
        {
            return _context.ItemToppings.Where(x => x.OrderItemId == orderId).ToList();
        }

        public List<ItemTopping> GetByToppingId(int toppingId)
        {
            return _context.ItemToppings.Where(x => x.ToppingId == toppingId).ToList();
        }
    }
}
