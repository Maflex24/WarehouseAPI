using System.ComponentModel.DataAnnotations;
using WarehouseAPI.Entities;

namespace WarehouseAPI.Models
{
    public class RegisterClientModelDto
    {
        public string? Login { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
