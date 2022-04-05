using Microsoft.EntityFrameworkCore;

namespace WarehouseAPI.Entities
{
    [Keyless]
    public class OrderPosition
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
