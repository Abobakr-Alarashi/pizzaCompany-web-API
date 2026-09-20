using Application.DTOs;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;


namespace Application.ServiceImpl
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository; // dependancy injection

        public CategoryServiceImpl(ICategoryRepository catergoryRepository, IMapper mapper)
        {
            _categoryRepository = catergoryRepository;
            _mapper = mapper;
        }
        public void CreateCategory(CategoryDto categoryDto)
        {
            if (categoryDto == null) throw new ArgumentNullException(nameof(categoryDto));

            var categoryEntity = _mapper.Map<Category>(categoryDto);

            categoryEntity.Id = 0;

            _categoryRepository.Add(categoryEntity);
        }


        public CategoryDto GetCategoryById(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id);

            if (categoryEntity == null) return null;

            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            if (categoryDto == null) throw new ArgumentNullException(nameof(categoryDto));

            var existingCategory = _categoryRepository.GetById(categoryDto.Id);
            if (existingCategory == null) throw new ArgumentNullException(nameof(categoryDto));

            _mapper.Map(categoryDto, existingCategory);

            _categoryRepository.Update(existingCategory);
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categoryEntities = _categoryRepository.GetAll();

            return _mapper.Map<IList<CategoryDto>>(categoryEntities);
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null) throw new ArgumentNullException(nameof(category));

            _categoryRepository.Delete(id);
        }
    }


}

