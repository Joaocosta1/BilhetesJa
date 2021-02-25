using System.Collections.Generic;

namespace WebService.ViewModels.Warehouse
{
    public class DetailWarehouseViewModel : PreviewWarehouseViewModel
    {
        public ICollection<PreviewWarehouseProductViewModel> Stock { get; set; }
    }
}