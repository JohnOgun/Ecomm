using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets; //alows use of the controllerBase 
namespace API.Controllers;
// This organizes the code into a group called "API.Controllers".
// It helps keep the project structured and clean.

[ApiController]
// This tells ASP.NET that this class is an API controller.
// It enables automatic validation and helpful API features.

[Route("api/[controller]")]
// This sets the URL route for this controller.
// [controller] automatically becomes "products"
// So the route becomes: api/products

public class ProductsController : ControllerBase
// This creates a controller class named ProductsController.
// It inherits from ControllerBase, which gives it API-related functionality.
{
    public readonly StoreContext context;

    public ProductsController(StoreContext context)
    {
        this.context = context;
    }


    [HttpGet]
    // This means this method will respond to HTTP GET requests.

    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await context.Products.ToListAsync();
    }
    // "async" means the method runs asynchronously
    // "Task<>" means it will return something asynchronously.



    [HttpGet("{id:int}")]
    // This means this method will respond to HTTP GET requests.

    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]

    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        context.Products.Add(product);

        await context.SaveChangesAsync();

        return product;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (product.ID != id || !ProductExist(id))
            return BadRequest("Cannot update this product");

        context.Entry(product).State = EntityState.Modified;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null) return NotFound();

        context.Products.Remove(product);


        await context.SaveChangesAsync();

        return NoContent();
        
    }

    private bool ProductExist(int id)
    {
        return context.Products.Any(x => x.ID == id);
    }

}