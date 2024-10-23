using Microsoft.AspNetCore.Mvc;
using ShopAppApi.Data;
using ShopAppApi.Repositories.RepoCustomer;
using ShopAppApi.Request;
using ShopAppApi.Response;

namespace ShopAppApi.Controllers.Admin
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repo;
        public CustomerController(ICustomerRepository repository) {
            _repo = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] CustomerRequest request)
        {
            var entries = await _repo.GetAll(request);
            return Ok(new ResponsePaginatedCollection<Customer>(entries, 201, ""));
        }
        [HttpGet("{Id}")]
        public IActionResult Show(int Id)
        {
            var entry = _repo.Find(Id);

            if (entry != null) {
                try
                {
                    return Ok(new ResponseOne<Customer>(entry));
                }
                catch (Exception ex) {
                    return BadRequest(ex.Message);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Store(StoreCustomerRequest customer) 
        {
            return Ok(_repo.Create(customer));
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]UpdateCustomerRequest customer) 
        {
            //var id = HttpContext.GetRouteValue("id");
        
            _repo.Update(Id, customer);
            return Ok(new { message = "Success" });
        }

        [HttpDelete("{Id}")]
        public IActionResult Destroy(int Id)
        {
            //var id = HttpContext.GetRouteValue("id");

            var isDeleted = _repo.Delete(Id);
            if (isDeleted) {
                return Ok(new { message = "Xoá khách hàng thành công!" });
            }
            return BadRequest();
        }
    }
}
