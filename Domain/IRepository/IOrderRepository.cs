using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IOrderRepository
    {
        void Add(Order order); // what inside the () it the values you should send 
        // what is before the name of the method it is the return values

        void Update(Order order);

        void Delete(int id);

        Order GetById(int id);

        List<Order> GetAll();

    }
}
