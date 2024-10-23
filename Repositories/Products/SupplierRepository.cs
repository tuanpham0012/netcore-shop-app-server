using Microsoft.EntityFrameworkCore;
using ShopAppApi.Data;

namespace ShopAppApi.Repositories.Products
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShopAppContext _context;

        public SupplierRepository(ShopAppContext context) { _context = context;  }
        public async Task<List<Supplier>> GetAll()
        {
            var entries = await _context.Suppliers.AsNoTracking().ToListAsync();
            return entries;
        }
    }
}
