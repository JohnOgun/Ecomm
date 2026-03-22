using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Core.Interfaces; //alows use of the controllerBase 
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

public class ProductsController(IProductRepository repo) : ControllerBase
// This creates a controller class named ProductsController.
// It inherits from ControllerBase, which gives it API-related functionality.
{
   
    [HttpGet]
    // This means this method will respond to HTTP GET requests.

    public async Task<ActionResult<IReadOnlyList<Product>>> 
        GetProducts(string? brand, string? type,string? sort)
    {
        return Ok(await repo.GetProductsAsync(brand, type,sort));
    }
    // "async" means the method runs asynchronously
    // "Task<>" means it will return something asynchronously.



    [HttpGet("{id:int}")]
    // This means this method will respond to HTTP GET requests.

    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await repo.GetProductIdAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]

    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.AddProduct(product);

        if (await repo.SaveChangesAsync())
        {

            return CreatedAtAction("GetProduct", new { id = product.ID }, product);
        }

        return BadRequest("Problem making product");
    }

        [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (product.ID != id || !ProductExist(id))
            return BadRequest("Cannot update this product");

        repo.UpdateProduct(product);         

        if  (await repo.SaveChangesAsync() )
        {

            return NoContent();
        }

        return BadRequest("Problem updating the product");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await repo.GetProductIdAsync(id);

        if (product == null) return NotFound();

        repo.DeleteProduct(product);

        if (await repo.SaveChangesAsync())
        {

            return NoContent();
        }

        return BadRequest("Problem deleting Product");
        
    }

    [HttpGet("Brands")]

    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        return Ok(await repo.GetBrandsAsync());
    }


    [HttpGet("Types")]

    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        return Ok(await repo.GetTypesAsync());
    }

    private bool ProductExist(int id)
    {
        return repo.ProductExists(id);
            
    }

}