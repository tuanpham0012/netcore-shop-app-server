using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAppApi.Data;
using ShopAppApi.Repositories.Products;
using ShopAppApi.Response;

namespace ShopAppApi.Controllers.Admin
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repository)
        {
            _repo = repository;
        }
        // GET: CategoryController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var entries = await _repo.GetAll();
            return Ok(new ResponseCollection<Category>(entries));
        }
    }
}
