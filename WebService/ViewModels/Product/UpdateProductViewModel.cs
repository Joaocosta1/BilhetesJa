namespace WebService.ViewModels.Product
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public double SalePrice { get; set; }
        public double PurchasePrice { get; set; }
    }
}