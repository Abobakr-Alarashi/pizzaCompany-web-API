using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;


namespace Application.IService
{
    public interface IPizzaToppingService
    {
        void CreatePizzaTopping(PizzaToppingDto pizzaTopping);

        PizzaToppingDto GetPizzaToppingById(int pizzaId,int toppingId);

        IEnumerable<PizzaToppingDto> GetPizzaToppings();

        void UpdatePizzaTopping(PizzaToppingDto pizzaToppingDto);

        void DeletePizzaTopping(int pizzaId,int toppingId);


        IEnumerable<PizzaToppingDto> GetPizzaToppingsByPizzaId(int pizzaId);								
        IEnumerable<PizzaToppingDto> GetPizzaToppingsByToppingId(int toppingId);								
    }
}
