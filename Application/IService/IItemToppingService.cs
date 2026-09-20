using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;


namespace Application.IService
{
    public interface IItemToppingService
    {
        void CreateItemTopping(ItemToppingDto ItemToppingDto);

        ItemToppingDto GetItemToppingById(int orderId,int toppingId);

        IEnumerable<ItemToppingDto> GetItemToppings();

        void UpdateItemTopping(ItemToppingDto itemToppingDto);

        void DeleteItemTopping(int orderId,int ToppingId);

        IEnumerable<ItemToppingDto> GetItemToppingsByOrderId(int orderId);
        IEnumerable<ItemToppingDto> GetItemToppingsByToppingId(int toppingId);

    }
}
