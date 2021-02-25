using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;
using Repository.Exception;
using Repository.Interface;
using Repository.Repository;

namespace Repository.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private ApplicationContext _context;
        private IProductService _productService;
        private IEventService _eventService;
        private Event _event;
        
        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "PaymentTypeTestDatabase")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            
            _context = new ApplicationContext(options);
            
            _productService = new ProductService(_context);
            _eventService = new EventService(_context);

            var @event = new Event()
            {
                Name = "Forró 9 3/4"
            };

            await _eventService.SaveAsync(@event);
        }
        
        [Test]
        public async Task ShouldCreateANewSimpleProduct()
        {
            var product = new Product()
            {
                Name = "Pena de dragão",
                Event = _event,
                SalePrice = 499,
            };

            await _productService.SaveAsync(product);

            var recoveredProduct = await _productService.FindByIdAsync(product.Id);
            
            Assert.NotNull(recoveredProduct);
        }
        
        [Test]
        public async Task ShouldCreateANewProductWithComposition()
        {
            var product = new Product()
            {
                Name = "Pena de dragão",
                Event = _event,
                SalePrice = 499,
            };

            await _productService.SaveAsync(product);
            
            var product2 = new Product()
            {
                Name = "Pena de dragão 2",
                Event = _event,
                SalePrice = 499,
                Composition = new List<ProductComposition>()
                {
                    new ProductComposition()
                    {
                        SlaveProduct = product,
                        Amount = 1
                    }
                } 
            };
            
            await _productService.SaveAsync(product2);

            var recoveredProduct = await _productService.FindByIdAsync(product2.Id);
            
            Assert.NotNull(recoveredProduct.Composition);
        }

        [Test]
        public void CantAddAComposeProductOnComposition()
        {
            Assert.ThrowsAsync<ProductHasCompositionException>(async () => await CantAddAComposeProductOnCompositionTrows());
        }

        public async Task CantAddAComposeProductOnCompositionTrows()
        {
            var product1 = new Product()
            {
                Name = "Pena de dragão 1",
                Event = _event,
                SalePrice = 499,
            };
            
            await _productService.SaveAsync(product1);

            var product = new Product()
            {
                Name = "Pena de dragão",
                Event = _event,
                SalePrice = 499,
                Composition = new List<ProductComposition>()
                {
                    new ProductComposition()
                    {
                        SlaveProduct = product1,
                        Amount = 2
                    }
                }
            };
            
            await _productService.SaveAsync(product);
            
            var product2 = new Product()
            {
                Name = "Pena de dragão 2",
                Event = _event,
                SalePrice = 499,
                Composition = new List<ProductComposition>()
                {
                    new ProductComposition()
                    {
                        SlaveProduct = product,
                        Amount = 1
                    }
                } 
            };
            
            await _productService.SaveAsync(product2);
        }
    }
}