# NailWarehouse.Models

## Core data models for the Nail Warehouse management system.

This package provides essential data entities for managing products and inventory in a nail warehouse.

### Содержимое пакета:

*   **`Product`**: Основная сущность товара. Включает свойства:
    *   `Name` (Наименование товара)
    *   `Size` (Размер товара)
    *   `Material` (Материал изготовления)
    *   `Quantity` (Текущее количество на складе)
    *   `MinQuantity` (Минимальное допустимое количество на складе)
    *   `Price` (Цена товара без НДС)
    *   Также содержит метод `TotalSum` для расчета общей стоимости позиции.

*   **`Warehouse`**: Представляет склад или место хранения.


### Как использовать:

1.  **Установка пакета** через NuGet Package Manager:
    ```powershell
    Install-Package SofiaM.NailWarehouse.Models
2. Добавьте пространство имен в начало файла:
   ```csharp
   using NailWarehouse.Models;


