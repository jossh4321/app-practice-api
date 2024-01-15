using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Service;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductService service;
        
        public ProductController()
        {
            service = new ProductService();
        }

        [HttpGet()]
        public IActionResult GetAllProducts()
        {
            return Ok(service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            return Ok(service.GetProduct(id));
        }
    }
}
