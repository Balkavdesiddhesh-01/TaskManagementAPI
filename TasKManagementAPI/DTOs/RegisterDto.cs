using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TasKManagementAPI.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="UserName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="UserName must be between 3 and 50 character")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Emmail is required")]
        [EmailAddress(ErrorMessage ="invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="password is required")]
        [StringLength(100, MinimumLength =6, ErrorMessage ="password must be at least 6 characters")]
        public string password { get; set; } = string.Empty;



    }
}
