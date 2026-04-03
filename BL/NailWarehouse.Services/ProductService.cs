using NailWarehouse.Storage.InMemory;

namespace NailWarehouse.Services;
using Models;
using Contracts;

/// <summary>
/// Сервис для работы с товарами.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductStorage storage;
    public ProductService(IProductStorage storage)
    {
        this.storage = storage;
    }

    /// <summary>
    /// Возвращает список всех товаров.
    /// </summary>
    public List<Product> GetAll() => storage.Products;

    /// <summary>
    /// Добавляет новый товар.
    /// </summary>
    public void Add(Product product) => storage.Products.Add(product);

    /// <summary>
    /// Удаляет указанный товар.
    /// </summary>
    public void Remove(Product product) => storage.Products.Remove(product);

    /// <summary>
    /// Рассчитывает и возвращает статистику по товарам.
    /// </summary>
    public (int count, decimal avgPrice, int totalQty, Product? deficit) GetStats()
    {
        var list = storage.Products;
        if (!list.Any())
        {
            return (0, 0, 0, null);
        }
        return (
            list.Count,
            list.Average(p => p.Price),
            list.Sum(p => p.Quantity),
            list.OrderBy(p => p.Quantity).FirstOrDefault()
        );
    }
}
