namespace Domain.Entity
{
    public class PaymentType
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public double Tax { get; set; }

        public virtual Event Event { get; set; }
        
        public override string ToString() => $"{Id}/{EventId} - {Name}";
    }
}