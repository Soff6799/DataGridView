using NailWarehouse.Models;
using NailWarehouse.Storage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace NailWarehouse.Storage.MsSql;

/// <summary>
/// Реализация хранилища данных товаров для SQL Server с использованием Entity Framework Core.
/// Все операции выполняются асинхронно.
/// </summary>
public class MsSqlStorage: IProductStorage
{
    /// <summary>
    /// Асинхронно получает коллекцию всех товаров из базы данных.
    /// </summary>
    public async Task<IReadOnlyCollection<Product>> GetAllProductsAsync()
    {
        using var db = new ClassMagazineContext();
        return await db.Products
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    /// <summary>
    /// Асинхронно добавляет новый товар в базу данных.
    /// </summary>
    public async Task<Product> AddAsync(Product product)
    {
        using var db = new ClassMagazineContext();
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return product;
    }

    /// <summary>
    /// Асинхронно получает товар по его уникальному идентификатору из базы данных.
    /// </summary>
    public async Task<Product?> GetProductAsync(Guid id)
    {
        using var db = new ClassMagazineContext();
        return await db.Products
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Асинхронно пытается обновить существующий товар в базе данных.
    /// </summary>
    async Task<bool> IProductStorage.TryEditAsync(Product product)
    {
        using var db = new ClassMagazineContext();
        Product? item = await db.Products
            .FirstOrDefaultAsync(x => x.Id == product.Id);
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

        db.Products.Update(item);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Асинхронно пытается удалить товар из базы данных по его уникальному идентификатору.
    /// </summary>
    public async Task<bool> TryDeleteAsync(Guid id)
    {
        using var db = new ClassMagazineContext();
        var item = await db.Products
            .FirstOrDefaultAsync(x => x.Id == id);
        if (item == null)
        {
            return false;
        }
        db.Products.Remove(item);
        await db.SaveChangesAsync();
        return true;
    }
}
