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
    public class ProductsProjectsController : ControllerBase
    {
        private readonly DBContext _context;

        public ProductsProjectsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/ProductsProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsProjects>>> GetProductsProjects()
        {
          if (_context.ProductsProjects == null)
          {
              return NotFound();
          }
            return await _context.ProductsProjects.ToListAsync();
        }

        // GET: api/ProductsProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsProjects>> GetProductsProjects(int id)
        {
          if (_context.ProductsProjects == null)
          {
              return NotFound();
          }
            var productsProjects = await _context.ProductsProjects.FindAsync(id);

            if (productsProjects == null)
            {
                return NotFound();
            }

            return productsProjects;
        }

        // PUT: api/ProductsProjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsProjects(int id, ProductsProjects productsProjects)
        {
            if (id != productsProjects.ProductsId)
            {
                return BadRequest();
            }

            _context.Entry(productsProjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsProjectsExists(id))
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

        // POST: api/ProductsProjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsProjects>> PostProductsProjects(ProductsProjects productsProjects)
        {
          if (_context.ProductsProjects == null)
          {
              return Problem("Entity set 'DBContext.ProductsProjects'  is null.");
          }
            _context.ProductsProjects.Add(productsProjects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsProjects", new { id = productsProjects.ProductsId }, productsProjects);
        }

        // DELETE: api/ProductsProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsProjects(int id)
        {
            if (_context.ProductsProjects == null)
            {
                return NotFound();
            }
            var productsProjects = await _context.ProductsProjects.FindAsync(id);
            if (productsProjects == null)
            {
                return NotFound();
            }

            _context.ProductsProjects.Remove(productsProjects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsProjectsExists(int id)
        {
            return (_context.ProductsProjects?.Any(e => e.ProductsId == id)).GetValueOrDefault();
        }
    }
}
