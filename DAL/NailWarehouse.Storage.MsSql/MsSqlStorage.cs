using NailWarehouse.Models;
using NailWarehouse.Storage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace NailWarehouse.Storage.MsSql;

public class MsSqlStorage: IProductStorage
{
    IReadOnlyCollection<Product> IProductStorage.GetAllProducts()
    {
        using var db = new ClassMagazineContext();
        List<Product> items = db.Products
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToList();
        return items;
    }

    public Product Add(Product product)
    {
        using var db = new ClassMagazineContext();
        db.Products.Add(product);
        db.SaveChanges();
        return product;
    }

    public Product? GetProduct(Guid id)
    {
        using var db = new ClassMagazineContext();
        return db.Products
            .FirstOrDefault(x => x.Id == id);
    }

    bool IProductStorage.TryEdit(Product product)
    {
        using var db = new ClassMagazineContext();
        Product? item = db.Products
            .FirstOrDefault(x => x.Id == product.Id);
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
        db.SaveChanges();
        return true;
    }

    public bool TryDelete(Guid id)
    {
        using var db = new ClassMagazineContext();
        var item = db.Products
            .FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return false;
        }
        db.Products.Remove(item);
        db.SaveChanges();
        return true;
    }
}
