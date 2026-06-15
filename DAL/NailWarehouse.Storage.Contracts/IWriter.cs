using System.Diagnostics.CodeAnalysis;

namespace NailWarehouse.Storage.Contracts;

public interface IWriter
{
    /// <summary>
    /// Добавить новую запись
    /// </summary>
    void Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    /// Изменить запись
    /// </summary>
    void Update<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    /// удалить запись
    /// </summary>
    void Delete<TEntity>([NotNull] TEntity entity) where TEntity : class;

    Task<int>  SaveChangesAsync(CancellationToken cancellationToken = default);

}
