using System.Collections.Generic;

namespace WebService.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public int EventId { get; set; }
        public double SalePrice { get; set; }
        public double? PurchasePrice { get; set; }
        public List<ProductCompositionViewModel> Composition { get; set; }

    }
}