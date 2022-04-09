using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Models
{
    public class RegisterEmployeeModelDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string BadgeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
