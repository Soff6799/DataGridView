using Microsoft.EntityFrameworkCore;
using NailWarehouse.Models;
using NailWarehouse.Storage.Contracts;

namespace NailWarehouse.Storage.Db;

/// <summary>
/// Контекст базы данных для взаимодействия с SQL Server посредством Entity Framework Core.
/// </summary>
public class ClassMagazineContext : DbContext, IReader, IWriter
{
    /// <summary>
    /// Предоставляет доступ к таблице товаров (Products) в базе данных для выполнения CRUD-операций.
    /// </summary>
    public DbSet<Product> Products { get; set; }


    public ClassMagazineContext(DbContextOptions<ClassMagazineContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ClassMagazineContext"/>
    /// и автоматически гарантирует создание базы данных, если она еще не создана.
    /// </summary>
    public ClassMagazineContext( )
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Конфигурирует параметры подключения к источнику данных (SQL Server).
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClassMagazine;Trusted_Connection=True;");
    }

    public IQueryable<TEntity> Read<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();
    }

    void IWriter.Add<TEntity>(TEntity entity)
    {
        base.Add(entity);
    }

    void IWriter.Update<TEntity>(TEntity entity)
    {
        base.Update(entity);
    }

    void IWriter.Delete<TEntity>(TEntity entity)
    {
        base.Remove(entity);
    }
}
