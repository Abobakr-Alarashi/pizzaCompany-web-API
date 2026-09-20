using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Topping : BaseEntities
    {
        public string Name { get; set; }
        public bool IsGultenFree { get; set; }
        public double Price { get; set; }

        public List<ItemTopping> ItemToppings { get; set; }
        public List<PizzaTopping> PizzaToppings { get; set; }
    }
}
