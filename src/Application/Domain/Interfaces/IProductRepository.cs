using TallerTest.Domain.Entities;

namespace TallerTest.Domain.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product GetById(int id);
    void Create(Product product);
    void Update(int id, Product product);
    void Delete(int id);
}
