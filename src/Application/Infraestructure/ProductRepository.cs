using TallerTest.Domain.Entities;
using TallerTest.Domain.Interfaces;

namespace TallerTest.Infraestructure;

public class ProductRepository : IProductRepository
{
    protected static List<Product> Products = [
        new Product() { Id = 1, Name = "Test 1", Description = "Test 1", CreatedDate = DateTimeOffset.Now, Price = 10 },
        new Product() { Id = 2, Name = "Test 2", Description = "Test 2", CreatedDate = DateTimeOffset.Now, Price = 20 },
    ];

    public List<Product> GetAll()
    {
        return Products;
    }

    public Product GetById(int id)
    {
        return Products.FirstOrDefault(x => x.Id == id);
    }

    public void Create(Product product)
    {
        product.CreatedDate = DateTimeOffset.Now;

        Products.Add(product);
    }

    public void Delete(int id)
    {
        var product = GetById(id);
        Products.Remove(product);
    }

    public void Update(int id, Product product)
    {
        var oldProduct = GetById(id);
        Products.Remove(oldProduct);

        Products.Add(product);
    }
}
