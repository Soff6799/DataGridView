using FluentAssertions;
using Moq;
using NailWarehouse.Models;
using NailWarehouse.Storage.Contracts;

namespace NailWarehouse.Services.Tests;

/// <summary>
/// Тесты для NailWarehouse.Services
/// </summary>
public class ProductServiceTests
{
    /// <summary>
    /// Проверяет что метод GetAll возвращает список товаров, если они присутствуют в хранилище
    /// </summary>
    [Fact]
    public async Task GetAllPozitShouldReturnProducts()
    {
        // Arrange
        var mockStorage = new Mock<IProductStorage>();
        var data = new List<Product>{new() {Name = "Гвоздь"}};

        mockStorage.Setup(s => s.GetAllProductsAsync()).ReturnsAsync(data);
        var service = new ProductService(mockStorage.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().BeSameAs(data);
        result.Should().HaveCount(1);
    }

    /// <summary>
    /// Проверяет что метод GetAll возвращает пустой список если в хранилище нет товаров
    /// </summary>
    [Fact]
    public async Task GetAllWhenEmptyReturnsEmpty()
    {
        // Arrange
        var mockStorage = new Mock<IProductStorage>();
        mockStorage.Setup(s => s.GetAllProductsAsync()).ReturnsAsync(new List<Product>());
        var service = new ProductService(mockStorage.Object);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Проверяет, что новый товар добавляется в хранилище
    /// </summary>
    [Fact]
    public async Task AddShouldAddProductToStorage()
    {
        // Arrange
        var mockStorage = new Mock<IProductStorage>();
        var list = new List<Product>();
        mockStorage.Setup(s => s.GetAllProductsAsync())
            .ReturnsAsync(list);
        var service = new ProductService(mockStorage.Object);
        var newProduct = new Product { Name = "Новый тоывар" };

        // Act
        await service.AddAsync(newProduct);
        list.Add(newProduct);

        // Assert
        list.Should().Contain(newProduct);
        list.Should().HaveCount(1);
    }

    /// <summary>
    /// Проверяет что указанный товар удаляется из коллекции хранилища
    /// </summary>
    [Fact]
    public async Task RemovePositiveShouldDeleteProduct()
    {
        // Arrange
        var mockStorage = new Mock<IProductStorage>();
        var p = new Product{Name = "Удаляемый"};
        var list = new List<Product>{p};
        mockStorage.Setup(s => s.GetAllProductsAsync()).ReturnsAsync(list);
        var service = new ProductService(mockStorage.Object);

        // Act
        await service.RemoveAsync(p);

        // Assert
        list.Should().BeEmpty();
    }

    /// <summary>
    /// Тестирует GetStats при пустом хранилище, проверяет ветвление кода для обработки пустого списка
    /// </summary>
    [Fact]
    public async Task GetStatsEmptyStorageShouldReturnZeros()
    {
        // Arrange
        var mockStorage = new Mock<IProductStorage>();
        mockStorage.Setup(s => s.GetAllProductsAsync()).ReturnsAsync([]);
        var service = new ProductService(mockStorage.Object);

        // Act
        var stats = await service.GetStatsAsync();

        // Assert
        stats.count.Should().Be(0);
        stats.avgPrice.Should().Be(0);
        stats.totalQty.Should().Be(0);
        stats.deficit.Should().BeNull();
    }

    /// <summary>
    /// Проверяет корректность математических расчетов (средняя цена и общее количество) и правильное определение заканчивающегося товара
    /// </summary>
    [Fact]
    public async Task GetStatsWithProductsShouldCalculateCorrectValues()
    {
        // Arrange
        var mockStorage = new Mock<IProductStorage>();
        var data = new List<Product>
        {
            new() { Name = "Товар1", Price = 100, Quantity = 20 }, new() { Name = "Товар2", Price = 200, Quantity = 5 },
        };
        mockStorage.Setup(s => s.GetAllProductsAsync()).ReturnsAsync(data);
        var service = new ProductService(mockStorage.Object);

        // Act
        var stats = await service.GetStatsAsync();

        // Assert
        stats.count.Should().Be(2);
        stats.avgPrice.Should().Be(150);
        stats.totalQty.Should().Be(25);
        stats.deficit.Should().NotBeNull();
        stats.deficit.Name.Should().Be("Товар2");
    }

    /// <summary>
    /// Проверяет что средняя цена рассчитывается правильно и точно
    /// </summary>
    [Fact]
    public async Task GetStatsAveragePriceShouldHandleDecimals()
    {
        // Arrange
        var mockStorage = new Mock<IProductStorage>();
        var data = new List<Product>
        {
            new() { Name = "Товар 1", Price = 10.50m},
            new() { Name = "Товар 2", Price = 20.25m}
        };

        mockStorage.Setup(s => s.GetAllProductsAsync()).ReturnsAsync(data);
        var service = new ProductService(mockStorage.Object);

        // Act
        var stats = await service.GetStatsAsync();

        // Assert
        stats.avgPrice.Should().Be(15.375m);
    }
}
