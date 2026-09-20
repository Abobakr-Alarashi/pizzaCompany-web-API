using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pizza : BaseEntities
    {
        
        public string Name { get; set; }
        public string  Description { get; set; }
        public double Price { get; set; }
        public bool IsGultenFree { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<PizzaTopping> PizzaToppings { get; set; }
        public List<OrderItem> OrderItems { get; set; }


    }
}
