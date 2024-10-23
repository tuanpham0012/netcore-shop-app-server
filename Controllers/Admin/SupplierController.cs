using Microsoft.AspNetCore.Mvc;
using ShopAppApi.Data;
using ShopAppApi.Repositories.Products;
using ShopAppApi.Response;

namespace ShopAppApi.Controllers.Admin
{
    [ApiController]
    [Route("suppliers")]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _repo;

        public SupplierController(ISupplierRepository repository) { _repo = repository; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var entries = await _repo.GetAll();
            return Ok(new ResponseCollection<Supplier>(entries));
        }
    }
}
