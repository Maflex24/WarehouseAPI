using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Entities
{
    public class Product
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Sex { get; set; }
        public string Color { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
