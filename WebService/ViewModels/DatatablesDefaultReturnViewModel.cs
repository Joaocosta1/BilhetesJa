namespace WebService.ViewModels
{
    public class DatatablesDefaultReturnViewModel<T>
    {
        public T Data { get; set; }
        public string Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        
        public DatatablesDefaultReturnViewModel(T data, int recordsTotal, int recordsFiltered)
        {
            Data = data;
            Draw = "1";
            RecordsTotal = recordsTotal;
            RecordsFiltered = recordsFiltered;
        }
    }
}