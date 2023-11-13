using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsSubscriptionsController : ControllerBase
    {
        private readonly DBContext _context;

        public ProductsSubscriptionsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/ProductsSubscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsSubscriptions>>> GetProductsSubscriptions()
        {
          if (_context.ProductsSubscriptions == null)
          {
              return NotFound();
          }
            return await _context.ProductsSubscriptions.ToListAsync();
        }

        // GET: api/ProductsSubscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsSubscriptions>> GetProductsSubscriptions(int id)
        {
          if (_context.ProductsSubscriptions == null)
          {
              return NotFound();
          }
            var productsSubscriptions = await _context.ProductsSubscriptions.FindAsync(id);

            if (productsSubscriptions == null)
            {
                return NotFound();
            }

            return productsSubscriptions;
        }

        // PUT: api/ProductsSubscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsSubscriptions(int id, ProductsSubscriptions productsSubscriptions)
        {
            if (id != productsSubscriptions.ProductsId)
            {
                return BadRequest();
            }

            _context.Entry(productsSubscriptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsSubscriptionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductsSubscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsSubscriptions>> PostProductsSubscriptions(ProductsSubscriptions productsSubscriptions)
        {
          if (_context.ProductsSubscriptions == null)
          {
              return Problem("Entity set 'DBContext.ProductsSubscriptions'  is null.");
          }
            _context.ProductsSubscriptions.Add(productsSubscriptions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsSubscriptions", new { id = productsSubscriptions.ProductsId }, productsSubscriptions);
        }

        // DELETE: api/ProductsSubscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsSubscriptions(int id)
        {
            if (_context.ProductsSubscriptions == null)
            {
                return NotFound();
            }
            var productsSubscriptions = await _context.ProductsSubscriptions.FindAsync(id);
            if (productsSubscriptions == null)
            {
                return NotFound();
            }

            _context.ProductsSubscriptions.Remove(productsSubscriptions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsSubscriptionsExists(int id)
        {
            return (_context.ProductsSubscriptions?.Any(e => e.ProductsId == id)).GetValueOrDefault();
        }
    }
}
