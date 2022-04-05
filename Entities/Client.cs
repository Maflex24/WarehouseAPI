using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Models
{
    public class Client : IPerson
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
