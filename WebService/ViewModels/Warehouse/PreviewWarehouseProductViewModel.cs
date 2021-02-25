namespace WebService.ViewModels.Warehouse
{
    public class PreviewWarehouseProductViewModel
    {
        public PreviewProductWarehouseProductViewModel Product { get; set; }
        public int Amount { get; set; }
    }
    
    public class PreviewProductWarehouseProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}