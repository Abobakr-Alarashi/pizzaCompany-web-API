using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IPizzaToppingRepository
    {
        void Add(PizzaTopping pizzaTopping); // what inside the () it the values you should send 
        // what is before the name of the method it is the return values

        void Update(PizzaTopping pizzaTopping);

        void Delete(int pizzaId,int toppingId);

        PizzaTopping GetById(int pizzaId,int toppingId);

        List<PizzaTopping> GetByPizzaId(int pizzaId);
        List<PizzaTopping> GetByToppingId(int toppingId);

        List<PizzaTopping> GetAll();

    }
}
