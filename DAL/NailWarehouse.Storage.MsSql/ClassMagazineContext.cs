using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using NailWarehouse.Models;

namespace NailWarehouse.Storage.MsSql;

/// <summary>
/// Контекст базы данных для взаимодействия с SQL Server посредством Entity Framework Core.
/// </summary>
public class ClassMagazineContext : DbContext
{
    /// <summary>
    /// Предоставляет доступ к таблице товаров (Products) в базе данных для выполнения CRUD-операций.
    /// </summary>
    public DbSet<Product> Products { get; set; }


    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ClassMagazineContext"/>
    /// и автоматически гарантирует создание базы данных, если она еще не создана.
    /// </summary>
    public ClassMagazineContext( ) => Database.EnsureCreated();

    /// <summary>
    /// Конфигурирует параметры подключения к источнику данных (SQL Server).
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClassMagazine;Trusted_Connection=True;");
    }
}
