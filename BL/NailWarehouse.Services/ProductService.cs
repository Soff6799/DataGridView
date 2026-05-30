using NailWarehouse.Storage.Contracts;

namespace NailWarehouse.Services;
using NailWarehouse.Models;
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
    public List<Product> GetAll() => storage.GetAllProducts().ToList();

    /// <summary>
    /// Добавляет новый товар.
    /// </summary>
    public void Add(Product product) => storage.Add(product);

    /// <summary>
    /// Удаляет указанный товар.
    /// </summary>
    public void Remove(Product product) => storage.TryDelete(product.Id);

    /// <summary>
    /// Рассчитывает и возвращает статистику по товарам.
    /// </summary>
    public (int count, decimal avgPrice, int totalQty, Product? deficit) GetStats()
    {
        var list = storage.GetAllProducts();
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
