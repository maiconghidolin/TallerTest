using TallerTest.Domain.Entities;

namespace TallerTest.Domain.Interfaces;

public interface IProductService
{
    List<Product> GetAll();
    Product GetById(int id);
    void Create(Product product);
    void Update(int id, Product product);
    void Delete(int id);
}
