using Microsoft.AspNetCore.Mvc;
using ShopAppApi.Data;
using ShopAppApi.Request;
using ShopAppApi.Response;

namespace ShopAppApi.Repositories.Products
{
    public interface IProductRepository
    {
        Task<PaginatedList<Product>> GetAll(ProductRequest request, List<String>? Includes = null!);
        Product? Find(int Id, List<String>? Includes = null!);
        Task Create(StoreProductRequest product);
        Task Update(int id, Product customer);
        Boolean Delete(int id);
    }
}
