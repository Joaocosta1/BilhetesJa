using System.Collections.Generic;

namespace WebService.ViewModels.Sale
{
    public class CreateSaleViewModel
    {
        public int WarehouseId { get; set; }
        public ICollection<CreateSalePaymentViewModel> Payments { get; set; }
        public ICollection<CreateSaleItemViewModel> Items { get; set; }
    }
}