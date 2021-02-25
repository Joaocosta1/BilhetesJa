namespace Domain.Entity
{
    public class ClosurePaymentType
    {
        public int ClosureId { get; set; }
        public int PaymentTypeId { get; set; }
        public double Total { get; set; }

        public virtual Closure Closure { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}