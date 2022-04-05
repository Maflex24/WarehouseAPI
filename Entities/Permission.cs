using Microsoft.EntityFrameworkCore;

namespace WarehouseAPI.Entities
{
    [Keyless]
    public class Permission
    {
        public int EmployeeId { get; set; }
        public bool? IsAdmin { get; set; } = false;
    }
}
