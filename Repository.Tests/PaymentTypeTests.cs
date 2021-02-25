using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repository.Interface;
using Repository.Repository;

namespace Repository.Tests
{
    [TestFixture]
    public class PaymentTypeTests
    {
        private ApplicationContext _context;
        private IPaymentTypeService _paymentTypeService;
        private IEventService _eventService;
        private Event _event;
        
        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "PaymentTypeTestDatabase")
                .Options;
            
            _context = new ApplicationContext(options);
            
            _paymentTypeService = new PaymentTypeService(_context);
            _eventService = new EventService(_context);

            var @event = new Event()
            {
                Name = "Beco Diagonal"
            };

            await _eventService.SaveAsync(@event);
        }
        
        [Test]
        public async Task ShouldCreatePaymentType()
        {
            var paymentType = new PaymentType()
            {
                Event = _event,
                Name = "Débito",
                Tax = 0
            };

            await _paymentTypeService.SaveAsync(paymentType);

            var pType = _paymentTypeService.FindByIdAsync(paymentType.Id);
            Assert.NotNull(pType);
        }
        
        [Test]
        public async Task ShouldUpdatePaymentType()
        {
            var paymentType = new PaymentType()
            {
                Event = _event,
                Name = "Débito 2",
                Tax = 0
            };

            await _paymentTypeService.SaveAsync(paymentType);

            var pType = await _paymentTypeService.FindByIdAsync(paymentType.Id);

            pType.Name = "Débito 2 - Atualizado";
            
            await _paymentTypeService.SaveAsync(pType);
            
            var newPType = await _paymentTypeService.FindByIdAsync(paymentType.Id);
            
            Assert.AreEqual("Débito 2 - Atualizado", newPType.Name);
        }
        

    }
}