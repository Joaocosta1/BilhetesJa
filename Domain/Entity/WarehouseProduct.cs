namespace Domain.Entity
{
    public class WarehouseProduct
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        
        public WarehouseProduct(int warehouseId, int productId, int amount)
        {
            WarehouseId = warehouseId;
            ProductId = productId;
            Amount = amount;
        }

        public virtual Warehouse Warehouse { get; set; }
        public virtual Product Product { get; set; }
    }
}