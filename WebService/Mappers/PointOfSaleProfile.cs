using AutoMapper;
using Domain.Entity;
using WebService.ViewModels;
using WebService.ViewModels.Event;
using WebService.ViewModels.PointOfSale;

namespace WebService.Mappers
{
    public class PointOfSaleProfile : Profile
    {
        public PointOfSaleProfile()
        {
            CreateMap<CreatePointOfSaleViewModel, PointOfSale>();
            CreateMap<UpdatePointOfSaleViewModel, PointOfSale>();
            CreateMap<PointOfSale, PreviewEventViewModel>();    
        }
    }
}
