using NailWarehouse.Models;

namespace NailWarehouse.Storage.Contracts;

/// <summary>
/// Интерфейс хранилища товаров. Определяет доступ к данным.
/// </summary>
public interface IProductStorage
{
    IReadOnlyCollection<Product> GetAllProducts();
    Product Add(Product product);
    Product? GetProduct(Guid id);
    bool TryEdit(Product product);
    bool TryDelete(Guid id);
}
