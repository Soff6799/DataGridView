namespace NailWarehouse.Storage.Contracts;

public interface IReader
{
    IQueryable<TEntity> Read<TEntity>() where TEntity : class;
}
