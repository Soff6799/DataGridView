namespace NailWarehouse;

using System.Windows.Forms;
using Models;
using System.Text;

/// <summary>
/// Окно для создания и редактирования данных о товаре.
/// </summary>
public partial class ProductEditForm : Form
{
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    private readonly Product originalProduct;
    private readonly Product editedProduct;

    /// <summary>
    /// Инициализирует форму, создает копию объекта и настраивает привязки.
    /// </summary>
    public ProductEditForm(Product product)
    {
        InitializeComponent();
        originalProduct = product;
        editedProduct = new Product()
        {
            Name = originalProduct.Name,
            Size = originalProduct.Size,
            Material = originalProduct.Material,
            Quantity = originalProduct.Quantity,
            MinQuantity = originalProduct.MinQuantity,
            Price = originalProduct.Price
        };
        textBoxName.DataBindings.Clear();
        textBoxPrice.DataBindings.Clear();
        comboBoxSize.DataBindings.Clear();
        comboBoxMaterial.DataBindings.Clear();
        numericUpDownQuantity.DataBindings.Clear();
        numericUpDownMinQuantity.DataBindings.Clear();

        textBoxName.DataBindings.Add("Text", editedProduct, nameof(Product.Name),
            true, DataSourceUpdateMode.OnValidation);
        comboBoxSize.DataBindings.Add("Text", editedProduct, nameof(Product.Size),
            true, DataSourceUpdateMode.OnValidation);
        comboBoxMaterial.DataBindings.Add("Text", editedProduct, nameof(Product.Material),
            true, DataSourceUpdateMode.OnValidation);
        numericUpDownQuantity.DataBindings.Add("Value", editedProduct, nameof(Product.Quantity),
            true, DataSourceUpdateMode.OnValidation);
        numericUpDownMinQuantity.DataBindings.Add("Value", editedProduct, nameof(Product.MinQuantity),
            true, DataSourceUpdateMode.OnValidation);

        var priceBinding = new Binding("Text", editedProduct, nameof(Product.Price),
            true, DataSourceUpdateMode.OnValidation) { FormatString = ProductEditFormConstants.PriceFormat };
        textBoxPrice.DataBindings.Add(priceBinding);

        textBoxName.Validating += RequiredField_Validating;
        textBoxPrice.Validating += RequiredField_Validating;
        comboBoxSize.Validating += RequiredField_Validating;
        comboBoxMaterial.Validating += RequiredField_Validating;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SuspendLayout();
        try
        {
            if (!ValidateData())
            {
                return;
            }
            originalProduct.Name = editedProduct.Name;
            originalProduct.Size = editedProduct.Size;
            originalProduct.Material = editedProduct.Material;
            originalProduct.Quantity = editedProduct.Quantity;
            originalProduct.MinQuantity = editedProduct.MinQuantity;
            originalProduct.Price = editedProduct.Price;

            DialogResult = DialogResult.OK;
            Close();
        }
        finally
        {
            ResumeLayout();
        }
    }

    private void RequiredField_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        var control = sender as Control;
        var isEmpty = string.IsNullOrEmpty(control?.Text);
        var isZero = control?.Text is "0" or "0,00";
        if (isEmpty || isZero)
        {
            if (control != null)
            {
                errorProvider.SetError(control, "Это поле обязательно для заполнения!");
            }

            e.Cancel = true;
        }
        else
        {
            if (control != null)
            {
                errorProvider.SetError(control, string.Empty);
            }

            e.Cancel = false;
        }
    }

    private bool ValidateData()
    {
        return ValidateChildren();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void comboBoxSize_TextChanged(object sender, EventArgs e)
    {
        var currentText = comboBoxSize.Text;
        var stringBuilder = new StringBuilder();
        var hasX = false;
        foreach (var c in currentText)
        {
            if (char.IsDigit(c) || c == '.')
            {
                stringBuilder.Append(c);
            }
            else if (char.ToLower(c) == 'x' && !hasX)
            {
                stringBuilder.Append('x');
                hasX = true;
            }
        }
        var filteredText = stringBuilder.ToString();
        if (comboBoxSize.Text != filteredText)
        {
            comboBoxSize.Text = filteredText;
            comboBoxSize.SelectionStart = filteredText.Length;
        }
    }

    private void comboBoxMaterial_TextChanged(object sender, EventArgs e)
    {
        var currentText = comboBoxMaterial.Text;
        var stringBuilder = new StringBuilder();
        foreach (var c in currentText.Where(char.IsLetter))
        {
            stringBuilder.Append(c);
        }
        var filteredText = stringBuilder.ToString();
        if (comboBoxMaterial.Text == filteredText)
        {
            return;
        }
        comboBoxMaterial.Text = filteredText;
        comboBoxMaterial.Select(filteredText.Length, 0);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Enter:
                btnSave.PerformClick();
                return true;
            case Keys.Escape:
                btnCancel.PerformClick();
                return true;
            default:
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
