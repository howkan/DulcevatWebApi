using DulcevatWebApi.Models;
using DulcevatWebApi.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DulcevatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AplicationContext _context;

        public ProductController(AplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            
            if(products == null)
            {
                return NotFound();
            }
            return products;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProducts(int id)
        {
            var producs = await _context.Products.FindAsync(id);
            if(producs == null)
            {
                return NotFound();
            }
            _context.Products.Remove(producs);
            await _context.SaveChangesAsync();

            return producs;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetProducts", new {id = product.ProductID}, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Product product)
        {
            if(id != product.ProductID)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
