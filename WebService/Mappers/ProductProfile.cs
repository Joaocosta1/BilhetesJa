using AutoMapper;
using Domain.Entity;
using WebService.ViewModels;
using WebService.ViewModels.Product;
using WebService.ViewModels.Transfer;
using WebService.ViewModels.Warehouse;

namespace WebService.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<Product, PreviewProductWarehouseProductViewModel>();
            CreateMap<ProductCompositionViewModel, ProductComposition>()
                .ForMember(dest => dest.SlaveProductId, opts => opts.MapFrom(src => src.Id));

            CreateMap<Product, PreviewProductViewModel>();
            CreateMap<Product, PreviewTransferItemProductViewModel>();
            CreateMap<ProductComposition, PreviewProductCompositionViewModel>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.SlaveProduct.Name))
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.SlaveProduct.Id));
        }
    }
}