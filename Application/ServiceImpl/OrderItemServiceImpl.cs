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
    public class OrderItemServiceImpl : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository; // dependancy injection

        public OrderItemServiceImpl(IOrderItemRepository catergoryRepository, IMapper mapper)
        {
            _orderItemRepository = catergoryRepository;
            _mapper = mapper;
        }
        public void CreateOrderItem(OrderItemDto orderItemDto)
        {
            if (orderItemDto == null) throw new ArgumentNullException(nameof(orderItemDto));

            var orderItemEntity = _mapper.Map<OrderItem>(orderItemDto);

            orderItemEntity.Id = 0;

            _orderItemRepository.Add(orderItemEntity);
        }


        public OrderItemDto GetOrderItemById(int id)
        {
            var orderItemEntity = _orderItemRepository.GetById(id);

            if (orderItemEntity == null) return null;

            return _mapper.Map<OrderItemDto>(orderItemEntity);
        }

        public void UpdateOrderItem(OrderItemDto orderItemDto)
        {
            if (orderItemDto == null) throw new ArgumentNullException(nameof(orderItemDto));

            var existingOrderItem = _orderItemRepository.GetById(orderItemDto.Id);
            if (existingOrderItem == null) throw new ArgumentNullException(nameof(orderItemDto));

            _mapper.Map(orderItemDto, existingOrderItem);

            _orderItemRepository.Update(existingOrderItem);
        }

        public IEnumerable<OrderItemDto> GetOrderItems()
        {
            var orderItemEntities = _orderItemRepository.GetAll();

            return _mapper.Map<IList<OrderItemDto>>(orderItemEntities);
        }

        public void DeleteOrderItem(int id)
        {
            var orderItem = _orderItemRepository.GetById(id);
            if (orderItem == null) throw new ArgumentNullException(nameof(orderItem));

            _orderItemRepository.Delete(id);
        }

    }
}
