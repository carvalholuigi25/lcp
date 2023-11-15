using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsProjectsController : ControllerBase
    {
        private readonly IProductsProjects _productsprojectsRepo;

        public ProductsProjectsController(IProductsProjects productsprojectsRepo)
        {
            _productsprojectsRepo = productsprojectsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsProjects>>> GetProductsProjects()
        {
           return await _productsprojectsRepo.GetProductsProjects();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsProjects>> GetProductsProjectsById(int id)
        {
           return await _productsprojectsRepo.GetProductsProjectsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsProjects(int id, ProductsProjects ProductsProjects)
        {
            return await _productsprojectsRepo.PutProductsProjects(id, ProductsProjects);
        }

        [HttpPost]
        public async Task<ActionResult<ProductsProjects>> PostProductsProjects(ProductsProjects ProductsProjects)
        {
            return await _productsprojectsRepo.PostProductsProjects(ProductsProjects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsProjects(int id)
        {
            return await _productsprojectsRepo.DeleteProductsProjects(id);
        }
    }
}
