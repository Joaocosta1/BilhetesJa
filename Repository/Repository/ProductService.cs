using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Exception;
using Repository.Interface;

namespace Repository.Repository
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public Task<List<Product>> GetAllAsync(int eventId) =>
            _context.Products.Where(p => p.EventId == eventId).ToListAsync();

        public Task<List<Product>> GetAllAsync(Event @event) => GetAllAsync(@event.Id);

        public Task<List<Product>> GetAsync(int eventId, int limit = 10, int page = 0) => _context.Products
            .Where(p => p.EventId == eventId).Skip(limit * page).Take(limit).ToListAsync();

        public Task<List<Product>> GetAsync(Event @event, int limit = 10, int page = 0) =>
            GetAsync(@event.Id, limit, page);

        public Task<Product> FindByIdAsync(int productId) =>
            _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

        public async Task SaveAsync(Product product)
        {
            if (product.Id == 0)
            {
                product.CreatedDate = DateTime.Now;
                var entityEntry = _context.Add(product);
            }
            else
            {
                product.UpdatedDate = DateTime.Now;
                var entityEntry = _context.Attach(product);
                entityEntry.State = EntityState.Modified;
                entityEntry.Property(p => p.EventId).IsModified = false;
                entityEntry.Property(p => p.CreatorId).IsModified = false;
                entityEntry.Property(p => p.CreatedDate).IsModified = false;
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                await _context.SaveChangesAsync();
                
                if (product.HaveComposition)
                {
                    await LoadProductComposition(product.Composition);
                    
                    var productHaveComposition = product.Composition?.Any(c => c.SlaveProduct.HaveComposition);
                    if(productHaveComposition != null && productHaveComposition == true)
                        throw new ProductHasCompositionException();

                    CalculateApportionment(product);
                    
                    await _context.SaveChangesAsync();
                }
                
                transaction.Commit();
            }
        }

        private async Task LoadProductComposition(ICollection<ProductComposition> composition)
        {
            var idsToSearch = composition.Select(c => c.SlaveProductId).ToList();
            var products = await _context.Products.Where(p => idsToSearch.Contains(p.Id)).ToListAsync();

            foreach (var productComposition in composition)
            {
                productComposition.SlaveProduct =
                    products.FirstOrDefault(p => p.Id == productComposition.SlaveProductId);
            }
        }

        public void CalculateApportionment(Product product)
        {
            var composition = product.Composition;

            var totalValue = product.SalePrice;
            var totalCompositionValue = composition.Sum(c => c.Amount * c.SlaveProduct.SalePrice);
            
            var compositionValues = composition.Select(c =>
            new {
                ProductId = c.SlaveProductId,
                Value = c.Amount * c.SlaveProduct.SalePrice
            });
            
            var compositionPercents = compositionValues.Select(cv =>
            new {
                cv.ProductId,
                ValuePercent = ((cv.Value * 100) / totalCompositionValue) / 100
            });

            var proratedValueProducts = compositionPercents.Select(cp => new
            {
                cp.ProductId,
                ProratedValue = totalValue * cp.ValuePercent
            });

            foreach (var productComposition in composition)
            {
                productComposition.ProratedValue = proratedValueProducts
                    .FirstOrDefault(pvp => pvp.ProductId == productComposition.SlaveProductId).ProratedValue;
            }
        }

        public Task DeleteAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync(int eventId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync(Event @event)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountPagesAsync(int eventId, int limit = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountPagesAsync(Event @event, int limit = 10)
        {
            throw new System.NotImplementedException();
        }
    }
}