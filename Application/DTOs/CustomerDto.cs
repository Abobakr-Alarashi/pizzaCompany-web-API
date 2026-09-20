using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CustomerDto : BaseEntitiesDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "First name contains invalid characters.")]
        public string firstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Last name contains invalid characters.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(254, ErrorMessage = "Email cannot exceed 254 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^7[01378]\d{7}$", ErrorMessage = "Invalid phone number format")]
        public string phoneNumber { get; set; }

    }
}
