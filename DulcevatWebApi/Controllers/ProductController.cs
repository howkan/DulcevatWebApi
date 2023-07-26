namespace DulcevatWebApi.Controllers;

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
    public async Task<ActionResult<Product>> GetProducts(Guid id)
    {
        var products = await _context.Products.FindAsync(id);

        if (products == null)
        {
            return NotFound();
        }

        return products;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProducts(Guid id)
    {
        var producs = await _context.Products.FindAsync(id);

        if (producs == null)
        {
            return NotFound();
        }

        _context.Products.Remove(producs);
        await _context.SaveChangesAsync();

        return producs;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducts), new { id = product.ProductID }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducts(Guid id, Product product)
    {
        if (id != product.ProductID)
        {
            return BadRequest();
        }

        var findedProduct = await _context.Products.FirstOrDefaultAsync(s => s.ProductID == id);

        if (findedProduct == null)
        {
            return NotFound();
        }

        findedProduct.ProductName = product.ProductName;
        findedProduct.ProductPrice = product.ProductPrice;
        findedProduct.ProductDescription = product.ProductDescription;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
