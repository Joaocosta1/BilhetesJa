using AutoMapper;
using Domain.Entity;
using WebService.ViewModels;
using WebService.ViewModels.Event;
using WebService.ViewModels.PointOfSale;

namespace WebService.Mappers
{
    public class ProductGroupProfile : Profile
    {
        public ProductGroupProfile()
        {
            CreateMap<CreatePorductGroupViewModel, ProductGroup>();
            CreateMap<UpdateProductGroupViewModel, ProductGroup>();
            CreateMap<ProductGroup, PreviewProductGroupViewModel>();
            CreateMap<ProductGroup, PreviewReadForSaleViewModel>();
        }
    }
}
