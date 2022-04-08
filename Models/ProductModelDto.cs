using WarehouseAPI.Entities;

namespace WarehouseAPI.Models
{
    public class ProductModelDto
    {
        public string? Code { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Sex { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
    }
}
