using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NailWarehouse.Models;
using NailWarehouse.Services.Contracts;

namespace NailWarehouse.Services;

/// <summary>
/// Декоратор для логирования производительности методов ProductService
/// </summary>
public class ProductServiceLogWrapper : IProductService

{
    private readonly IProductService innerServiceLog;
    private readonly ILogger<ProductServiceLogWrapper> loggerLog;

    /// <summary>
    /// Инициализирует декоратор, принимая основной сервис и логгер для записи аналитики
    /// </summary>
    public ProductServiceLogWrapper(IProductService innerService, ILogger<ProductServiceLogWrapper> logger)
    {
        innerServiceLog = innerService;
        loggerLog = logger;
    }

    /// <summary>
    /// Добавляет товар в систему с замером времени выполнения операции
    /// </summary>
    public async Task AddAsync(Product product)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            await innerServiceLog.AddAsync(product);
        }
        finally
        {
            sw.Stop();
            loggerLog.LogInformation("Метод Add выполнен за {Elapsed} мс", sw.ElapsedMilliseconds);
        }
    }

    /// <summary>
    /// Удаляет товар из системы с замером времени выполнения операции
    /// </summary>
    public async Task RemoveAsync(Product product)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            await innerServiceLog.RemoveAsync(product);
        }
        finally
        {
            sw.Stop();
            loggerLog.LogInformation("Метод Remove выполнен за {Elapsed} мс", sw.ElapsedMilliseconds);
        }
    }

    /// <summary>
    /// Возвращает список всех товаров с замером времени выполнения операции
    /// </summary>
    public async Task<List<Product>> GetAllAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return await innerServiceLog.GetAllAsync();
        }
        finally
        {
            sw.Stop();
            loggerLog.LogInformation("Метод GetAll выполнен за {Elapsed} мс", sw.ElapsedMilliseconds);
        }
    }

    /// <summary>
    /// Изменяет товар в системе с замером времени выполнения операции
    /// </summary>
    public async Task<bool> TryEditAsync(Product product)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return await innerServiceLog.TryEditAsync(product);
        }
        finally
        {
            sw.Stop();
            loggerLog.LogInformation("Метод TryEdit выполнен за {Elapsed} мс", sw.ElapsedMilliseconds);
        }
    }

    /// <summary>
    /// Получает аналитику по складу (статистику) с замером времени выполнения операции
    /// </summary>
    public async Task<(int count, decimal avgPrice, int totalQty, Product? deficit)> GetStatsAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return await innerServiceLog.GetStatsAsync();
        }
        finally
        {
            sw.Stop();
            loggerLog.LogInformation("Метод GetStats выполнен за {Elapsed} мс", sw.ElapsedMilliseconds);
        }
    }
}
