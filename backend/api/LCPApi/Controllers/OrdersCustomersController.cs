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
    public class OrdersCustomersController : ControllerBase
    {
        private readonly DBContext _context;

        public OrdersCustomersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/OrdersCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersCustomers>>> GetOrdersCustomers()
        {
          if (_context.OrdersCustomers == null)
          {
              return NotFound();
          }
            return await _context.OrdersCustomers.ToListAsync();
        }

        // GET: api/OrdersCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersCustomers>> GetOrdersCustomers(int id)
        {
          if (_context.OrdersCustomers == null)
          {
              return NotFound();
          }
            var ordersCustomers = await _context.OrdersCustomers.FindAsync(id);

            if (ordersCustomers == null)
            {
                return NotFound();
            }

            return ordersCustomers;
        }

        // PUT: api/OrdersCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersCustomers(int id, OrdersCustomers ordersCustomers)
        {
            if (id != ordersCustomers.OrdersId)
            {
                return BadRequest();
            }

            _context.Entry(ordersCustomers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersCustomersExists(id))
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

        // POST: api/OrdersCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersCustomers>> PostOrdersCustomers(OrdersCustomers ordersCustomers)
        {
          if (_context.OrdersCustomers == null)
          {
              return Problem("Entity set 'DBContext.OrdersCustomers'  is null.");
          }
            _context.OrdersCustomers.Add(ordersCustomers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersCustomers", new { id = ordersCustomers.OrdersId }, ordersCustomers);
        }

        // DELETE: api/OrdersCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersCustomers(int id)
        {
            if (_context.OrdersCustomers == null)
            {
                return NotFound();
            }
            var ordersCustomers = await _context.OrdersCustomers.FindAsync(id);
            if (ordersCustomers == null)
            {
                return NotFound();
            }

            _context.OrdersCustomers.Remove(ordersCustomers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersCustomersExists(int id)
        {
            return (_context.OrdersCustomers?.Any(e => e.OrdersId == id)).GetValueOrDefault();
        }
    }
}
