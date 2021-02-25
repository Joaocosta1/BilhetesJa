namespace Domain.Entity
{
    public class TransferItem
    {
        public int TransferId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual Transfer Transfer { get; set; }
        public virtual Product Product { get; set; }    
    }
}