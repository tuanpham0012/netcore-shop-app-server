using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAppApi.Data;
using ShopAppApi.Helpers;
using ShopAppApi.Request;
using ShopAppApi.Response;
using Slugify;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace ShopAppApi.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopAppContext _context;
        private readonly IStringHelper _helper;

        public ProductRepository(ShopAppContext context, IStringHelper helper) {
            _context = context;
            _helper = helper;
                }
        public async Task Create(StoreProductRequest product)
        {
            using var transaction = _context.Database.BeginTransaction();

             var entry = new Product
                {
                    Code = _helper.RandomString(24),
                    Name = product.Name,
                    Price = product.Price,
                    Unit = product.Unit,
                    Alias = new SlugHelper().GenerateSlug(product.Name),
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    SupplierId = product.SupplierId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                _context.Add(entry);
                await _context.SaveChangesAsync();

                foreach (var option in product.Options)
                {
                    var _option = new Option
                    {
                        ProductId = entry.Id,
                        Code = option.Code,
                        Name = option.Name,
                        Order = option.Order,
                        Visual = option.Visual,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };
                    _context.Add(_option);
                    await _context.SaveChangesAsync();

                    foreach (var value in option.OptionValues)
                    {
                        var _value = new OptionValue
                        {
                            OptionId = _option.Id,
                            ProductId = entry.Id,
                            Code = value.Code,
                            Label = value.Label,
                            Value = value.Value,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                        };
                        _context.Add(_value);
                        await _context.SaveChangesAsync();
                    }
                }

                foreach (var sku in product.Skus)
                {
                    var _sku = new Sku
                    {
                        ProductId = entry.Id,
                        Name = sku.Name,
                        Price = sku.Price,
                        BarCode = sku.BarCode,
                        Stock = sku.Stock,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };
                    _context.Add(_sku);
                    await _context.SaveChangesAsync();

                    foreach (var variant in sku.Variants)
                    {
                        var optionValue = _context.OptionValues.FirstOrDefault(x => x.Code == variant.Code);
                        if (optionValue != null)
                        {
                            var _variant = new Variant
                            {
                                OptionId = optionValue.OptionId,
                                OptionValueId = optionValue.Id,
                                ProductId = entry.Id,
                                SkuId = _sku.Id,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow,
                            };
                            _context.Add(_variant);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                transaction.Commit();
                //return entry;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product? Find(int Id, List<String>? Includes = null!)
        {
            var query = _context.Products.AsQueryable();
            if (Includes != null)
            {
                foreach (var include in Includes)
                {
                    query = query.Include(include);
                }
            }
            return query.AsNoTracking().SingleOrDefault(x => x.Id == Id);
        }

        public async Task<PaginatedList<Product>> GetAll(ProductRequest request, List<String>? Includes = null!)
        {
            var query = _context.Products.OrderByDescending(x => x.Id).AsQueryable();

            if (Includes != null)
            {
                foreach (var include in Includes)
                {
                    query = query.Include(include);
                }
            }
            return await PaginatedList<Product>.CreateAsync(query.AsNoTracking(), request.Page, request.PageSize);
        }

        public Task Update(int id, Product customer)
        {
            throw new NotImplementedException();
        }
    }
}
