using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IPizzaRepository
    {
        void Add(Pizza pizza); // what inside the () it the values you should send 
        // what is before the name of the method it is the return values

        void Update(Pizza pizza);

        void Delete(int id);

        Pizza GetById(int id);

        List<Pizza> GetAll();

    }
}
