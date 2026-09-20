using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;


namespace Application.IService
{
    public interface IOrderItemService
    {
        void CreateOrderItem(OrderItemDto orderItemDto);

        OrderItemDto GetOrderItemById(int id);

        IEnumerable<OrderItemDto> GetOrderItems();

        void UpdateOrderItem(OrderItemDto orderItemDto);

        void DeleteOrderItem(int id);
    }
}
