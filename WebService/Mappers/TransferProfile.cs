using AutoMapper;
using Domain.Entity;
using WebService.ViewModels.Transfer;

namespace WebService.Mappers
{
    public class TransferProfile : Profile
    {
        public TransferProfile()
        {
            CreateMap<CreateTransferViewModel, Transfer>();
            CreateMap<UpdateTransferViewModel, Transfer>();
            CreateMap<CreateTransferItemViewModel, TransferItem>();
            
            CreateMap<Transfer, DetailTransferViewModel>();
            CreateMap<Transfer, PreviewTransferViewModel>();
            CreateMap<TransferItem, PreviewTransferItemViewModel>();
        }
    }
}