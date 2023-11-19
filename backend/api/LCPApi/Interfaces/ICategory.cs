using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ICategory {
    Task<ActionResult<IEnumerable<Category>>> GetCategory();
    Task<ActionResult<Category>> GetCategoryById(int id);
    Task<IActionResult> PutCategory(int id, Category Category);
    Task<ActionResult<Category>> PostCategory(Category Category);
    Task<IActionResult> DeleteCategory(int id);
}