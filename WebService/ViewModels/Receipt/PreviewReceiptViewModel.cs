using Domain.Enum;
using WebService.ViewModels.Event;

namespace WebService.ViewModels.Receipt
{
    public class PreviewReceiptViewModel
    {
        public int Id { get; set; }
        public PreviewEventViewModel Event { get; set; }
        public int WarehouseId { get; set; }
        public ReceiptState State { get; set; }
    }
}