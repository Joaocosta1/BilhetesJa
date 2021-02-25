namespace Domain.Entity
{
    public class SaleItemComposition
    {
        public int SaleItemId { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }
        public double Total { get; set; }
        
        public virtual SaleItem SaleItem { get; set; }
        public virtual Product Product { get; set; }
    }
}