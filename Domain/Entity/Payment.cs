namespace Domain.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public double Value { get; set; }
        public int PaymentTypeId { get; set; }
        public double Tax { get; set; }
        public double PayedTax { get; set; }

        public virtual PaymentType PaymentType { get; set; }
    }
}