using System.Collections.Generic;
using WebService.ViewModels.Event;

namespace WebService.ViewModels.Product
{
    public class PreviewProductViewModel
    {
        public int Id { get; set; }
        public PreviewEventViewModel Event { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double? PurchasePrice { get; set; }
        public ICollection<PreviewProductCompositionViewModel> Composition { get; set; }
    }
}