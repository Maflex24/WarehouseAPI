using System.ComponentModel.DataAnnotations.Schema;
using WarehouseAPI.Entities;

namespace WarehouseAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? OrderStatusId { get; set; }
        public int? OrderPositionId { get; set; }
        public int? ClientId { get; set; }
        //public int? ShipmentAddressId { get; set; }
        // todo disabled because error of buildind database "Introducing FOREIGN KEY constraint 'FK_Orders_Addresses_ShipmentAddressId' on table 'Orders' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints."
        //public int? InvoiceAddressId { get; set; }

        public virtual OrderStatus Status { get; set; }
        [NotMapped]
        public virtual List<OrderPosition> ProductsList { get; set; }
        public virtual Client Client { get; set; }
        //public virtual Address ShipmentAddress { get; set; }
        //public virtual Address InvoiceAddress { get; set; }

    }
}
