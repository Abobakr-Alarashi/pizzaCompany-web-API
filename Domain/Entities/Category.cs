using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntities
    {
        public string Name { get; set; }


        public List<Pizza> Pizzas { get; set; }
    }
}
