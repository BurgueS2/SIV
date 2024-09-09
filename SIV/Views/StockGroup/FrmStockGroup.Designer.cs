using System.ComponentModel;

namespace SIV.Views.StockGroup;

partial class FrmStockGroup
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        this.panelGrid = new Guna.UI2.WinForms.Guna2Panel();
        this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
        this.labelRegisteredPaymants = new System.Windows.Forms.Label();
        this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
        this.gridData = new Guna.UI2.WinForms.Guna2DataGridView();
        this.labelFlag = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
        this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
        this.btnNew = new Guna.UI2.WinForms.Guna2Button();
        this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
        this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
        this.btnSave = new Guna.UI2.WinForms.Guna2Button();
        this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
        this.panelGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
        this.SuspendLayout();
        // 
        // panelGrid
        // 
        this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.panelGrid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
        this.panelGrid.BorderRadius = 15;
        this.panelGrid.BorderThickness = 1;
        this.panelGrid.Controls.Add(this.btnSearch);
        this.panelGrid.Controls.Add(this.labelRegisteredPaymants);
        this.panelGrid.Controls.Add(this.txtSearch);
        this.panelGrid.Controls.Add(this.gridData);
        this.panelGrid.CustomizableEdges = customizableEdges5;
        this.panelGrid.FillColor = System.Drawing.Color.Transparent;
        this.panelGrid.Location = new System.Drawing.Point(12, 246);
        this.panelGrid.Name = "panelGrid";
        this.panelGrid.ShadowDecoration.CustomizableEdges = customizableEdges6;
        this.panelGrid.Size = new System.Drawing.Size(790, 270);
        this.panelGrid.TabIndex = 135;
        // 
        // btnSearch
        // 
        this.btnSearch.Animated = true;
        this.btnSearch.BackColor = System.Drawing.Color.Transparent;
        this.btnSearch.BorderRadius = 10;
        this.btnSearch.CustomizableEdges = customizableEdges1;
        this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnSearch.FillColor = System.Drawing.Color.Transparent;
        this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.btnSearch.ForeColor = System.Drawing.Color.White;
        this.btnSearch.Image = global::SIV.Properties.Resources.icons_pesquisar;
        this.btnSearch.ImageSize = new System.Drawing.Size(30, 30);
        this.btnSearch.Location = new System.Drawing.Point(265, 41);
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
        this.btnSearch.Size = new System.Drawing.Size(25, 25);
        this.btnSearch.TabIndex = 29;
        // 
        // labelRegisteredPaymants
        // 
        this.labelRegisteredPaymants.BackColor = System.Drawing.Color.Transparent;
        this.labelRegisteredPaymants.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelRegisteredPaymants.Location = new System.Drawing.Point(3, 0);
        this.labelRegisteredPaymants.Name = "labelRegisteredPaymants";
        this.labelRegisteredPaymants.Size = new System.Drawing.Size(207, 36);
        this.labelRegisteredPaymants.TabIndex = 27;
        this.labelRegisteredPaymants.Text = "Clientes Cadastrados";
        this.labelRegisteredPaymants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // txtSearch
        // 
        this.txtSearch.Animated = true;
        this.txtSearch.BackColor = System.Drawing.Color.Transparent;
        this.txtSearch.BorderRadius = 10;
        this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtSearch.CustomizableEdges = customizableEdges3;
        this.txtSearch.DefaultText = "";
        this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtSearch.Location = new System.Drawing.Point(3, 39);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.PasswordChar = '\0';
        this.txtSearch.PlaceholderText = "Buscar...";
        this.txtSearch.SelectedText = "";
        this.txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
        this.txtSearch.Size = new System.Drawing.Size(295, 29);
        this.txtSearch.TabIndex = 28;
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
        this.gridData.Location = new System.Drawing.Point(3, 89);
        this.gridData.Name = "gridData";
        this.gridData.ReadOnly = true;
        this.gridData.RowHeadersVisible = false;
        this.gridData.Size = new System.Drawing.Size(784, 168);
        this.gridData.TabIndex = 21;
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
        // labelFlag
        // 
        this.labelFlag.AutoSize = false;
        this.labelFlag.BackColor = System.Drawing.Color.Transparent;
        this.labelFlag.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelFlag.Location = new System.Drawing.Point(12, 92);
        this.labelFlag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        this.labelFlag.Name = "labelFlag";
        this.labelFlag.Size = new System.Drawing.Size(124, 36);
        this.labelFlag.TabIndex = 137;
        this.labelFlag.Text = "Nome";
        this.labelFlag.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // txtName
        // 
        this.txtName.Animated = true;
        this.txtName.BorderRadius = 10;
        this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtName.CustomizableEdges = customizableEdges7;
        this.txtName.DefaultText = "";
        this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtName.Location = new System.Drawing.Point(142, 92);
        this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        this.txtName.MaxLength = 255;
        this.txtName.Name = "txtName";
        this.txtName.PasswordChar = '\0';
        this.txtName.PlaceholderText = "";
        this.txtName.SelectedText = "";
        this.txtName.ShadowDecoration.CustomizableEdges = customizableEdges8;
        this.txtName.Size = new System.Drawing.Size(252, 36);
        this.txtName.TabIndex = 136;
        // 
        // btnCancel
        // 
        this.btnCancel.Animated = true;
        this.btnCancel.BackColor = System.Drawing.Color.Transparent;
        this.btnCancel.BorderRadius = 10;
        this.btnCancel.CustomizableEdges = customizableEdges9;
        this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnCancel.FillColor = System.Drawing.Color.Black;
        this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(124, 181);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.PressedColor = System.Drawing.Color.White;
        this.btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges10;
        this.btnCancel.Size = new System.Drawing.Size(106, 29);
        this.btnCancel.TabIndex = 142;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnNew
        // 
        this.btnNew.Animated = true;
        this.btnNew.BackColor = System.Drawing.Color.Transparent;
        this.btnNew.BorderRadius = 10;
        this.btnNew.CustomizableEdges = customizableEdges11;
        this.btnNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnNew.FillColor = System.Drawing.Color.Black;
        this.btnNew.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.btnNew.ForeColor = System.Drawing.Color.White;
        this.btnNew.Location = new System.Drawing.Point(12, 181);
        this.btnNew.Name = "btnNew";
        this.btnNew.PressedColor = System.Drawing.Color.White;
        this.btnNew.ShadowDecoration.CustomizableEdges = customizableEdges12;
        this.btnNew.Size = new System.Drawing.Size(106, 29);
        this.btnNew.TabIndex = 141;
        this.btnNew.Text = "Novo";
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Animated = true;
        this.btnDelete.BackColor = System.Drawing.Color.Transparent;
        this.btnDelete.BorderRadius = 10;
        this.btnDelete.CustomizableEdges = customizableEdges13;
        this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnDelete.FillColor = System.Drawing.Color.Black;
        this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnDelete.ForeColor = System.Drawing.Color.White;
        this.btnDelete.Location = new System.Drawing.Point(460, 181);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.PressedColor = System.Drawing.Color.White;
        this.btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges14;
        this.btnDelete.Size = new System.Drawing.Size(106, 29);
        this.btnDelete.TabIndex = 140;
        this.btnDelete.Text = "Excluir";
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.Animated = true;
        this.btnEdit.BackColor = System.Drawing.Color.Transparent;
        this.btnEdit.BorderRadius = 10;
        this.btnEdit.CustomizableEdges = customizableEdges15;
        this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnEdit.FillColor = System.Drawing.Color.Black;
        this.btnEdit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnEdit.ForeColor = System.Drawing.Color.White;
        this.btnEdit.Location = new System.Drawing.Point(348, 181);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.PressedColor = System.Drawing.Color.White;
        this.btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges16;
        this.btnEdit.Size = new System.Drawing.Size(106, 29);
        this.btnEdit.TabIndex = 139;
        this.btnEdit.Text = "Editar";
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnSave
        // 
        this.btnSave.Animated = true;
        this.btnSave.BackColor = System.Drawing.Color.Transparent;
        this.btnSave.BorderRadius = 10;
        this.btnSave.CustomizableEdges = customizableEdges17;
        this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnSave.FillColor = System.Drawing.Color.Black;
        this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(236, 181);
        this.btnSave.Name = "btnSave";
        this.btnSave.PressedColor = System.Drawing.Color.White;
        this.btnSave.ShadowDecoration.CustomizableEdges = customizableEdges18;
        this.btnSave.Size = new System.Drawing.Size(106, 29);
        this.btnSave.TabIndex = 138;
        this.btnSave.Text = "Salvar";
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // guna2ControlBox1
        // 
        this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.guna2ControlBox1.BorderRadius = 10;
        this.guna2ControlBox1.CustomizableEdges = customizableEdges19;
        this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
        this.guna2ControlBox1.IconColor = System.Drawing.Color.DarkTurquoise;
        this.guna2ControlBox1.Location = new System.Drawing.Point(786, 7);
        this.guna2ControlBox1.Name = "guna2ControlBox1";
        this.guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges20;
        this.guna2ControlBox1.Size = new System.Drawing.Size(26, 26);
        this.guna2ControlBox1.TabIndex = 143;
        // 
        // FrmStockGroup
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.ClientSize = new System.Drawing.Size(814, 528);
        this.ControlBox = false;
        this.Controls.Add(this.guna2ControlBox1);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.labelFlag);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.panelGrid);
        this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Margin = new System.Windows.Forms.Padding(5);
        this.MaximumSize = new System.Drawing.Size(814, 528);
        this.MinimumSize = new System.Drawing.Size(814, 528);
        this.Name = "FrmStockGroup";
        this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
        this.Text = "Cadatrar Estoque";
        this.Load += new System.EventHandler(this.FrmStockGroup_Load);
        this.panelGrid.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
        this.ResumeLayout(false);
    }

    private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

    private Guna.UI2.WinForms.Guna2Button btnCancel;
    private Guna.UI2.WinForms.Guna2Button btnNew;
    private Guna.UI2.WinForms.Guna2Button btnDelete;
    private Guna.UI2.WinForms.Guna2Button btnEdit;
    private Guna.UI2.WinForms.Guna2Button btnSave;

    private Guna.UI2.WinForms.Guna2HtmlLabel labelFlag;
    private Guna.UI2.WinForms.Guna2TextBox txtName;

    private Guna.UI2.WinForms.Guna2Panel panelGrid;
    private Guna.UI2.WinForms.Guna2Button btnSearch;
    private System.Windows.Forms.Label labelRegisteredPaymants;
    private Guna.UI2.WinForms.Guna2TextBox txtSearch;
    private Guna.UI2.WinForms.Guna2DataGridView gridData;

    #endregion
}