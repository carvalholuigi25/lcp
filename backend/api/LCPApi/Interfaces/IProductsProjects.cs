using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IProductsProjects {
    Task<ActionResult<IEnumerable<ProductsProjects>>> GetProductsProjects();
    Task<ActionResult<ProductsProjects>> GetProductsProjectsById(int id);
    Task<IActionResult> PutProductsProjects(int id, ProductsProjects ProductsProjects);
    Task<ActionResult<ProductsProjects>> PostProductsProjects(ProductsProjects ProductsProjects);
    Task<IActionResult> DeleteProductsProjects(int id);
}