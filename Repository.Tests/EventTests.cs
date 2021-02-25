using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repository.Interface;
using Repository.Repository;

namespace Repository.Tests
{
    [TestFixture]
    public class EventTests
    {
        private ApplicationContext _context;
        private IEventService _eventService;
        
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "EventTestsDatabase")
                .Options;
            
            _context = new ApplicationContext(options);
            
            _eventService = new EventService(_context);
        }
        
        [Test]
        public async Task ShouldCreateEvent()
        {
            var @event = new Event()
            {
                Name = "Beco Diagonal"
            };

            await _eventService.SaveAsync(@event);

            @event = await _eventService.FindByIdAsync(@event.Id);
            Assert.NotNull(@event);
        }
        
        [Test]
        public async Task ShouldSetCreatedDateWhenEventCreated()
        {
            var @event = new Event()
            {
                Name = "Hogwarts"
            };

            await _eventService.SaveAsync(@event);

            Assert.NotNull(@event.CreatedDate);
        }
        
        [Test]
        public async Task ShouldSetUpdatedDateWhenEventUpdate()
        {
            var @event = new Event()
            {
                Name = "RedeInova"
            };

            await _eventService.SaveAsync(@event);

            @event.Name = "RedeInova 2";
            
            await _eventService.SaveAsync(@event);

            Assert.NotNull(@event.UpdatedDate);
        }
        
        [Test]
        public async Task OnUpdateShouldNotNullCreatedDate()
        {
            var @event = new Event()
            {
                Name = "RedeInova"
            };

            await _eventService.SaveAsync(@event);

            @event.Name = "RedeInova 2";
            
            await _eventService.SaveAsync(@event);

            Assert.NotNull(@event.CreatedDate);
        }
        
        [Test]
        public async Task ShouldUpdatedDataWhenUpdated()
        {
            var @event = new Event()
            {
                Name = "Should update data"
            };

            await _eventService.SaveAsync(@event);

            @event.Name = "Should update data 2";
            
            @event = await _eventService.FindByIdAsync(@event.Id);

            Assert.AreEqual("Should update data 2", @event.Name);
        }
    }
}