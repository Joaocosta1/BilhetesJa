using AutoMapper;
using Domain.Entity;
using WebService.ViewModels;
using WebService.ViewModels.Receipt;

namespace WebService.Mappers
{
    public class ReceiptProfile : Profile
    {
        public ReceiptProfile()
        {
            CreateMap<CreateReceiptViewModel, Receipt>();
            CreateMap<UpdateReceiptViewModel, Receipt>();
            CreateMap<CreateReceiptItemViewModel, ReceiptItem>();
            
            CreateMap<Receipt, PreviewReceiptViewModel>();
        }
    }
}