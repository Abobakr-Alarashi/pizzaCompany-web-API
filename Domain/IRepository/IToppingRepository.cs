using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IToppingRepository
    {
        void Add(Topping topping); // what inside the () it the values you should send 
        // what is before the name of the method it is the return values

        void Update(Topping topping);

        void Delete(int id);

        Topping GetById(int id);

         List<Topping> GetAll();

    }
}
