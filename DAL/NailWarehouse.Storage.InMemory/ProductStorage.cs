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

    public  IReadOnlyCollection<Product> GetAllProducts() => Products.AsReadOnly();

    public Product Add(Product product)
    {
        Products.Add(product);
        return product;
    }
    public Product? GetProduct(Guid id) => Products.FirstOrDefault(x => x.Id == id);

    public bool TryEdit(Product product)
    {
        var item = Products.FirstOrDefault(x => x.Id == product.Id);
        if (item == null)
        {
            return false;
        }
        item.Name = product.Name;
        item.Size =  product.Size;
        item.Material = product.Material;
        item.Quantity =  product.Quantity;
        item.MinQuantity = product.MinQuantity;
        item.Price = product.Price;
        return true;
    }

    public bool TryDelete(Guid id)
    {
        var item = Products.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return false;
        }
        Products.Remove(item);
        return true;
    }

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
