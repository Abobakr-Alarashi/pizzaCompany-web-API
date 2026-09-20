using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer); // what inside the () it the values you should send 
        // what is before the name of the method it is the return values

        void Update(Customer customer);

        void Delete(int id);

        Customer GetById(int id);

        List<Customer> GetAll();

    }
}
