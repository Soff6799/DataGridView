using NailWarehouse.Models;
using NailWarehouse.Storage.Contracts;
namespace NailWarehouse.Storage.Db;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductStorage
{
    private readonly IReader reader;
    private readonly IWriter writer;

    public ProductRepository(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    async Task<IReadOnlyCollection<Product>> IProductStorage.GetAllProductsAsync()
    {
        return await reader.Read<Product>()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    async Task<Product> IProductStorage.AddAsync(Product product)
    {
        writer.Add(product);
        await writer.SaveChangesAsync();
        return product;
    }

    Task<Product?> IProductStorage.GetProductAsync(Guid id)
    {
        return reader.Read<Product>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    async Task<bool> IProductStorage.TryEditAsync(Product product)
    {

        var item = reader.Read<Product>().FirstOrDefault(x => x.Id == product.Id);
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

        writer.Update(item);
        await writer.SaveChangesAsync();
        return true;
    }

    async Task<bool> IProductStorage.TryDeleteAsync(Guid id)
    {
        var item = await
                reader.Read<Product>()
            .FirstOrDefaultAsync(x => x.Id == id);
        if (item == null)
        {
            return false;
        }
        writer.Delete(item);
        await writer.SaveChangesAsync();
        return true;
    }
}


