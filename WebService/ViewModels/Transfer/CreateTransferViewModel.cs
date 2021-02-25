using System.Collections.Generic;

namespace WebService.ViewModels.Transfer
{
    public class CreateTransferViewModel
    {
        public int WarehouseOriginId { get; set; }
        public int WarehouseDestinyId { get; set; }
        public int EventId { get; set; }
        public ICollection<CreateTransferItemViewModel> Items { get; set; }
    }
}