using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IProductsSubscriptions {
    Task<ActionResult<IEnumerable<ProductsSubscriptions>>> GetProductsSubscriptions();
    Task<ActionResult<ProductsSubscriptions>> GetProductsSubscriptionsById(int id);
    Task<IActionResult> PutProductsSubscriptions(int id, ProductsSubscriptions ProductsSubscriptions);
    Task<ActionResult<ProductsSubscriptions>> PostProductsSubscriptions(ProductsSubscriptions ProductsSubscriptions);
    Task<IActionResult> DeleteProductsSubscriptions(int id);
}