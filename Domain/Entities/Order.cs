using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order :BaseEntities
    {
        public int CustomerId { get; set; }
        public string status { get; set; }
        public double TotalPrice { get; set; }

        public Customer  Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
