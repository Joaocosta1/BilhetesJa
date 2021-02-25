using System.Collections.Generic;

namespace WebService.ViewModels.Receipt
{
    public class CreateReceiptViewModel
    {
        public int WarehouseId { get; set; }
        public int EventId { get; set; }
        public ICollection<CreateReceiptItemViewModel> Items { get; set; }
    }
}