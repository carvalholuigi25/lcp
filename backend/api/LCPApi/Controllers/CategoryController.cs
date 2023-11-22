using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "StaffOnly")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryRepo;

        public CategoryController(ICategory categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
           return await _categoryRepo.GetCategory();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
           return await _categoryRepo.GetCategoryById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category Category)
        {
            return await _categoryRepo.PutCategory(id, Category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category Category)
        {
            return await _categoryRepo.PostCategory(Category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return await _categoryRepo.DeleteCategory(id);
        }
    }
}
