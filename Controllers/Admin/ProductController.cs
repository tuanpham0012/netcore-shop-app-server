using Microsoft.AspNetCore.Mvc;
using ShopAppApi.Data;
using ShopAppApi.Repositories.Products;

namespace ShopAppApi.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo) { _repo = repo; }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Store(StoreProductRequest product)
        {
            var entry = await _repo.Create(product);
            return Ok("success");
        }
    }
}
