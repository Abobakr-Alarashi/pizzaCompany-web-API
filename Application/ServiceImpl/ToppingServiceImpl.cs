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
    public class ToppingServiceImpl : IToppingService
    {
        private readonly IMapper _mapper;
        private readonly IToppingRepository _toppingRepository; // dependancy injection

        public ToppingServiceImpl(IToppingRepository catergoryRepository, IMapper mapper)
        {
            _toppingRepository = catergoryRepository;
            _mapper = mapper;
        }
        public void CreateTopping(ToppingDto toppingDto)
        {
            if (toppingDto == null) throw new ArgumentNullException(nameof(toppingDto));

            var toppingEntity = _mapper.Map<Topping>(toppingDto);

            toppingEntity.Id = 0;

            _toppingRepository.Add(toppingEntity);
        }


        public ToppingDto GetToppingById(int id)
        {
            var toppingEntity = _toppingRepository.GetById(id);

            if (toppingEntity == null) return null;

            return _mapper.Map<ToppingDto>(toppingEntity);
        }

        public void UpdateTopping(ToppingDto toppingDto)
        {
            if (toppingDto == null) throw new ArgumentNullException(nameof(toppingDto));

            var existingTopping = _toppingRepository.GetById(toppingDto.Id);
            if (existingTopping == null) throw new ArgumentNullException(nameof(toppingDto));

            _mapper.Map(toppingDto, existingTopping);

            _toppingRepository.Update(existingTopping);
        }

        public IEnumerable<ToppingDto> GetToppings()
        {
            var toppingEntities = _toppingRepository.GetAll();

            return _mapper.Map<IList<ToppingDto>>(toppingEntities);
        }
        public void DeleteTopping(int id)
        {
            var topping = _toppingRepository.GetById(id);
            if (topping == null) throw new ArgumentNullException(nameof(topping));

            _toppingRepository.Delete(id);
        }

    }
}
