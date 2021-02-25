using System;
using WebService.ViewModels.Product;

namespace WebService.ViewModels.PointOfSale
{
    public class PreviewReadForSaleViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public PreviewProductViewModel Product { get; set; }

    }
}
