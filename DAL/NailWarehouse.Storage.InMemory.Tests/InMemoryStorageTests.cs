using FluentAssertions;
using NailWarehouse.Models;

namespace NailWarehouse.Storage.InMemory.Tests;

/// <summary>
/// Тесты для NailWarehouse.Storage.InMemory
/// </summary>
public class InMemoryStorageTests
{
    /// <summary>
    /// Тестирует состояние хранилища по умолчанию, гарантирует наличие набора данных при старте приложения
    /// </summary>
    [Fact]
    public void ConstructorShouldInitializeWithFourProducts()
    {
        // Arrange
        var storage = new InMemoryProductStorage();

        // Act
        var products = storage.Products;

        // Assert
        products.Should().NotBeNull();
        products.Should().HaveCount(4);
        products.Should().Contain(p => p.Name == "Гвоздь оцинкованный");
    }

    /// <summary>
    /// Проверяет целостность данных, не должен содержать дубликатов по названию
    /// </summary>
    [Fact]
    public void ConstructorShouldNotHaveDuplicateProductNames()
    {
        // Arrange
        var storage = new InMemoryProductStorage();

        // Act
        var names = storage.Products.Select(p => p.Name);

        // Assert
        names.Should().OnlyHaveUniqueItems();
    }

    /// <summary>
    /// Подтверждает, что добавление нового объекта product увеличивает общее количество элементов в списке хранилища на единицу
    /// </summary>
    [Fact]
    public void AddShouldIncreaseProductsCount()
    {
        // Arrange
        var storage = new InMemoryProductStorage();
        var newProduct = new Product
        {
            Name = "Новый гвоздь",
            Quantity = 10
        };

        // Act
        storage.Products.Add(newProduct);

        // Assert
        storage.Products.Should().HaveCount(5);
        storage.Products.Should().Contain(newProduct);
    }

    /// <summary>
    /// Тестирует функцию поиска, убеждается что при запросе существующего товара по имени возвращается правильный объект product
    /// </summary>
    [Fact]
    public void GetProductWhenExistsShouldReturnCorrectProduct()
    {
        // Arrange
        var storage = new InMemoryProductStorage();
        const string targetName = "Гвоздь оцинкованный";

        // Act
        var product = storage.Products.FirstOrDefault(p => p.Name == targetName);

        // Assert
        product.Should().NotBeNull();
        product.Material.Should().Be("Сталь");
    }

    /// <summary>
    /// Проверяет надежность функции поиска, подтверждает что запрос несуществующего товара возвращает null
    /// </summary>
    [Fact]
    public void GetProductWhenNotExistsShouldReturnNull()
    {
        // Arrange
        var storage = new InMemoryProductStorage();
        const string nonExistentName = "Несуществующий гвоздь";

        // Act
        var product = storage.Products.FirstOrDefault(p => p.Name == nonExistentName);

        // Assert
        product.Should().BeNull();
    }

    /// <summary>
    /// Проверяет возможность взаимодействия данными, удаление товара из списка products должно уменьшать размер коллекции
    /// </summary>
    [Fact]
    public void ProductsShouldAllowManualRemoval()
    {
        // Arrange
        var storage = new InMemoryProductStorage();
        var initialCount = storage.Products.Count;
        var productToRemove = storage.Products.First();

        // Act
        storage.Products.Remove(productToRemove);

        // Assert
        storage.Products.Should().HaveCount(initialCount - 1);
        storage.Products.Should().NotContain(productToRemove);
    }

    /// <summary>
    /// Проверяет, что при изменении свойств объекта, полученного из списка, автоматически отражается на состоянии данных в самом хранилище
    /// </summary>
    [Fact]
    public void ProductsShouldMaintainReferentialIntegrity()
    {
        // Arrange
        var storage = new InMemoryProductStorage();
        var productToModify = storage.Products.First();
        var oldName = productToModify.Name;
        const string newName = "Новое_Тестовое_Имя";

        // Act
        productToModify.Name = newName;

        // Assert
        storage.Products.First().Name.Should().Be(newName);
        storage.Products.First().Name.Should().NotBe(oldName);
    }
}
