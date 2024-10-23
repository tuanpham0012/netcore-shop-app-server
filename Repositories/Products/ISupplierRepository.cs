using ShopAppApi.Data;

namespace ShopAppApi.Repositories.Products
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAll();
    }
}
