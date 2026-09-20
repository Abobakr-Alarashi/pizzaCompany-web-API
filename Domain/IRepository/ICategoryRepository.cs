using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICategoryRepository
    {
        void Add(Category category); 

        void Update(Category category);

        void Delete(int id);

        Category GetById(int id);

        List<Category> GetAll();

    }
}
