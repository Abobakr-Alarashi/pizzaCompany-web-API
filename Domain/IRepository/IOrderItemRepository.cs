using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IOrderItemRepository
    {
        void Add(OrderItem orderitem); // what inside the () it the values you should send 
        // what is before the name of the method it is the return values

        void Update(OrderItem orderitem);

        void Delete(int id);

        OrderItem GetById(int id);

        List<OrderItem> GetAll();

    }
}
