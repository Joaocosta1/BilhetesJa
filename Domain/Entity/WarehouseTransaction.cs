using Domain.Enum;

namespace Domain.Entity
{
    public class WarehouseTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Amount { get; set; }
        public WarehouseTransactionType Type { get; set; }

        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}