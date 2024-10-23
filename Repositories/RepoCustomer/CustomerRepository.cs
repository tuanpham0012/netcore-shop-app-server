using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopAppApi.Data;
using ShopAppApi.Helpers;
using ShopAppApi.Request;
using ShopAppApi.Response;
using System.Net;
using System.Numerics;

namespace ShopAppApi.Repositories.RepoCustomer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopAppContext _context;
        private readonly IStringHelper _helper;

        public CustomerRepository(ShopAppContext context, IStringHelper helper) 
        {
            _context = context;
            _helper = helper;
        }
        public Boolean Delete(int id)
        {
            var entry = _context.Customers.FirstOrDefault(cus => cus.Id == id);

            if (entry != null)
            {
                _context.Remove(entry);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<PaginatedList<Customer>> GetAll(CustomerRequest request)
        {
            IQueryable<Customer> query = _context.Customers.Select(customer => new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                Status = customer.Status
            }).AsQueryable().OrderByDescending(q => q.Id);

            if (!request.Search.IsNullOrEmpty()) {
                query = query.Where(q => q.Name.Contains(request.Search) || q.Email.Contains(request.Search) || q.Phone.Contains(request.Search));
            }

            if (request.Status != null) {
                query = query.Where(q => q.Status == request.Status);
            }



            var data = await PaginatedList<Customer>.CreateAsync(
                query.AsNoTracking(), request.Page, request.PageSize);

            //if (!request.search.IsNullOrEmpty())

            return data;
        }

        public Customer? Find(int id)
        {
            var entry = _context.Customers.FirstOrDefault(cus => cus.Id == id);
            if (entry != null)
            {
                return new Customer {
                    Id = entry.Id,
                    Name = entry.Name,
                    Email = entry.Email,
                    Phone = entry.Phone,
                    Address = entry.Address,
                    Status = entry.Status
                };
            }
            return null;
        }

        public Customer Create(StoreCustomerRequest customer)
        {
            HashSalt hash = _helper.EncryptPassword(customer.Password);
            var entry = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone ?? "",
                Address = customer.Address ?? "",
                Password = hash.Hash,
                Salt = hash.Salt.ToString(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = customer.Status,
                Gender = customer.Gender
                
            };
            _context.Add(entry);
            _context.SaveChanges();
            return new Customer
            {
                Id = entry.Id,
                Name = entry.Name,
                Email = entry.Email,
                Phone = entry.Phone,
                Address = entry.Address,
            };

        }

        public void Update(int id, UpdateCustomerRequest customer)
        {
            var _customer = _context.Customers.FirstOrDefault(cus => cus.Id == id);
            if (_customer != null) {
                _customer.Name = customer.Name;
                _customer.Email = customer.Email;
                _customer.Phone = customer.Phone ?? "";
                _customer.Address = customer.Address ?? "";
                _customer.Status = customer.Status;
                _customer.Gender = customer.Gender;
                _customer.UpdatedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }

        }
    }
}
