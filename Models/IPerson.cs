using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Models
{
    public interface IPerson
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
