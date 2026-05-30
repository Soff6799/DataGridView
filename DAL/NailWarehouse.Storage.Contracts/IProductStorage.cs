using NailWarehouse.Models;

namespace NailWarehouse.Storage.Contracts;

/// <summary>
/// Интерфейс хранилища товаров. Определяет доступ к данным.
/// </summary>
public interface IProductStorage
{
    Task<IReadOnlyCollection<Product>> GetAllProductsAsync();
    Task<Product> AddAsync(Product product);
    Task<Product?> GetProductAsync(Guid id);
    Task<bool> TryEditAsync(Product product);
    Task<bool> TryDeleteAsync(Guid id);
}
