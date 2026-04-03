using System.ComponentModel;

namespace NailWarehouse;

partial class ProductEditForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        textBoxName = new System.Windows.Forms.TextBox();
        textBoxPrice = new System.Windows.Forms.TextBox();
        comboBoxMaterial = new System.Windows.Forms.ComboBox();
        comboBoxSize = new System.Windows.Forms.ComboBox();
        numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
        numericUpDownMinQuantity = new System.Windows.Forms.NumericUpDown();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        errorProvider = new System.Windows.Forms.ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        //
        // label1
        //
        label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.Location = new System.Drawing.Point(10, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(155, 25);
        label1.TabIndex = 0;
        label1.Text = "Название товара:";
        //
        // label2
        //
        label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label2.Location = new System.Drawing.Point(8, 79);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(125, 28);
        label2.TabIndex = 1;
        label2.Text = "Размер:";
        //
        // label3
        //
        label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label3.Location = new System.Drawing.Point(7, 144);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(157, 26);
        label3.TabIndex = 2;
        label3.Text = "Материал:";
        //
        // label4
        //
        label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label4.Location = new System.Drawing.Point(7, 205);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(140, 29);
        label4.TabIndex = 3;
        label4.Text = "Количество:";
        //
        // label5
        //
        label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label5.Location = new System.Drawing.Point(7, 261);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(267, 26);
        label5.TabIndex = 4;
        label5.Text = "Минимальный предел количества:";
        //
        // label6
        //
        label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label6.Location = new System.Drawing.Point(8, 311);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(198, 26);
        label6.TabIndex = 5;
        label6.Text = "Цена (без НДС):";
        //
        // textBoxName
        //
        textBoxName.Location = new System.Drawing.Point(6, 36);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new System.Drawing.Size(342, 27);
        textBoxName.TabIndex = 7;
        //
        // textBoxPrice
        //
        textBoxPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)204));
        textBoxPrice.Location = new System.Drawing.Point(10, 329);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new System.Drawing.Size(210, 27);
        textBoxPrice.TabIndex = 9;
        //
        // comboBoxMaterial
        //
        comboBoxMaterial.FormattingEnabled = true;
        comboBoxMaterial.Items.AddRange(new object[] { "медь", "сталь ", "железо", "хром" });
        comboBoxMaterial.Location = new System.Drawing.Point(6, 173);
        comboBoxMaterial.Name = "comboBoxMaterial";
        comboBoxMaterial.Size = new System.Drawing.Size(342, 28);
        comboBoxMaterial.TabIndex = 8;
        comboBoxMaterial.TextChanged += comboBoxMaterial_TextChanged;
        //
        // comboBoxSize
        //
        comboBoxSize.FormattingEnabled = true;
        comboBoxSize.Items.AddRange(new object[] { "2.0x35", "2.5x50", "3.0x70", "3.5x90", "4.0x100", "4.5x120" });
        comboBoxSize.Location = new System.Drawing.Point(11, 102);
        comboBoxSize.Name = "comboBoxSize";
        comboBoxSize.Size = new System.Drawing.Size(337, 28);
        comboBoxSize.TabIndex = 13;
        comboBoxSize.TextChanged += comboBoxSize_TextChanged;
        //
        // numericUpDownQuantity
        //
        numericUpDownQuantity.Location = new System.Drawing.Point(6, 231);
        numericUpDownQuantity.Name = "numericUpDownQuantity";
        numericUpDownQuantity.Size = new System.Drawing.Size(214, 27);
        numericUpDownQuantity.TabIndex = 14;
        //
        // numericUpDownMinQuantity
        //
        numericUpDownMinQuantity.Location = new System.Drawing.Point(7, 280);
        numericUpDownMinQuantity.Name = "numericUpDownMinQuantity";
        numericUpDownMinQuantity.Size = new System.Drawing.Size(211, 27);
        numericUpDownMinQuantity.TabIndex = 15;
        //
        // btnSave
        //
        btnSave.Location = new System.Drawing.Point(13, 381);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(150, 35);
        btnSave.TabIndex = 16;
        btnSave.Text = "Сохранить";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        //
        // btnCancel
        //
        btnCancel.Location = new System.Drawing.Point(196, 381);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(152, 35);
        btnCancel.TabIndex = 17;
        btnCancel.Text = "Отмена";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // errorProvider
        //
        errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        //
        // ProductEditForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(382, 428);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(numericUpDownMinQuantity);
        Controls.Add(numericUpDownQuantity);
        Controls.Add(comboBoxSize);
        Controls.Add(textBoxPrice);
        Controls.Add(comboBoxMaterial);
        Controls.Add(textBoxName);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Text = "Редактирование продукта";
        ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ErrorProvider errorProvider;

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    private System.Windows.Forms.NumericUpDown numericUpDownMinQuantity;

    private System.Windows.Forms.NumericUpDown numericUpDownQuantity;

    private System.Windows.Forms.ComboBox comboBoxSize;

    private System.Windows.Forms.TextBox textBoxMinQuantity;

    private System.Windows.Forms.TextBox textBoxPrice;

    private System.Windows.Forms.ComboBox comboBoxMaterial;

    private System.Windows.Forms.TextBox textBoxName;

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}

