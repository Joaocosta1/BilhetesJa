namespace Domain.Entity
{
    public class ProductComposition
    {
        public int MasterProductId { get; set; }
        public int SlaveProductId { get; set; }
        public int Amount { get; set; }
        public double ProratedValue { get; set; }

        public virtual Product MasterProduct { get; set; }
        public virtual Product SlaveProduct { get; set; }
    }
}