using System.ComponentModel.DataAnnotations;
using WarehouseAPI.Entities;

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
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
