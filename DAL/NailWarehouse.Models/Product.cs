namespace NailWarehouse.Models;

/// <summary>
/// Представляет собой модель данных для одного товара (гвоздя)
/// </summary>
public class Product
{
    /// <summary>
    /// Наименование товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// размер товара
    /// </summary>
    public string Size { get; set; }

    /// <summary>
    /// материал
    /// </summary>
    public string Material { get; set; }

    /// <summary>
    /// количество на складе
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// минимальный предел количества
    /// </summary>
    public int MinQuantity { get; set; }

    /// <summary>
    /// цена (без НДС)
    /// </summary>
    public decimal Price { get;set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса Product
    /// с заданными параметрами товара
    /// </summary>
    public Product(string name, string size, string material, int quantity, int minQuantity, decimal price)
    {
        Name = name;
        Size = size;
        Material = material;
        Quantity = quantity;
        MinQuantity = minQuantity;
        Price = price;
    }

    /// <summary>
    /// Рассчитывает общую стоимость текущего товара
    /// </summary>
    public decimal TotalSum => Price * Quantity;

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса Product.
    /// </summary>
    public Product() { }
}
