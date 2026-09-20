using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class OrderDto : BaseEntitiesDto
    {
        public int customerId { get; set; }
        

        [Required(ErrorMessage = "status is required.")]
        [AllowedValues("ongoing", "canceled", "delivered", ErrorMessage = "status must be ongoing, canceled or delivered.")]
        public string status { get; set; }


        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than 0.")] 
        public decimal totalPrice { get; set; }

   

    }
}
