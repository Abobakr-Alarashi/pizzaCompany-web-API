using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;


namespace Application.IService
{
    public interface IPizzaService
    {
        void CreatePizza(PizzaDto PizzaDto);

        PizzaDto GetPizzaById(int id);

        IEnumerable<PizzaDto> GetPizzas();

        void UpdatePizza(PizzaDto pizzaDto);

        void DeletePizza(int id);
    }
}
