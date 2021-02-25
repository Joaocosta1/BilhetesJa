using System.Collections.Generic;

namespace WebService.ViewModels.Transfer
{
    public class PreviewTransferViewModel
    {
        public int Id { get; set; }
        public PreviewTransferWarehouseViewModel WarehouseOrigin { get; set; }
        public PreviewTransferWarehouseViewModel WarehouseDestiny { get; set; }
        public PreviewTransferEventViewModel Event { get; set; }
    }
}