using System.ComponentModel;

namespace SIV.Views.Tables.ProductData;

partial class FrmProductData
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        this.panelDisplay = new Guna.UI2.WinForms.Guna2Panel();
        this.btnExit = new Guna.UI2.WinForms.Guna2Button();
        this.btnSearchProduct = new Guna.UI2.WinForms.Guna2Button();
        this.txtProduct = new Guna.UI2.WinForms.Guna2TextBox();
        this.gridData = new Guna.UI2.WinForms.Guna2DataGridView();
        this.labelSalesData = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.panelDisplay.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
        this.SuspendLayout();
        // 
        // panelDisplay
        // 
        this.panelDisplay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
        this.panelDisplay.BorderRadius = 15;
        this.panelDisplay.BorderThickness = 1;
        this.panelDisplay.Controls.Add(this.btnExit);
        this.panelDisplay.Controls.Add(this.btnSearchProduct);
        this.panelDisplay.Controls.Add(this.txtProduct);
        this.panelDisplay.Controls.Add(this.gridData);
        this.panelDisplay.Controls.Add(this.labelSalesData);
        this.panelDisplay.CustomizableEdges = customizableEdges7;
        this.panelDisplay.Location = new System.Drawing.Point(12, 12);
        this.panelDisplay.Name = "panelDisplay";
        this.panelDisplay.ShadowDecoration.CustomizableEdges = customizableEdges8;
        this.panelDisplay.Size = new System.Drawing.Size(790, 472);
        this.panelDisplay.TabIndex = 0;
        // 
        // btnExit
        // 
        this.btnExit.Animated = true;
        this.btnExit.AutoRoundedCorners = true;
        this.btnExit.BackColor = System.Drawing.Color.Transparent;
        this.btnExit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
        this.btnExit.BorderRadius = 17;
        this.btnExit.BorderThickness = 1;
        this.btnExit.CustomizableEdges = customizableEdges1;
        this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnExit.FillColor = System.Drawing.Color.WhiteSmoke;
        this.btnExit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
        this.btnExit.ForeColor = System.Drawing.Color.Black;
        this.btnExit.Location = new System.Drawing.Point(751, 3);
        this.btnExit.Name = "btnExit";
        this.btnExit.ShadowDecoration.CustomizableEdges = customizableEdges2;
        this.btnExit.Size = new System.Drawing.Size(36, 36);
        this.btnExit.TabIndex = 36;
        this.btnExit.Text = "X";
        this.btnExit.UseTransparentBackground = true;
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        // 
        // btnSearchProduct
        // 
        this.btnSearchProduct.Animated = true;
        this.btnSearchProduct.BackColor = System.Drawing.Color.Transparent;
        this.btnSearchProduct.BorderRadius = 10;
        this.btnSearchProduct.CustomizableEdges = customizableEdges3;
        this.btnSearchProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnSearchProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnSearchProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnSearchProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnSearchProduct.FillColor = System.Drawing.Color.Transparent;
        this.btnSearchProduct.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.btnSearchProduct.ForeColor = System.Drawing.Color.White;
        this.btnSearchProduct.Image = global::SIV.Properties.Resources.icons_pesquisar;
        this.btnSearchProduct.ImageSize = new System.Drawing.Size(32, 32);
        this.btnSearchProduct.Location = new System.Drawing.Point(695, 6);
        this.btnSearchProduct.Name = "btnSearchProduct";
        this.btnSearchProduct.ShadowDecoration.CustomizableEdges = customizableEdges4;
        this.btnSearchProduct.Size = new System.Drawing.Size(30, 30);
        this.btnSearchProduct.TabIndex = 35;
        // 
        // txtProduct
        // 
        this.txtProduct.Animated = true;
        this.txtProduct.BackColor = System.Drawing.Color.Transparent;
        this.txtProduct.BorderRadius = 15;
        this.txtProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtProduct.CustomizableEdges = customizableEdges5;
        this.txtProduct.DefaultText = "";
        this.txtProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtProduct.Location = new System.Drawing.Point(270, 3);
        this.txtProduct.Name = "txtProduct";
        this.txtProduct.PasswordChar = '\0';
        this.txtProduct.PlaceholderText = "Buscar por Produto...";
        this.txtProduct.SelectedText = "";
        this.txtProduct.ShadowDecoration.CustomizableEdges = customizableEdges6;
        this.txtProduct.Size = new System.Drawing.Size(468, 36);
        this.txtProduct.TabIndex = 34;
        this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProduct_KeyDown);
        // 
        // gridData
        // 
        this.gridData.AllowUserToAddRows = false;
        this.gridData.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
        this.gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(211)))));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.gridData.DefaultCellStyle = dataGridViewCellStyle3;
        this.gridData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
        this.gridData.Location = new System.Drawing.Point(12, 45);
        this.gridData.Name = "gridData";
        this.gridData.ReadOnly = true;
        this.gridData.RowHeadersVisible = false;
        this.gridData.Size = new System.Drawing.Size(766, 414);
        this.gridData.TabIndex = 23;
        this.gridData.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Cyan;
        this.gridData.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
        this.gridData.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.gridData.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.gridData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.gridData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.gridData.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.gridData.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
        this.gridData.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(211)))));
        this.gridData.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.gridData.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.gridData.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
        this.gridData.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        this.gridData.ThemeStyle.HeaderStyle.Height = 23;
        this.gridData.ThemeStyle.ReadOnly = true;
        this.gridData.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
        this.gridData.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.gridData.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.gridData.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.gridData.ThemeStyle.RowsStyle.Height = 22;
        this.gridData.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
        this.gridData.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
        this.gridData.DoubleClick += new System.EventHandler(this.gridData_DoubleClick);
        // 
        // labelSalesData
        // 
        this.labelSalesData.AutoSize = false;
        this.labelSalesData.BackColor = System.Drawing.Color.Transparent;
        this.labelSalesData.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelSalesData.Location = new System.Drawing.Point(12, 3);
        this.labelSalesData.Name = "labelSalesData";
        this.labelSalesData.Size = new System.Drawing.Size(252, 35);
        this.labelSalesData.TabIndex = 2;
        this.labelSalesData.Text = "Pesquisar por Produto";
        this.labelSalesData.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // FrmProductData
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.ClientSize = new System.Drawing.Size(814, 496);
        this.Controls.Add(this.panelDisplay);
        this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Margin = new System.Windows.Forms.Padding(5);
        this.MinimumSize = new System.Drawing.Size(814, 496);
        this.Name = "FrmProductData";
        this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
        this.Text = "FrmProductData";
        this.panelDisplay.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
        this.ResumeLayout(false);
    }

    private Guna.UI2.WinForms.Guna2Button btnExit;

    private Guna.UI2.WinForms.Guna2Button btnSearchProduct;
    private Guna.UI2.WinForms.Guna2TextBox txtProduct;

    private Guna.UI2.WinForms.Guna2DataGridView gridData;

    private Guna.UI2.WinForms.Guna2HtmlLabel labelSalesData;

    private Guna.UI2.WinForms.Guna2Panel panelDisplay;

    #endregion
}