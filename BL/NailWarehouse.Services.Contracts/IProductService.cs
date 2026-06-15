using NailWarehouse.Models;
namespace NailWarehouse.Services.Contracts;

/// <summary>
/// Интерфейс сервиса для работы с товарами. Описывает бизнес-логику склада.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Возвращает список всех товаров.
    /// </summary>
    Task<List<Product>> GetAllAsync();

    /// <summary>
    /// Добавляет новый товар.
    /// </summary>
   Task AddAsync(Product product);

    /// <summary>
    /// Удаляет указанный товар.
    /// </summary>
    Task RemoveAsync(Product product);

    /// <summary>
    /// Асинхронно пытается обновить данные существующего товара.
    /// </summary>
    Task<bool> TryEditAsync(Product product);

    /// <summary>
    /// Рассчитывает и возвращает статистику по товарам.
    /// </summary>
    Task<(int count, decimal avgPrice, int totalQty, Product? deficit)> GetStatsAsync();

    /// <summary>
    /// Асинхронно находит и возвращает товар по его уникальному идентификатору.
    /// </summary>
    Task<Product?> GetByIdAsync(Guid id);
}
