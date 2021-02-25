using AutoMapper;
using Domain.Entity;
using WebService.ViewModels.Sale;

namespace WebService.Mappers
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<CreateSaleViewModel, Sale>();
            CreateMap<UpdateSaleViewModel, Sale>();
            CreateMap<CreateSaleItemViewModel, SaleItem>();
        }
    }
}