using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PizzaToppingDto 
    {
        public int pizzaId { get; set; }

        public int toppingId { get; set; }


    }
}
