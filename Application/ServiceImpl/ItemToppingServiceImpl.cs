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
    public class ItemToppingServiceImpl : IItemToppingService
    {
        private readonly IMapper _mapper;
        private readonly IItemToppingRepository _itemToppingRepository; // dependancy injection
        

        public ItemToppingServiceImpl(IItemToppingRepository itemToppingRepository, IMapper mapper)
        {
            _itemToppingRepository = itemToppingRepository;
            _mapper = mapper;
        }
        public void CreateItemTopping(ItemToppingDto itemToppingDto)
        {
            if (itemToppingDto == null) throw new ArgumentNullException(nameof(itemToppingDto));

            var itemToppingEntity = _mapper.Map<ItemTopping>(itemToppingDto);

            _itemToppingRepository.Add(itemToppingEntity);
        }


        public ItemToppingDto GetItemToppingById(int orderId, int toppingId)
        {
            var itemToppingEntity = _itemToppingRepository.GetById(orderId,toppingId);

            if (itemToppingEntity == null) return null;

            return _mapper.Map<ItemToppingDto>(itemToppingEntity);
        }

        public void UpdateItemTopping(ItemToppingDto itemToppingDto)
        {
            if (itemToppingDto == null) throw new ArgumentNullException(nameof(itemToppingDto));

            var existingItemTopping = _itemToppingRepository.GetById(itemToppingDto.orderItemId, itemToppingDto.toppingId);
            if (existingItemTopping == null) throw new ArgumentNullException(nameof(itemToppingDto));

            _mapper.Map(itemToppingDto, existingItemTopping);

            _itemToppingRepository.Update(existingItemTopping);
        }

        public IEnumerable<ItemToppingDto> GetItemToppings()
        {
            var itemToppingEntities = _itemToppingRepository.GetAll();

            return _mapper.Map<IList<ItemToppingDto>>(itemToppingEntities);
        }

        public void DeleteItemTopping(int orderId, int toppingId)
        {
            var itemTopping = _itemToppingRepository.GetById(orderId,toppingId);
            if (itemTopping == null) throw new ArgumentNullException(nameof(itemTopping));


            _itemToppingRepository.Delete(orderId,toppingId);
        }

        public IEnumerable<ItemToppingDto> GetItemToppingsByOrderId(int orderId)
        {
            var itemTopping = _itemToppingRepository.GetByOrderId(orderId);
            if (itemTopping == null) throw new ArgumentNullException(nameof(itemTopping));

            return _mapper.Map<IEnumerable<ItemToppingDto>>(itemTopping);
        }

        public IEnumerable<ItemToppingDto> GetItemToppingsByToppingId(int toppingId)
        {
            var itemTopping = _itemToppingRepository.GetByToppingId(toppingId);
            if (itemTopping == null) throw new ArgumentNullException(nameof(itemTopping));

            return _mapper.Map<IEnumerable<ItemToppingDto>>(itemTopping);
        }
    }
}
