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
    public void Add(Product product)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            innerServiceLog.Add(product);
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
    public void Remove(Product product)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            innerServiceLog.Remove(product);
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
    public List<Product> GetAll()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return innerServiceLog.GetAll();
        }
        finally
        {
            sw.Stop();
            loggerLog.LogInformation("Метод GetAll выполнен за {Elapsed} мс", sw.ElapsedMilliseconds);
        }
    }

    /// <summary>
    /// Получает аналитику по складу (статистику) с замером времени выполнения операции
    /// </summary>
    public (int count, decimal avgPrice, int totalQty, Product? deficit) GetStats()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return innerServiceLog.GetStats();
        }
        finally
        {
            sw.Stop();
            loggerLog.LogInformation("Метод GetStats выполнен за {Elapsed} мс", sw.ElapsedMilliseconds);
        }
    }
}
