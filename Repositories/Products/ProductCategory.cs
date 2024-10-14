using Microsoft.AspNetCore.Mvc;
using ShopAppApi.Data;
using ShopAppApi.Response;
using Slugify;
using System.Collections;

namespace ShopAppApi.Repositories.Products
{
    public class ProductCategory : IProductRepository
    {
        private readonly ShopAppContext _context;

        public ProductCategory(ShopAppContext context) {
            _context = context;
                }
        public async Task<Product> Create(StoreProductRequest product)
        {
            var entry = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Unit = product.Unit,
                Alias = new SlugHelper().GenerateSlug(product.Name),
                Description =product.Description,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            _context.Add(entry);
            await _context.SaveChangesAsync();

            return entry;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<Product>> GetAll(Product request)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(int id, Product customer)
        {
            throw new NotImplementedException();
        }
    }
}
