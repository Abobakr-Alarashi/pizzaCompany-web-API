using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IItemToppingRepository
    {
        void Add(ItemTopping itemTopping); // what inside the () it the values you should send 
        // what is before the name of the method it is the return values

        void Update(ItemTopping itemTopping);

        void Delete(int orderId,int toppingId);

        ItemTopping GetById(int orderId,int toppingId);

        List<ItemTopping> GetByOrderId(int orderId);
        List<ItemTopping> GetByToppingId(int toppingId);
        List<ItemTopping> GetAll();

    }
}
