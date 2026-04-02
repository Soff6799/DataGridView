namespace NailWarehouse.Storage.InMemory;
using Models;
using Contracts; 

/// <summary>
/// Реализация хранилища данных в оперативной памяти (In-Memory).
/// </summary>
public class ProductStorage : IProductStorage
{
    /// <summary>
    /// Список товаров, хранящийся в памяти приложения.
    /// </summary>
    public List<Product> Products { get; } = new();

    /// <summary>
    /// Инициализирует сервис и загружает начальные товары.
    /// </summary>
    public ProductStorage()
    {
        Products.Add(new Product("Гвоздь оцинкованный", "3.0x70", "Сталь", 100, 20, 0.85m));
        Products.Add(new Product("Гвоздь кровельный", "2.5x30", "Медь", 90, 10, 12.50m));
        Products.Add(new Product("Гвоздь строительный", "4.0x100", "Железо", 45, 10, 0.50m));
        Products.Add(new Product("Гвоздь декоративный", "1.6x20", "Хром", 75, 20, 3.20m));
    }
}