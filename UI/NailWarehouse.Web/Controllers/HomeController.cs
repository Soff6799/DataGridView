using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NailWarehouse.Services.Contracts;
using NailWarehouse.Web.Models;

namespace NailWarehouse.Web.Controllers;

/// <summary>
/// Контроллер для управления главными страницами и операциями с товарами на складе.
/// </summary>
public class HomeController : Controller
{
    private readonly IProductService productService;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера <see cref="HomeController"/>.
    /// </summary>
    public HomeController(IProductService productService)
    {
        this.productService = productService;
    }

    /// <summary>
    /// Отображает главную страницу с полным списком всех товаров на складе
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAllAsync();
        return View(products);
    }

    /// <summary>
    /// Отображает страницу ошибок
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    /// Отображает форму для создания нового продукта
    /// </summary>
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Обрабатывает отправку формы для создания нового продукта
    /// </summary>
    [HttpPost]
    public async Task<IActionResult>
        Create(NailWarehouse.Models.Product product)
    {
        product.Id = Guid.NewGuid();
        await productService.AddAsync(product);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Обрабатывает запрос на удаление продукта
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await productService.RemoveAsync(new NailWarehouse.Models.Product { Id = id });
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Отображает форму для редактирования существующего продукта
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var product = await productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    /// <summary>
    /// Обрабатывает отправку формы для обновления существующего продукта.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, NailWarehouse.Models.Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }
        var success = await productService.TryEditAsync(product);
        if (!success)
        {
            return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
}

