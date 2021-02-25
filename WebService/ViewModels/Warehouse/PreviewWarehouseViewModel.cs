using WebService.ViewModels.PaymentType;

namespace WebService.ViewModels.Warehouse
{
    public class PreviewWarehouseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PreviewPaymentTypeEventViewModel Event { get; set; }
    }
}