namespace NailWarehouse.Models;

/// <summary>
/// Содержит набор констант, используемых в главном окне приложения
/// и для общих настроек UI.
/// </summary>
public static class MainFormConstants
{
    /// <summary>
    /// Задает максимальное значение, используемое для отображения прогресс-бара
    /// в столбце таблицы товаров.
    /// </summary>
    public const int MaxQuantityForProgressBar = 100; 
    
    /// <summary>
    /// Отступ для ячеек.
    /// </summary>
    public const int Offset = 2;
    
    /// <summary>
    /// Определяет заголовок окна
    /// для формы добавления нового товара.
    /// </summary>
    public const string TitleAddForm = "Добавление нового товара";
    
    /// <summary>
    /// Текст сообщения для подтверждения
    /// действия пользователя по удалению выбранного товара.
    /// </summary>
    public const string MsgConfirmDelete = "Вы действительно хотите удалить товар?";
    
    /// <summary>
    /// Заголовок диалогового окна,
    /// отображаемого при запросе подтверждения удаления товара.
    /// </summary>
    public const string CapConfirmDelete = "Подтверждение удаления";
    
    /// <summary>
    /// Инструкция, указывающая на необходимость
    /// выбора товара в таблице для выполнения действия.
    /// </summary>
    public const string MsgSelectProduct = "Пожалуйста, выберите товар в таблице, который хотите удалить.";
    
    /// <summary>
    /// Заголовок для диалоговых окон,
    /// используемый для привлечения внимания пользователя к важной информации.
    /// </summary>
    public const string CapAttention = "Внимание";
    
    /// <summary>
    /// Текст статусного сообщения,
    /// отображаемый, когда на складе нет ни одного товара.
    /// </summary>
    public const string StockEmpty = "Склад пуст";
}