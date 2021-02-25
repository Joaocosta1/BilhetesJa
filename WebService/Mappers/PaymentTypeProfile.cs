using AutoMapper;
using Domain.Entity;
using WebService.ViewModels;
using WebService.ViewModels.PaymentType;
using WebService.ViewModels.Sale;

namespace WebService.Mappers
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<CreatePaymentTypeViewModel, PaymentType>();
            CreateMap<CreateSalePaymentViewModel, Payment>();
            CreateMap<UpdatePaymentTypeViewModel, PaymentType>();
            CreateMap<PaymentType, PreviewPaymentTypeViewModel>();
        }
    }
}