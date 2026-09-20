using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CategoryDto : BaseEntitiesDto
    {
        [Required(ErrorMessage = "name is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "name must be between 2 and 20 characters.")]
        public string name { get; set; }


    }
}
