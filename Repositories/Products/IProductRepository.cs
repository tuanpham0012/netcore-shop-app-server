using Microsoft.AspNetCore.Mvc;
using ShopAppApi.Data;
using ShopAppApi.Response;

namespace ShopAppApi.Repositories.Products
{
    public interface IProductRepository
    {
        Task<PaginatedList<Product>> GetAll(Product request);
        Customer? Find(int id);
        Task<Product> Create(StoreProductRequest product);
        Task<Product> Update(int id, Product customer);
        Boolean Delete(int id);
    }
}
