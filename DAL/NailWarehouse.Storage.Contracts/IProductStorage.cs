using NailWarehouse.Models;

namespace NailWarehouse.Storage.Contracts;

/// <summary>
/// Интерфейс хранилища товаров. Определяет доступ к данным.
/// </summary>
public interface IProductStorage
{
    /// <summary>
    /// Асинхронно получает коллекцию всех товаров из хранилища.
    /// </summary>
    Task<IReadOnlyCollection<Product>> GetAllProductsAsync();

    /// <summary>
    /// Асинхронно добавляет новый товар в хранилище.
    /// </summary>
    Task<Product> AddAsync(Product product);

    /// <summary>
    /// Асинхронно получает товар по его уникальному идентификатору.
    /// </summary>
    Task<Product?> GetProductAsync(Guid id);

    /// <summary>
    /// Асинхронно пытается обновить существующий товар в хранилище.
    /// </summary>
    Task<bool> TryEditAsync(Product product);

    /// <summary>
    /// Асинхронно пытается удалить товар из хранилища по его уникальному идентификатору.
    /// </summary>
    Task<bool> TryDeleteAsync(Guid id);
}
