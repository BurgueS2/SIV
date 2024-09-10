using System;
using System.ComponentModel;

namespace SIV.Views.Jobs;

partial class FrmJobs
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
        this.labelName = new System.Windows.Forms.Label();
        this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
        this.btnNew = new Guna.UI2.WinForms.Guna2Button();
        this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
        this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
        this.btnSave = new Guna.UI2.WinForms.Guna2Button();
        this.panelGrid = new Guna.UI2.WinForms.Guna2Panel();
        this.gridData = new Guna.UI2.WinForms.Guna2DataGridView();
        this.labelRegisteredEmployees = new System.Windows.Forms.Label();
        this.panelGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
        this.SuspendLayout();
        // 
        // txtName
        // 
        this.txtName.Animated = true;
        this.txtName.BorderRadius = 10;
        this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtName.CustomizableEdges = customizableEdges1;
        this.txtName.DefaultText = "";
        this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtName.Location = new System.Drawing.Point(111, 39);
        this.txtName.Name = "txtName";
        this.txtName.PasswordChar = '\0';
        this.txtName.PlaceholderText = "";
        this.txtName.SelectedText = "";
        this.txtName.ShadowDecoration.CustomizableEdges = customizableEdges2;
        this.txtName.Size = new System.Drawing.Size(295, 36);
        this.txtName.TabIndex = 4;
        // 
        // labelName
        // 
        this.labelName.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelName.Location = new System.Drawing.Point(12, 39);
        this.labelName.Name = "labelName";
        this.labelName.Size = new System.Drawing.Size(93, 36);
        this.labelName.TabIndex = 5;
        this.labelName.Text = "Nome";
        this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnCancel
        // 
        this.btnCancel.Animated = true;
        this.btnCancel.BackColor = System.Drawing.Color.Transparent;
        this.btnCancel.BorderRadius = 10;
        this.btnCancel.CustomizableEdges = customizableEdges3;
        this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnCancel.FillColor = System.Drawing.Color.Black;
        this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(127, 420);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.PressedColor = System.Drawing.Color.White;
        this.btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
        this.btnCancel.Size = new System.Drawing.Size(106, 29);
        this.btnCancel.TabIndex = 29;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnNew
        // 
        this.btnNew.Animated = true;
        this.btnNew.BackColor = System.Drawing.Color.Transparent;
        this.btnNew.BorderRadius = 10;
        this.btnNew.CustomizableEdges = customizableEdges5;
        this.btnNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnNew.FillColor = System.Drawing.Color.Black;
        this.btnNew.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.btnNew.ForeColor = System.Drawing.Color.White;
        this.btnNew.Location = new System.Drawing.Point(15, 420);
        this.btnNew.Name = "btnNew";
        this.btnNew.PressedColor = System.Drawing.Color.White;
        this.btnNew.ShadowDecoration.CustomizableEdges = customizableEdges6;
        this.btnNew.Size = new System.Drawing.Size(106, 29);
        this.btnNew.TabIndex = 28;
        this.btnNew.Text = "Novo";
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Animated = true;
        this.btnDelete.BackColor = System.Drawing.Color.Transparent;
        this.btnDelete.BorderRadius = 10;
        this.btnDelete.CustomizableEdges = customizableEdges7;
        this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnDelete.FillColor = System.Drawing.Color.Black;
        this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnDelete.ForeColor = System.Drawing.Color.White;
        this.btnDelete.Location = new System.Drawing.Point(463, 420);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.PressedColor = System.Drawing.Color.White;
        this.btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges8;
        this.btnDelete.Size = new System.Drawing.Size(106, 29);
        this.btnDelete.TabIndex = 27;
        this.btnDelete.Text = "Excluir";
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.Animated = true;
        this.btnEdit.BackColor = System.Drawing.Color.Transparent;
        this.btnEdit.BorderRadius = 10;
        this.btnEdit.CustomizableEdges = customizableEdges9;
        this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnEdit.FillColor = System.Drawing.Color.Black;
        this.btnEdit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnEdit.ForeColor = System.Drawing.Color.White;
        this.btnEdit.Location = new System.Drawing.Point(351, 420);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.PressedColor = System.Drawing.Color.White;
        this.btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges10;
        this.btnEdit.Size = new System.Drawing.Size(106, 29);
        this.btnEdit.TabIndex = 26;
        this.btnEdit.Text = "Editar";
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnSave
        // 
        this.btnSave.Animated = true;
        this.btnSave.BackColor = System.Drawing.Color.Transparent;
        this.btnSave.BorderRadius = 10;
        this.btnSave.CustomizableEdges = customizableEdges11;
        this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnSave.FillColor = System.Drawing.Color.Black;
        this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(239, 420);
        this.btnSave.Name = "btnSave";
        this.btnSave.PressedColor = System.Drawing.Color.White;
        this.btnSave.ShadowDecoration.CustomizableEdges = customizableEdges12;
        this.btnSave.Size = new System.Drawing.Size(106, 29);
        this.btnSave.TabIndex = 25;
        this.btnSave.Text = "Salvar";
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // panelGrid
        // 
        this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.panelGrid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
        this.panelGrid.BorderRadius = 15;
        this.panelGrid.BorderThickness = 1;
        this.panelGrid.Controls.Add(this.gridData);
        this.panelGrid.Controls.Add(this.labelRegisteredEmployees);
        this.panelGrid.CustomizableEdges = customizableEdges13;
        this.panelGrid.FillColor = System.Drawing.Color.Transparent;
        this.panelGrid.Location = new System.Drawing.Point(12, 474);
        this.panelGrid.Name = "panelGrid";
        this.panelGrid.ShadowDecoration.CustomizableEdges = customizableEdges14;
        this.panelGrid.Size = new System.Drawing.Size(1056, 234);
        this.panelGrid.TabIndex = 137;
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
        this.gridData.Location = new System.Drawing.Point(3, 39);
        this.gridData.Name = "gridData";
        this.gridData.ReadOnly = true;
        this.gridData.RowHeadersVisible = false;
        this.gridData.Size = new System.Drawing.Size(1050, 182);
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
        // labelRegisteredEmployees
        // 
        this.labelRegisteredEmployees.BackColor = System.Drawing.Color.Transparent;
        this.labelRegisteredEmployees.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelRegisteredEmployees.Location = new System.Drawing.Point(3, 0);
        this.labelRegisteredEmployees.Name = "labelRegisteredEmployees";
        this.labelRegisteredEmployees.Size = new System.Drawing.Size(207, 36);
        this.labelRegisteredEmployees.TabIndex = 27;
        this.labelRegisteredEmployees.Text = "Clientes Cadastrados";
        this.labelRegisteredEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // FrmJobs
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1080, 720);
        this.Controls.Add(this.panelGrid);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.labelName);
        this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(5);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmJobs";
        this.ShowInTaskbar = false;
        this.Text = "Cadastro de Cargos";
        this.Load += new System.EventHandler(this.FrmJobs_Load);
        this.panelGrid.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
        this.ResumeLayout(false);
    }

    private Guna.UI2.WinForms.Guna2Panel panelGrid;
    private Guna.UI2.WinForms.Guna2DataGridView gridData;
    private System.Windows.Forms.Label labelRegisteredEmployees;

    private Guna.UI2.WinForms.Guna2Button btnCancel;
    private Guna.UI2.WinForms.Guna2Button btnNew;
    private Guna.UI2.WinForms.Guna2Button btnDelete;
    private Guna.UI2.WinForms.Guna2Button btnEdit;
    private Guna.UI2.WinForms.Guna2Button btnSave;

    private Guna.UI2.WinForms.Guna2TextBox txtName;
    private System.Windows.Forms.Label labelName;

    #endregion
}