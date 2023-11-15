using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _productsRepo;

        public ProductsController(IProducts productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
           return await _productsRepo.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProductsById(int id)
        {
           return await _productsRepo.GetProductsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products Products)
        {
            return await _productsRepo.PutProducts(id, Products);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products Products)
        {
            return await _productsRepo.PostProducts(Products);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            return await _productsRepo.DeleteProducts(id);
        }
    }
}
