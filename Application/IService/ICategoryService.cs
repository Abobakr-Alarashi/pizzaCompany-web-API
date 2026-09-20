using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.IService
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDto categoryDto);


        CategoryDto GetCategoryById(int id);

        IEnumerable<CategoryDto> GetCategories();


        void UpdateCategory(CategoryDto categoryDto);

        void DeleteCategory(int id);

        

    }
}
