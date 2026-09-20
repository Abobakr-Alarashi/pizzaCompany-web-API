using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Application.DTOs
{
    public class OrderItemDto : BaseEntitiesDto
    {
        public int orderId { get; set; }

        public int pizzaId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        public int quantity { get; set; }


        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than 0.")] 
        public decimal unitPrice { get; set; }

       


    }
}
