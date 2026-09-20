using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ItemToppingDto 
    {
        public int orderItemId { get; set; }

        public int toppingId { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than 0.")] 
        public decimal toppingPrice { get; set; }


    }
}
