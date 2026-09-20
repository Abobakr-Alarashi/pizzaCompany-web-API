using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ItemTopping 
    {
        public int OrderItemId { get; set; }
        public int ToppingId { get; set; }
        public double ToppingPrice { get; set; }

        public OrderItem OrderItem { get; set; }
        public Topping Topping { get; set; }

    }
}
