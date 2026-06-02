namespace NailWarehouse;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        dataGridViewMain = new System.Windows.Forms.DataGridView();
        ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ProductSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
        MinQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
        TotalSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
        bindingSource1 = new System.Windows.Forms.BindingSource(components);
        bindingSource2 = new System.Windows.Forms.BindingSource(components);
        contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
        addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStrip1 = new System.Windows.Forms.ToolStrip();
        toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
        toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
        toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
        statusStrip1 = new System.Windows.Forms.StatusStrip();
        statusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMain).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
        contextMenuStrip1.SuspendLayout();
        toolStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        //
        // dataGridView1
        //
        dataGridViewMain.AllowUserToAddRows = false;
        dataGridViewMain.AllowUserToDeleteRows = false;
        dataGridViewMain.AllowUserToResizeColumns = false;
        dataGridViewMain.AllowUserToResizeRows = false;
        dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ProductName, ProductSize, Material, Quantity, MinQuantity, Price, TotalSum });
        dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewMain.Location = new System.Drawing.Point(0, 27);
        dataGridViewMain.Name = "dataGridViewMain";
        dataGridViewMain.ReadOnly = true;
        dataGridViewMain.RowHeadersWidth = 51;
        dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewMain.Size = new System.Drawing.Size(953, 423);
        dataGridViewMain.TabIndex = 1;
        dataGridViewMain.Text = "dataGridView1";
        //
        // ProductName
        //
        ProductName.DataPropertyName = "Name";
        ProductName.Frozen = true;
        ProductName.HeaderText = "Name";
        ProductName.MinimumWidth = 6;
        ProductName.Name = "ProductName";
        ProductName.ReadOnly = true;
        ProductName.Width = 125;
        //
        // ProductSize
        //
        ProductSize.DataPropertyName = "Size";
        ProductSize.HeaderText = "Size";
        ProductSize.MinimumWidth = 6;
        ProductSize.Name = "ProductSize";
        ProductSize.ReadOnly = true;
        ProductSize.Width = 125;
        //
        // Material
        //
        Material.DataPropertyName = "Material";
        Material.HeaderText = "Material";
        Material.MinimumWidth = 6;
        Material.Name = "Material";
        Material.ReadOnly = true;
        Material.Width = 125;
        //
        // Quantity
        //
        Quantity.DataPropertyName = "Quantity";
        Quantity.HeaderText = "Quantity";
        Quantity.MinimumWidth = 6;
        Quantity.Name = "Quantity";
        Quantity.ReadOnly = true;
        Quantity.Width = 125;
        //
        // MinQuantity
        //
        MinQuantity.DataPropertyName = "MinQuantity";
        MinQuantity.HeaderText = "MinQuantity";
        MinQuantity.MinimumWidth = 6;
        MinQuantity.Name = "MinQuantity";
        MinQuantity.ReadOnly = true;
        MinQuantity.Width = 125;
        //
        // Price
        //
        Price.DataPropertyName = "Price";
        Price.HeaderText = "Price(without NDS)";
        Price.MinimumWidth = 6;
        Price.Name = "Price";
        Price.ReadOnly = true;
        Price.Width = 125;
        //
        // TotalSum
        //
        TotalSum.DataPropertyName = "TotalSum";
        TotalSum.HeaderText = "TotalSum";
        TotalSum.MinimumWidth = 6;
        TotalSum.Name = "TotalSum";
        TotalSum.ReadOnly = true;
        TotalSum.Width = 125;
        //
        // contextMenuStrip1
        //
        contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new System.Drawing.Size(107, 28);
        //
        // addToolStripMenuItem
        //
        addToolStripMenuItem.Name = "addToolStripMenuItem";
        addToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
        addToolStripMenuItem.Text = "Add";
        //
        // toolStrip1
        //
        toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonDelete });
        toolStrip1.Location = new System.Drawing.Point(0, 0);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new System.Drawing.Size(953, 27);
        toolStrip1.TabIndex = 2;
        toolStrip1.Text = "toolStrip1";
        //
        // toolStripButtonAdd
        //
        toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        toolStripButtonAdd.Image = ((System.Drawing.Image)resources.GetObject("toolStripButtonAdd.Image"));
        toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
        toolStripButtonAdd.Name = "toolStripButtonAdd";
        toolStripButtonAdd.Size = new System.Drawing.Size(29, 24);
        toolStripButtonAdd.Text = "Add";
        toolStripButtonAdd.Click += toolStripButtonAdd_Click;
        //
        // toolStripButtonEdit
        //
        toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        toolStripButtonEdit.Image = ((System.Drawing.Image)resources.GetObject("toolStripButtonEdit.Image"));
        toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
        toolStripButtonEdit.Name = "toolStripButtonEdit";
        toolStripButtonEdit.Size = new System.Drawing.Size(29, 24);
        toolStripButtonEdit.Text = "Edit";
        toolStripButtonEdit.Click += toolStripButtonEditing_Click;
        //
        // toolStripButtonDelete
        //
        toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        toolStripButtonDelete.Image = ((System.Drawing.Image)resources.GetObject("toolStripButtonDelete.Image"));
        toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
        toolStripButtonDelete.Name = "toolStripButtonDelete";
        toolStripButtonDelete.Size = new System.Drawing.Size(29, 24);
        toolStripButtonDelete.Text = "Delete";
        toolStripButtonDelete.Click += toolStripButtonDelete_Click;
        //
        // statusStrip1
        //
        statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabelInfo });
        statusStrip1.Location = new System.Drawing.Point(0, 424);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new System.Drawing.Size(953, 26);
        statusStrip1.TabIndex = 3;
        statusStrip1.Text = "statusStrip1";
        //
        // statusLabelInfo
        //
        statusLabelInfo.Name = "statusLabelInfo";
        statusLabelInfo.Size = new System.Drawing.Size(134, 20);
        statusLabelInfo.Text = "Загрузка данных...";
        //
        // MainForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(953, 450);
        Controls.Add(statusStrip1);
        Controls.Add(dataGridViewMain);
        Controls.Add(toolStrip1);
        Text = "Аналитика склада гвоздей";
        ((System.ComponentModel.ISupportInitialize)dataGridViewMain).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
        contextMenuStrip1.ResumeLayout(false);
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ToolStripStatusLabel statusLabelInfo;

    private System.Windows.Forms.StatusStrip statusStrip1;

    private System.Windows.Forms.ToolStripButton toolStripButtonDelete;

    private System.Windows.Forms.ToolStripButton toolStripButtonEdit;

    private System.Windows.Forms.ToolStripButton toolStripButtonAdd;

    private System.Windows.Forms.ToolStrip toolStrip1;

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;

    private System.Windows.Forms.DataGridViewTextBoxColumn ProductSize;

    private new System.Windows.Forms.DataGridViewTextBoxColumn ProductName;

    private System.Windows.Forms.DataGridViewTextBoxColumn Material;
    private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    private System.Windows.Forms.DataGridViewTextBoxColumn MinQuantity;
    private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    private System.Windows.Forms.DataGridViewTextBoxColumn TotalSum;

    private System.Windows.Forms.BindingSource bindingSource1;
    private System.Windows.Forms.BindingSource bindingSource2;

    private System.Windows.Forms.DataGridView dataGridViewMain;

    #endregion
}
