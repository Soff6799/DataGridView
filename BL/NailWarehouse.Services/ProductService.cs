using NailWarehouse.Storage.Contracts;

namespace NailWarehouse.Services;
using Models;
using Contracts;

/// <summary>
/// Предоставляет бизнес-логику для работы с товарами, используя асинхронные операции.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductStorage storage;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ProductService"/>.
    /// </summary>
    public ProductService(IProductStorage storage)
    {
        this.storage = storage;
    }

    /// <summary>
    /// Возвращает список всех товаров.
    /// </summary>
    public async Task<List<Product>> GetAllAsync()
    {
        var products = await storage.GetAllProductsAsync();
        return products.ToList();
    }

    /// <summary>
    /// Добавляет новый товар.
    /// </summary>
    public async Task AddAsync(Product product) => await storage.AddAsync(product);

    /// <summary>
    /// Удаляет указанный товар.
    /// </summary>
    public async Task RemoveAsync(Product product) => await storage.TryDeleteAsync(product.Id);

    /// <summary>
    /// Рассчитывает и возвращает статистику по товарам.
    /// </summary>
    public async Task<(int count, decimal avgPrice, int totalQty, Product? deficit)> GetStatsAsync()
    {
        var list = await storage.GetAllProductsAsync();
        if (list.Count == 0)
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
