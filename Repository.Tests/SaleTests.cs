using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repository.Interface;
using Repository.Repository;

namespace Repository.Tests
{
    [TestFixture]
    public class SaleTests
    {
        private ApplicationContext _context;
        private IEventService _eventService;
        private IProductService _productService;
        private IPaymentTypeService _paymentTypeService;
        private ISaleService _saleService;
        
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "SalesTestsDatabase")
                .Options;
            
            _context = new ApplicationContext(options);
            
            _eventService = new EventService(_context);
            _productService = new ProductService(_context);
            _paymentTypeService = new PaymentTypeService(_context);
//            _saleService = new SaleState(_context);
            
//            _saleService = new SaleSer(_context);
        }
        
//        [Test]
//        public async Task ShouldCreateEvent()
//        {
//            var @event = new Event()
//            {
//                Name = "Beco Diagonal"
//            };
//
//            await _eventService.SaveAsync(@event);
//
//            @event = await _eventService.FindByIdAsync(@event.Id);
//            Assert.NotNull(@event);
//        }
    }
}