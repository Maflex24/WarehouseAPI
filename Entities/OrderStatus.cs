﻿namespace WarehouseAPI.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string? DisplayStatus { get; set; }
    }
}
