using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WarehouseAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
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
