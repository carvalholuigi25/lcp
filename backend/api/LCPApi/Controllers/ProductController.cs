using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepo;

        public ProductController(IProduct productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
           return await _productRepo.GetProduct();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
           return await _productRepo.GetProductById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {
            return await _productRepo.PutProduct(id, Product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product)
        {
            return await _productRepo.PostProduct(Product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return await _productRepo.DeleteProduct(id);
        }

        [HttpGet("project")]
        public async Task<ActionResult<IEnumerable<ProductProject>>> GetProductProject()
        {
           return await _productRepo.GetProductProject();
        }

        [HttpGet("project/{id}")]
        public async Task<ActionResult<ProductProject>> GetProductProjectById(int id)
        {
           return await _productRepo.GetProductProjectById(id);
        }

        [HttpPut("project/{id}")]
        public async Task<IActionResult> PutProductProject(int id, ProductProject ProductProject)
        {
            return await _productRepo.PutProductProject(id, ProductProject);
        }

        [HttpPost("project")]
        public async Task<ActionResult<ProductProject>> PostProductProject(ProductProject ProductProject)
        {
            return await _productRepo.PostProductProject(ProductProject);
        }

        [HttpDelete("project/{id}")]
        public async Task<IActionResult> DeleteProductProject(int id)
        {
            return await _productRepo.DeleteProductProject(id);
        }

        [HttpGet("subscription")]
        public async Task<ActionResult<IEnumerable<ProductSubscription>>> GetProductSubscription()
        {
           return await _productRepo.GetProductSubscription();
        }

        [HttpGet("subscription/{id}")]
        public async Task<ActionResult<ProductSubscription>> GetProductSubscriptionById(int id)
        {
           return await _productRepo.GetProductSubscriptionById(id);
        }

        [HttpPut("subscription/{id}")]
        public async Task<IActionResult> PutProductSubscription(int id, ProductSubscription ProductSubscription)
        {
            return await _productRepo.PutProductSubscription(id, ProductSubscription);
        }

        [HttpPost("subscription")]
        public async Task<ActionResult<ProductSubscription>> PostProductSubscription(ProductSubscription ProductSubscription)
        {
            return await _productRepo.PostProductSubscription(ProductSubscription);
        }

        [HttpDelete("subscription/{id}")]
        public async Task<IActionResult> DeleteProductSubscription(int id)
        {
            return await _productRepo.DeleteProductSubscription(id);
        }
    }
}
