using AutoMapper;
using Domain.Entity;
using WebService.ViewModels;
using WebService.ViewModels.Event;
using WebService.ViewModels.PaymentType;
using WebService.ViewModels.Transfer;

namespace WebService.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventViewModel, Event>();
            CreateMap<UpdateEventViewModel, Event>();
            CreateMap<Event, PreviewEventViewModel>();
            CreateMap<Event, PreviewPaymentTypeEventViewModel>();
            CreateMap<Event, PreviewTransferEventViewModel>();
        }
    }
}