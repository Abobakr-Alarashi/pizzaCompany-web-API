using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;


namespace Application.IService
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto orderDto);

        OrderDto GetOrderById(int id);

        IEnumerable<OrderDto> GetOrders();

        void UpdateOrder(OrderDto orderDto);

        void DeleteOrder(int id);
    }
}
