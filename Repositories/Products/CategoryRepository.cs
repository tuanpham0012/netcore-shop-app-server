using Microsoft.EntityFrameworkCore;
using ShopAppApi.Data;

namespace ShopAppApi.Repositories.Products
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopAppContext _context;

        public CategoryRepository(ShopAppContext context) {
            _context = context;
        }
        public async Task<List<Category>> GetAll()
        {
            var entries = _context.Categories.AsNoTracking().Select( q => new Category
            {
                Id = q.Id,
                Name = q.Name,
                Code = q.Code
            });

            return await entries.ToListAsync();
        }
    }
}
