using ShopAppApi.Data;
using ShopAppApi.Request;
using ShopAppApi.Response;

namespace ShopAppApi.Repositories.RepoCustomer
{
    public interface ICustomerRepository
    {
        Task<PaginatedList<Customer>> GetAll(CustomerRequest request);
        Customer? Find(int id);
        Customer Create(StoreCustomerRequest customer);
        void Update(int id, UpdateCustomerRequest customer);
        Boolean Delete(int id);
    }
}
