using NailWarehouse.Storage.MsSql;

namespace NailWarehouse;

using Services;
using Services.Contracts;
using Storage.InMemory;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Serilog;

/// <summary>
/// Класс, содержащий логику запуска приложения.
/// </summary>
static internal class Program
{
    /// <summary>
    /// Главная точка входа, запускающая основное окно программы.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Debug()
            .WriteTo.Seq(serverUrl: "http://localhost:5341",
                            apiKey: "ZYEO7Sfp7HBQ9MbKb0vF",
                            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
            .WriteTo.File("logs/tour-perf-.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog();
        });
        var logger = loggerFactory.CreateLogger<ProductServiceLogWrapper>();
        ApplicationConfiguration.Initialize();
        var dbstorage = new MsSqlStorage();
        var realService = new ProductService(dbstorage);
        IProductService service = new ProductServiceLogWrapper(realService, logger);
        Application.Run(new MainForm(service));
    }
}

