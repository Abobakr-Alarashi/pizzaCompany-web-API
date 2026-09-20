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
    public class PizzaToppingServiceImpl : IPizzaToppingService
    {
        private readonly IMapper _mapper;
        private readonly IPizzaToppingRepository _pizzaToppingRepository; // dependancy injection

        public PizzaToppingServiceImpl(IPizzaToppingRepository catergoryRepository, IMapper mapper)
        {
            _pizzaToppingRepository = catergoryRepository;
            _mapper = mapper;
        }
        public void CreatePizzaTopping(PizzaToppingDto pizzaToppingDto)
        {
            if (pizzaToppingDto == null) throw new ArgumentNullException(nameof(pizzaToppingDto));

            var pizzaToppingEntity = _mapper.Map<PizzaTopping>(pizzaToppingDto);


            _pizzaToppingRepository.Add(pizzaToppingEntity);
        }


        public PizzaToppingDto GetPizzaToppingById(int pizzaId,int toppingId)
        {
            var pizzaToppingEntity = _pizzaToppingRepository.GetById(pizzaId,toppingId);

            if (pizzaToppingEntity == null) return null;

            return _mapper.Map<PizzaToppingDto>(pizzaToppingEntity);
        }

        public void UpdatePizzaTopping(PizzaToppingDto pizzaToppingDto)
        {
            if (pizzaToppingDto == null) throw new ArgumentNullException(nameof(pizzaToppingDto));

            var existingPizzaTopping = _pizzaToppingRepository.GetById(pizzaToppingDto.pizzaId,pizzaToppingDto.toppingId);
            if (existingPizzaTopping == null) throw new ArgumentNullException(nameof(pizzaToppingDto));

            _mapper.Map(pizzaToppingDto, existingPizzaTopping);

            _pizzaToppingRepository.Update(existingPizzaTopping);
        }

        public IEnumerable<PizzaToppingDto> GetPizzaToppings()
        {
            var pizzaToppingEntities = _pizzaToppingRepository.GetAll();

            return _mapper.Map<IList<PizzaToppingDto>>(pizzaToppingEntities);
        }
        public void DeletePizzaTopping(int pizzaId, int toppingId)
        {
            var pizzaTopping = _pizzaToppingRepository.GetById(pizzaId,toppingId);
            if (pizzaTopping == null) throw new ArgumentNullException(nameof(pizzaTopping));

            _pizzaToppingRepository.Delete(pizzaId,toppingId);
        }

        public IEnumerable<PizzaToppingDto> GetPizzaToppingsByPizzaId(int pizzaId)
        {
            var pizzaTopping = _pizzaToppingRepository.GetByPizzaId(pizzaId);
            if (pizzaTopping == null) throw new ArgumentNullException(nameof(pizzaTopping));

            return _mapper.Map<IEnumerable<PizzaToppingDto>>(pizzaTopping);
        }

        public IEnumerable<PizzaToppingDto> GetPizzaToppingsByToppingId(int toppingId)
        {
            var pizzaTopping = _pizzaToppingRepository.GetByToppingId(toppingId);
            if (pizzaTopping == null) throw new ArgumentNullException(nameof(pizzaTopping));

            return _mapper.Map<IEnumerable<PizzaToppingDto>>(pizzaTopping);
        }
    }
}
