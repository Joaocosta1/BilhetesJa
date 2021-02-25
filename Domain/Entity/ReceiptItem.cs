namespace Domain.Entity
{
    public class ReceiptItem
    {
        public int ReceiptId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual Receipt Receipt { get; set; }
        public virtual Product Product { get; set; }
    }
}