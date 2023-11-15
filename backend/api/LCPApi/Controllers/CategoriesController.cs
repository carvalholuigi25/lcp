using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories _categoriesRepo;

        public CategoriesController(ICategories categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
           return await _categoriesRepo.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategoriesById(int id)
        {
           return await _categoriesRepo.GetCategoriesById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, Categories Categories)
        {
            return await _categoriesRepo.PutCategories(id, Categories);
        }

        [HttpPost]
        public async Task<ActionResult<Categories>> PostCategories(Categories Categories)
        {
            return await _categoriesRepo.PostCategories(Categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            return await _categoriesRepo.DeleteCategories(id);
        }
    }
}
