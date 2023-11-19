using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IProduct {
    Task<ActionResult<IEnumerable<Product>>> GetProduct();
    Task<ActionResult<Product>> GetProductById(int id);
    Task<IActionResult> PutProduct(int id, Product Product);
    Task<ActionResult<Product>> PostProduct(Product Product);
    Task<IActionResult> DeleteProduct(int id);
    Task<ActionResult<IEnumerable<ProductProject>>> GetProductProject();
    Task<ActionResult<ProductProject>> GetProductProjectById(int id);
    Task<IActionResult> PutProductProject(int id, ProductProject ProductProject);
    Task<ActionResult<ProductProject>> PostProductProject(ProductProject ProductProject);
    Task<IActionResult> DeleteProductProject(int id);
    Task<ActionResult<IEnumerable<ProductSubscription>>> GetProductSubscription();
    Task<ActionResult<ProductSubscription>> GetProductSubscriptionById(int id);
    Task<IActionResult> PutProductSubscription(int id, ProductSubscription ProductSubscription);
    Task<ActionResult<ProductSubscription>> PostProductSubscription(ProductSubscription ProductSubscription);
    Task<IActionResult> DeleteProductSubscription(int id);
}