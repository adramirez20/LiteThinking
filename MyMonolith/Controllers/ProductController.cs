using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

[ApiController]

[Route("api/products")]

public class ProductController : ControllerBase

{

    private readonly StoreContext _context;

    public ProductController(StoreContext context) => _context = context;

    [HttpGet]

    public IActionResult GetProducts()

    {

        var products = _context.Products.ToList();

        return Ok(products);

    }

    [HttpPost]

    public IActionResult AddProduct([FromBody] Product product)

    {

        _context.Products.Add(product);

        _context.SaveChanges();

        return CreatedAtAction (nameof (GetProducts),new {id = product.Id}, product);

    }

}