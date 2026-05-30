using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using NailWarehouse.Models;

namespace NailWarehouse.Storage.MsSql;

public class ClassMagazineContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ClassMagazineContext( ) => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClassMagazine;Trusted_Connection=True;");

    }
}
