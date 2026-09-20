using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem : BaseEntities
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public Pizza Pizza { get; set; }
        public Order Order  { get; set; }
        public List<ItemTopping> ItemToppings { get; set; }


    }
}
