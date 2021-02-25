using AutoMapper;
using Domain.Entity;
using WebService.ViewModels;
using WebService.ViewModels.Transfer;
using WebService.ViewModels.Warehouse;

namespace WebService.Mappers
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<CreateWarehouseViewModel, Warehouse>();
            CreateMap<UpdateWarehouseViewModel, Warehouse>();
            CreateMap<Warehouse, PreviewWarehouseViewModel>();
            CreateMap<Warehouse, DetailWarehouseViewModel>();
            CreateMap<Warehouse, PreviewTransferWarehouseViewModel>();
            CreateMap<WarehouseProduct, PreviewWarehouseProductViewModel>();
        }
    }
}