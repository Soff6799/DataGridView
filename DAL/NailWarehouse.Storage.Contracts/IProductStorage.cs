using NailWarehouse.Models;

namespace NailWarehouse.Storage.InMemory;

/// <summary>
/// Интерфейс хранилища товаров. Определяет доступ к данным.
/// </summary>
public interface IProductStorage
{
    List<Product> Products { get; }
}
