using System.Collections.Generic;
using Domain.Enum;
using Domain.Interface;

namespace Domain.Entity
{
    public class Receipt : BaseWarehouseTransaction
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public ReceiptState State { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual ICollection<ReceiptItem> Items { get; set; }
    }
}