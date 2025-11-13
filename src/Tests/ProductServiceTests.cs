using Moq;
using TallerTest.Domain.Entities;
using TallerTest.Domain.Interfaces;
using TallerTest.Services;

namespace UnitTests;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _productService = new ProductService(_productRepositoryMock.Object);
    }

    [Fact]
    public void GetAll_Should_ReturnAllProducts()
    {
        // Arrange
        var expectedProducts = new List<Product>
            {
                new() { Id = 1, Name = "Test 1", Description = "Test 1", CreatedDate = DateTimeOffset.Now, Price = 10 },
                new() { Id = 2, Name = "Test 2", Description = "Test 2", CreatedDate = DateTimeOffset.Now, Price = 20 },
            };

        _productRepositoryMock
            .Setup(repo => repo.GetAll())
            .Returns(expectedProducts);

        // Act
        var result = _productService.GetAll();

        // Assert
        Assert.Equal(expectedProducts.Count, result.Count);
        Assert.Equal(expectedProducts, result);

        _productRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
    }

    [Fact]
    public void GetById_Should_ReturnProduct()
    {
        // Arrange
        var expectedProduct = new Product { Id = 1, Name = "Product 1", Price = 10 };

        _productRepositoryMock
            .Setup(repo => repo.GetById(1))
            .Returns(expectedProduct);

        // Act
        var result = _productService.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedProduct, result);
        _productRepositoryMock.Verify(repo => repo.GetById(1), Times.Once);
    }

    [Fact]
    public void GetById_Should_ReturnNull_WhenNotFound()
    {
        // Arrange
        _productRepositoryMock
            .Setup(repo => repo.GetById(It.IsAny<int>()))
            .Returns((Product?)null);

        // Act
        var result = _productService.GetById(99);

        // Assert
        Assert.Null(result);
        _productRepositoryMock.Verify(repo => repo.GetById(99), Times.Once);
    }

    [Fact]
    public void Create_Should_CallRepositoryCreate()
    {
        // Arrange
        var newProduct = new Product { Id = 1, Name = "New Product", Price = 50 };

        // Act
        _productService.Create(newProduct);

        // Assert
        _productRepositoryMock.Verify(repo => repo.Create(newProduct), Times.Once);
    }

    [Fact]
    public void Update_Should_CallRepositoryUpdate()
    {
        // Arrange
        var updatedProduct = new Product { Id = 1, Name = "Updated Product", Price = 100 };

        // Act
        _productService.Update(updatedProduct.Id, updatedProduct);

        // Assert
        _productRepositoryMock.Verify(repo => repo.Update(1, updatedProduct), Times.Once);
    }

    [Fact]
    public void Delete_Should_CallRepositoryDelete()
    {
        int id = 1;

        // Act
        _productService.Delete(id);

        // Assert
        _productRepositoryMock.Verify(repo => repo.Delete(id), Times.Once);
    }
}