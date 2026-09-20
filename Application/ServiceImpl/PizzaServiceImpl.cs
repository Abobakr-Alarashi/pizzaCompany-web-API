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
    public class PizzaServiceImpl : IPizzaService
    {
        private readonly IMapper _mapper;
        private readonly IPizzaRepository _pizzaRepository; // dependancy injection

        public PizzaServiceImpl(IPizzaRepository catergoryRepository, IMapper mapper)
        {
            _pizzaRepository = catergoryRepository;
            _mapper = mapper;
        }
        public void CreatePizza(PizzaDto pizzaDto)
        {
            if (pizzaDto == null) throw new ArgumentNullException(nameof(pizzaDto));

            var pizzaEntity = _mapper.Map<Pizza>(pizzaDto);

            pizzaEntity.Id = 0;

            _pizzaRepository.Add(pizzaEntity);
        }


        public PizzaDto GetPizzaById(int id)
        {
            var pizzaEntity = _pizzaRepository.GetById(id);

            if (pizzaEntity == null) return null;

            return _mapper.Map<PizzaDto>(pizzaEntity);
        }

        public void UpdatePizza(PizzaDto pizzaDto)
        {
            if (pizzaDto == null) throw new ArgumentNullException(nameof(pizzaDto));

            var existingPizza = _pizzaRepository.GetById(pizzaDto.Id);
            if (existingPizza == null) throw new ArgumentNullException(nameof(pizzaDto));

            _mapper.Map(pizzaDto, existingPizza);

            _pizzaRepository.Update(existingPizza);
        }

        public IEnumerable<PizzaDto> GetPizzas()
        {
            var pizzaEntities = _pizzaRepository.GetAll();

            return _mapper.Map<IList<PizzaDto>>(pizzaEntities);
        }
        public void DeletePizza(int id)
        {
            var pizza = _pizzaRepository.GetById(id);
            if (pizza == null) throw new ArgumentNullException(nameof(pizza));

            _pizzaRepository.Delete(id);
        }

    }
}
