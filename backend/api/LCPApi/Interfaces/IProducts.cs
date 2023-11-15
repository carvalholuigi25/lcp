using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IProducts {
    Task<ActionResult<IEnumerable<Products>>> GetProducts();
    Task<ActionResult<Products>> GetProductsById(int id);
    Task<IActionResult> PutProducts(int id, Products Products);
    Task<ActionResult<Products>> PostProducts(Products Products);
    Task<IActionResult> DeleteProducts(int id);
}