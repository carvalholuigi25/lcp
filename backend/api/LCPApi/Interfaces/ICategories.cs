using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ICategories {
    Task<ActionResult<IEnumerable<Categories>>> GetCategories();
    Task<ActionResult<Categories>> GetCategoriesById(int id);
    Task<IActionResult> PutCategories(int id, Categories Categories);
    Task<ActionResult<Categories>> PostCategories(Categories Categories);
    Task<IActionResult> DeleteCategories(int id);
}