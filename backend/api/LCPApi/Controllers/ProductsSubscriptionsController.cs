using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsSubscriptionsController : ControllerBase
    {
        private readonly IProductsSubscriptions _productssubscriptionsRepo;

        public ProductsSubscriptionsController(IProductsSubscriptions productssubscriptionsRepo)
        {
            _productssubscriptionsRepo = productssubscriptionsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsSubscriptions>>> GetProductsSubscriptions()
        {
           return await _productssubscriptionsRepo.GetProductsSubscriptions();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsSubscriptions>> GetProductsSubscriptionsById(int id)
        {
           return await _productssubscriptionsRepo.GetProductsSubscriptionsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsSubscriptions(int id, ProductsSubscriptions ProductsSubscriptions)
        {
            return await _productssubscriptionsRepo.PutProductsSubscriptions(id, ProductsSubscriptions);
        }

        [HttpPost]
        public async Task<ActionResult<ProductsSubscriptions>> PostProductsSubscriptions(ProductsSubscriptions ProductsSubscriptions)
        {
            return await _productssubscriptionsRepo.PostProductsSubscriptions(ProductsSubscriptions);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsSubscriptions(int id)
        {
            return await _productssubscriptionsRepo.DeleteProductsSubscriptions(id);
        }
    }
}
