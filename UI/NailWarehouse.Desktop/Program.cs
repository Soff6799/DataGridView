namespace Nail_Warehouse;

using NailWarehouse.Services;
using NailWarehouse.Services.Contracts;
using NailWarehouse.Storage.InMemory;
using System;
using System.Windows.Forms;

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
        ApplicationConfiguration.Initialize();
        var storage = new ProductStorage();
        IProductService service = new ProductService(storage);
        Application.Run(new MainForm(service));
    }
}

