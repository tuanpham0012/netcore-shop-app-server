using ShopAppApi.Data;
using ShopAppApi.Response;

namespace ShopAppApi.Repositories.Products
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }
}
