using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Entities
{
    public class Product
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public int SizeId { get; set; }
        public int SexId { get; set; }
        public int ColorId { get; set; }

        public int? CategoryId { get; set; }
        public virtual Size Size { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual Color Color { get; set; }
        public virtual Category Category { get; set; }
    }
}
