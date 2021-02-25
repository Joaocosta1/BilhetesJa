using System.Collections.Generic;
using Domain.Enum;
using Domain.Interface;

namespace Domain.Entity
{
    public class Transfer : BaseWarehouseTransaction
    {
        public int Id { get; set; }
        public int WarehouseOriginId { get; set; }
        public int WarehouseDestinyId { get; set; }
        public TransferState State { get; set; }
        
        public virtual Warehouse WarehouseOrigin { get; set; }
        public virtual Warehouse WarehouseDestiny { get; set; }

        public virtual ICollection<TransferItem> Items { get; set; }

        public override string ToString() => $"{WarehouseOrigin.Name} => {WarehouseDestiny.Name} | {State}";
    }
}