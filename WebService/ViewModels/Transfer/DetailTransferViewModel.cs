using System.Collections.Generic;

namespace WebService.ViewModels.Transfer
{
    public class DetailTransferViewModel
    {
        public int Id { get; set; }
        public PreviewTransferWarehouseViewModel WarehouseOrigin { get; set; }
        public PreviewTransferWarehouseViewModel WarehouseDestiny { get; set; }
        public PreviewTransferEventViewModel Event { get; set; }
        public List<PreviewTransferItemViewModel> Items { get; set; }
    }
}