namespace NailWarehouse.Models;

/// <summary>
/// Содержит константы для формы редактирования товаров
/// </summary>
public static class ProductEditFormConstants
{
    /// <summary>
    /// Формат для отображения цены с двумя знаками после запятой
    /// </summary>
    public const string PriceFormat = "N2"; // Два знака после запятой
    
    /// <summary>
    /// Текст ошибки, когда поле Название товара оставлено пустым
    /// </summary>
    public const string ErrEmptyName = "Название не может быть пустым!";
    
    /// <summary>
    /// Текст ошибки, когда поле Размер товара оставлено пустым
    /// </summary>
    public const string ErrEmptySize = "Укажите размер!";
    
    /// <summary>
    /// Текст ошибки, когда поле Материал товара оставлено пустым.
    /// </summary>
    public const string ErrEmptyMaterial = "Укажите материал!";
    
    /// <summary>
    /// Текст ошибки, когда в поле "Цена" введено
    /// некорректное значение (не число или <= 0)
    /// </summary>
    public const string ErrInvalidPrice = "Цена должна быть числом больше нуля!";
}