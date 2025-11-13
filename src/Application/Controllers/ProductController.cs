using Microsoft.AspNetCore.Mvc;
using TallerTest.Domain.Entities;
using TallerTest.Domain.Interfaces;

namespace TallerTest.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public ActionResult Post(Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _productService.Create(product);

        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingProduct = _productService.GetById(id);
        if (existingProduct == null)
            return NotFound();

        _productService.Update(id, product);

        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var product = _productService.GetById(id);
        if (product == null)
            return NotFound();

        _productService.Delete(id);

        return NoContent();
    }
}
