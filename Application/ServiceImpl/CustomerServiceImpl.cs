using Application.DTOs;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceImpl
{
    public class CustomerServiceImpl : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository; // dependancy injection

        public CustomerServiceImpl(ICustomerRepository catergoryRepository, IMapper mapper)
        {
            _customerRepository = catergoryRepository;
            _mapper = mapper;
        }
        public void CreateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null) throw new ArgumentNullException(nameof(customerDto));

            var customerEntity = _mapper.Map<Customer>(customerDto);

            customerEntity.Id = 0;

            _customerRepository.Add(customerEntity);
        }


        public CustomerDto GetCustomerById(int id)
        {
            var customerEntity = _customerRepository.GetById(id);

            if (customerEntity == null) return null;

            return _mapper.Map<CustomerDto>(customerEntity);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null) throw new ArgumentNullException(nameof(customerDto));

            var existingCustomer = _customerRepository.GetById(customerDto.Id);
            if (existingCustomer == null) throw new ArgumentNullException(nameof(customerDto));

            _mapper.Map(customerDto, existingCustomer);

            _customerRepository.Update(existingCustomer);
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customerEntities = _customerRepository.GetAll();

            return _mapper.Map<IList<CustomerDto>>(customerEntities);
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            _customerRepository.Delete(id);
        }
    }

}
