using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NailWarehouse.Models;
using NailWarehouse.Services.Contracts;

namespace NailWarehouse.Services;

public class ProductServiceLogWrapper : IProductService

{
    private readonly IProductService innerServiceLog;
    private readonly ILogger<ProductServiceLogWrapper> loggerLog;

    public ProductServiceLogWrapper(IProductService innerService, ILogger<ProductServiceLogWrapper> logger)
    {
        innerServiceLog = innerService;
        loggerLog = logger;
    }

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
            loggerLog.LogInformation("Метод GetAll выполнен за {Exapsed} мс", sw.ElapsedMilliseconds);
        }
    }

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
