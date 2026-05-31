namespace NailWarehouse.Storage.InMemory;
using NailWarehouse.Models;
using NailWarehouse.Storage.Contracts;

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
    /// Асинхронно получает коллекцию всех товаров из хранилища.
    /// </summary>
    public Task<IReadOnlyCollection<Product>> GetAllProductsAsync()
    {
        IReadOnlyCollection<Product> readOnlyList = Products.AsReadOnly();
        return Task.FromResult(readOnlyList);
    }

    /// <summary>
    /// Асинхронно добавляет новый товар в хранилище.
    /// </summary>
    public Task<Product> AddAsync(Product product)
    {
        Products.Add(product);
        return Task.FromResult(product);
    }

    /// <summary>
    /// Асинхронно получает товар по его уникальному идентификатору.
    /// </summary>
    public Task<Product?> GetProductAsync(Guid id)
    {
        var product = Products.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(product);
    }

    /// <summary>
    /// Асинхронно получает товар по его уникальному идентификатору.
    /// </summary>
    public Task<bool> TryEditAsync(Product product)
    {
        var item = Products.FirstOrDefault(x => x.Id == product.Id);
        if (item == null)
        {
            return Task.FromResult(false);
        }
        item.Name = product.Name;
        item.Size =  product.Size;
        item.Material = product.Material;
        item.Quantity =  product.Quantity;
        item.MinQuantity = product.MinQuantity;
        item.Price = product.Price;
        return Task.FromResult(true);
    }

    /// <summary>
    /// Асинхронно получает товар по его уникальному идентификатору.
    /// </summary>
    public Task<bool> TryDeleteAsync(Guid id)
    {
        var item = Products.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return Task.FromResult(false);
        }
        Products.Remove(item);
        return Task.FromResult(true);
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ProductStorage"/>
    /// и загружает начальные товары.
    /// </summary>
    public ProductStorage()
    {
        Products.Add(new Product("Гвоздь оцинкованный", "3.0x70",
            "Сталь", 100, 20, 0.85m));
        Products.Add(new Product("Гвоздь кровельный", "2.5x30",
            "Медь", 90, 10, 12.50m));
        Products.Add(new Product("Гвоздь строительный", "4.0x100",
            "Железо", 45, 10, 0.50m));
        Products.Add(new Product("Гвоздь декоративный", "1.6x20",
            "Хром", 75, 20, 3.20m));
    }
}
