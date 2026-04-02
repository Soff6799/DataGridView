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
    List<Product> GetAll();

    /// <summary>
    /// Добавляет новый товар.
    /// </summary>
    void Add(Product product);

    /// <summary>
    /// Удаляет указанный товар.
    /// </summary>
    void Remove(Product product);

    /// <summary>
    /// Рассчитывает и возвращает статистику по товарам.
    /// </summary>
    (int count, decimal avgPrice, int totalQty, Product? deficit) GetStats();
}