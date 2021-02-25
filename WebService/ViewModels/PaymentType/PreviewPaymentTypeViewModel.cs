using WebService.ViewModels.PaymentType;

namespace WebService.ViewModels
{
    public class PreviewPaymentTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Tax { get; set; }
        public PreviewPaymentTypeEventViewModel Event { get; set; }
    }
}