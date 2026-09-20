using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;


namespace Application.IService
{
    public interface IToppingService
    {
        void CreateTopping(ToppingDto toppingDto);

        ToppingDto GetToppingById(int id);

        IEnumerable<ToppingDto> GetToppings();

        void UpdateTopping(ToppingDto toppingDto);

        void DeleteTopping(int id);
    }
}
