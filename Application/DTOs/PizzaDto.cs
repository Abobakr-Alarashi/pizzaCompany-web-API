using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PizzaDto : BaseEntitiesDto
    {

        [Required(ErrorMessage = "name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "name must be between 2 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s'-]+$", ErrorMessage = "name contains invalid characters.")]
        public string name { get; set; }


        [StringLength(100, ErrorMessage = "description cannot exceed 100 characters.")]
        public string?  description { get; set; }


        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than 0.")] 
        public decimal price { get; set; }


        public bool isGlutenFree { get; set; }
        

        public int categoryId { get; set; }

    
    }
}
