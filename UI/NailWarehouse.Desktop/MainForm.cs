namespace NailWarehouse;

using Models;
using Services.Contracts;

/// <summary>
/// Главное окно приложения для управления складом товаров.
/// </summary>
public partial class MainForm : Form
{
    private readonly IProductService productService;
    private readonly BindingSource source = new();

    /// <summary>
    /// Инициализирует окно, загружает данные и настраивает таблицу.
    /// </summary>
    public MainForm(IProductService service)
    {
        InitializeComponent();
        productService = service;

        dataGridViewMain.AutoGenerateColumns = false;
        dataGridViewMain.DataSource = source;
        dataGridViewMain.CellPainting += DataGridViewMain_CellPainting;

        Load += MainForm_Load;
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        await RefrashDataAsync();
    }

    private async Task RefrashDataAsync()
    {
        try
        {
            var products = await productService.GetAllAsync();
            source.DataSource = products;
            source.ResetBindings(false);
            await SetStatisticAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
        }
    }

    private void DataGridViewMain_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e is { ColumnIndex: 3, RowIndex: >= 0 })
        {
            var quantity = Convert.ToInt32(e.Value ?? 0);
            var maxQuantity = MainFormConstants.MaxQuantityForProgressBar;
            e.PaintBackground(e.CellBounds, true);
            var offset = MainFormConstants.Offset;
            var barHeight = e.CellBounds.Height - (offset * 2) - 1;
            var maxBarWidth = e.CellBounds.Width - (offset * 2) - 1;
            var percentage = Math.Min(1.0, (double)quantity / maxQuantity);
            var barWidth = (int)(maxBarWidth * percentage);
            if (barWidth > 0)
            {
                Rectangle rect = new Rectangle(e.CellBounds.X +
                                               offset, e.CellBounds.Y + offset, barWidth, barHeight);
                if (dataGridViewMain.Rows[e.RowIndex].DataBoundItem is not Product product)
                {
                    return;
                }
                Brush barBrush = quantity < product.MinQuantity ?
                    Brushes.Orange : Brushes.LightBlue;
                e.Graphics?.FillRectangle(barBrush, rect);
            }
            e.PaintContent(e.CellBounds);
            e.Handled = true;
        }
    }

    private async void toolStripButtonEditing_Click(object sender, EventArgs e)
    {
        if (dataGridViewMain.SelectedRows.Count > 0 &&
            dataGridViewMain.SelectedRows[0].DataBoundItem is Product selectedProduct )
        {
            var editForm = new ProductEditForm(selectedProduct);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await RefrashDataAsync();
            }
        }
    }

    private async Task SetStatisticAsync()
    {
        var stats = await productService.GetStatsAsync();
        if (stats.count == 0)
        {
            statusLabelInfo.Text = MainFormConstants.StockEmpty;
            return;
        }
        statusLabelInfo.Text = $"Всего: {stats.count} | " +
                               $"Запасы: {stats.totalQty} шт. | " +
                               $"Средняя цена: {stats.avgPrice:N2} руб. | " +
                               $"Меньше всего: {stats.deficit?.Name} ({stats.deficit?.Quantity ?? 0} шт)";
    }

    private async void toolStripButtonAdd_Click(object sender, EventArgs e)
    {
        Product newProduct = new Product
        {
            Name = "",
            Size = "",
            Material = "",
            Quantity = 0,
            Price = 0
        };
        var addForm = new ProductEditForm(newProduct);
        addForm.Text = MainFormConstants.TitleAddForm;
        if (addForm.ShowDialog() == DialogResult.OK)
        {
            await productService.AddAsync(newProduct);
            source.ResetBindings(false);
            await SetStatisticAsync();
        }
    }

    private async void toolStripButtonDelete_Click(object sender, EventArgs e)
    {
        if (dataGridViewMain.SelectedRows.Count > 0)
        {
            var selectedProduct = dataGridViewMain.SelectedRows[0].DataBoundItem as Product;
            if (selectedProduct == null)
            {
                return;
            }
            var result = MessageBox.Show(
                text: $"{MainFormConstants.MsgConfirmDelete} '{selectedProduct.Name}'?",
                caption: MainFormConstants.CapConfirmDelete,
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                await productService.RemoveAsync(selectedProduct);
                source.ResetBindings(false);
                await SetStatisticAsync();
            }
        }
        else
        {
            MessageBox.Show(MainFormConstants.MsgSelectProduct, MainFormConstants.CapAttention,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

