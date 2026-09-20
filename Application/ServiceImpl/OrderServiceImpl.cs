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
    public class OrderServiceImpl : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository; // dependancy injection

        public OrderServiceImpl(IOrderRepository catergoryRepository, IMapper mapper)
        {
            _orderRepository = catergoryRepository;
            _mapper = mapper;
        }
        public void CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            var orderEntity = _mapper.Map<Order>(orderDto);

            orderEntity.Id = 0;

            _orderRepository.Add(orderEntity);
        }


        public OrderDto GetOrderById(int id)
        {
            var orderEntity = _orderRepository.GetById(id);

            if (orderEntity == null) return null;

            return _mapper.Map<OrderDto>(orderEntity);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            var existingOrder = _orderRepository.GetById(orderDto.Id);
            if (existingOrder == null) throw new ArgumentNullException(nameof(orderDto));

            _mapper.Map(orderDto, existingOrder);

            _orderRepository.Update(existingOrder);
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            var orderEntities = _orderRepository.GetAll();

            return _mapper.Map<IList<OrderDto>>(orderEntities);
        }

        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) throw new ArgumentNullException(nameof(order));

            _orderRepository.Delete(id);
        }

    }
}
