using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;



namespace Application.IService
{


    public interface ICustomerService
    {
        void CreateCustomer(CustomerDto customerDto);

        CustomerDto GetCustomerById(int id);

        IEnumerable<CustomerDto> GetCustomers();

        void UpdateCustomer(CustomerDto customerDto);

        void DeleteCustomer(int id);


    }
}
