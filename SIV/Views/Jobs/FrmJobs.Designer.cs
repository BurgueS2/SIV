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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        this.txtName = new MetroFramework.Controls.MetroTextBox();
        this.LabelName = new MetroFramework.Controls.MetroLabel();
        this.btnCancel = new MetroFramework.Controls.MetroButton();
        this.btnSave = new MetroFramework.Controls.MetroButton();
        this.btnEdit = new MetroFramework.Controls.MetroButton();
        this.btnDelete = new MetroFramework.Controls.MetroButton();
        this.btnNew = new MetroFramework.Controls.MetroButton();
        this.panelGrid = new System.Windows.Forms.Panel();
        this.btnSearch = new System.Windows.Forms.Button();
        this.txtSearch = new MetroFramework.Controls.MetroTextBox();
        this.labelRegisteredEmployees = new System.Windows.Forms.Label();
        this.gridData = new MetroFramework.Controls.MetroGrid();
        this.panelGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
        this.SuspendLayout();
        // 
        // txtName
        // 
        // 
        // 
        // 
        this.txtName.CustomButton.Image = null;
        this.txtName.CustomButton.Location = new System.Drawing.Point(196, 1);
        this.txtName.CustomButton.Name = "";
        this.txtName.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtName.CustomButton.TabIndex = 1;
        this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtName.CustomButton.UseSelectable = true;
        this.txtName.CustomButton.Visible = false;
        this.txtName.Lines = new string[0];
        this.txtName.Location = new System.Drawing.Point(88, 39);
        this.txtName.MaxLength = 255;
        this.txtName.Name = "txtName";
        this.txtName.PasswordChar = '\0';
        this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtName.SelectedText = "";
        this.txtName.SelectionLength = 0;
        this.txtName.SelectionStart = 0;
        this.txtName.ShortcutsEnabled = true;
        this.txtName.Size = new System.Drawing.Size(218, 23);
        this.txtName.TabIndex = 27;
        this.txtName.UseSelectable = true;
        this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // LabelName
        // 
        this.LabelName.AutoSize = true;
        this.LabelName.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.LabelName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.LabelName.Location = new System.Drawing.Point(12, 37);
        this.LabelName.Name = "LabelName";
        this.LabelName.Size = new System.Drawing.Size(61, 25);
        this.LabelName.TabIndex = 26;
        this.LabelName.Text = "Nome";
        this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(122, 545);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 42;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.UseSelectable = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(227, 545);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 23);
        this.btnSave.TabIndex = 41;
        this.btnSave.Text = "Salvar";
        this.btnSave.UseSelectable = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.Location = new System.Drawing.Point(332, 545);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new System.Drawing.Size(75, 23);
        this.btnEdit.TabIndex = 40;
        this.btnEdit.Text = "Editar";
        this.btnEdit.UseSelectable = true;
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(435, 545);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 39;
        this.btnDelete.Text = "Excluir";
        this.btnDelete.UseSelectable = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnNew
        // 
        this.btnNew.Location = new System.Drawing.Point(12, 545);
        this.btnNew.Name = "btnNew";
        this.btnNew.Size = new System.Drawing.Size(75, 23);
        this.btnNew.TabIndex = 38;
        this.btnNew.Text = "Novo";
        this.btnNew.UseSelectable = true;
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // panelGrid
        // 
        this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.panelGrid.Controls.Add(this.btnSearch);
        this.panelGrid.Controls.Add(this.txtSearch);
        this.panelGrid.Controls.Add(this.labelRegisteredEmployees);
        this.panelGrid.Controls.Add(this.gridData);
        this.panelGrid.Location = new System.Drawing.Point(2, 164);
        this.panelGrid.Name = "panelGrid";
        this.panelGrid.Size = new System.Drawing.Size(1060, 294);
        this.panelGrid.TabIndex = 43;
        // 
        // btnSearch
        // 
        this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnSearch.FlatAppearance.BorderSize = 0;
        this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSearch.Image = global::SIV.Properties.Resources.icons8_localizar_e_substituir_26;
        this.btnSearch.Location = new System.Drawing.Point(266, 27);
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Size = new System.Drawing.Size(34, 23);
        this.btnSearch.TabIndex = 40;
        this.btnSearch.UseVisualStyleBackColor = true;
        // 
        // txtSearch
        // 
        // 
        // 
        // 
        this.txtSearch.CustomButton.Image = null;
        this.txtSearch.CustomButton.Location = new System.Drawing.Point(245, 1);
        this.txtSearch.CustomButton.Name = "";
        this.txtSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtSearch.CustomButton.TabIndex = 1;
        this.txtSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtSearch.CustomButton.UseSelectable = true;
        this.txtSearch.CustomButton.Visible = false;
        this.txtSearch.Lines = new string[0];
        this.txtSearch.Location = new System.Drawing.Point(0, 26);
        this.txtSearch.MaxLength = 255;
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.PasswordChar = '\0';
        this.txtSearch.PromptText = "Buscar";
        this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtSearch.SelectedText = "";
        this.txtSearch.SelectionLength = 0;
        this.txtSearch.SelectionStart = 0;
        this.txtSearch.ShortcutsEnabled = true;
        this.txtSearch.Size = new System.Drawing.Size(267, 23);
        this.txtSearch.TabIndex = 40;
        this.txtSearch.UseSelectable = true;
        this.txtSearch.WaterMark = "Buscar";
        this.txtSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // labelRegisteredEmployees
        // 
        this.labelRegisteredEmployees.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelRegisteredEmployees.Location = new System.Drawing.Point(0, 0);
        this.labelRegisteredEmployees.Name = "labelRegisteredEmployees";
        this.labelRegisteredEmployees.Size = new System.Drawing.Size(202, 23);
        this.labelRegisteredEmployees.TabIndex = 0;
        this.labelRegisteredEmployees.Text = "Cargos Cadastrados";
        // 
        // gridData
        // 
        this.gridData.AllowUserToAddRows = false;
        this.gridData.AllowUserToDeleteRows = false;
        this.gridData.AllowUserToResizeRows = false;
        this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.gridData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.gridData.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.gridData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
        this.gridData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.gridData.DefaultCellStyle = dataGridViewCellStyle2;
        this.gridData.EnableHeadersVisualStyles = false;
        this.gridData.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.gridData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.gridData.Location = new System.Drawing.Point(0, 55);
        this.gridData.Name = "gridData";
        this.gridData.ReadOnly = true;
        this.gridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Azure;
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.gridData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        this.gridData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.gridData.Size = new System.Drawing.Size(1060, 239);
        this.gridData.TabIndex = 30;
        this.gridData.UseStyleColors = true;
        this.gridData.DoubleClick += new System.EventHandler(this.gridData_DoubleClick);
        // 
        // FrmJobs
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1064, 681);
        this.Controls.Add(this.panelGrid);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.LabelName);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmJobs";
        this.ShowInTaskbar = false;
        this.Text = "Cadastro de Cargos";
        this.Load += new System.EventHandler(this.FrmJobs_Load);
        this.panelGrid.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Panel panelGrid;
    private System.Windows.Forms.Button btnSearch;
    private MetroFramework.Controls.MetroTextBox txtSearch;
    private System.Windows.Forms.Label labelRegisteredEmployees;
    private MetroFramework.Controls.MetroGrid gridData;

    private MetroFramework.Controls.MetroButton btnCancel;
    private MetroFramework.Controls.MetroButton btnSave;
    private MetroFramework.Controls.MetroButton btnEdit;
    private MetroFramework.Controls.MetroButton btnDelete;
    private MetroFramework.Controls.MetroButton btnNew;

    private MetroFramework.Controls.MetroTextBox txtName;
    private MetroFramework.Controls.MetroLabel LabelName;

    #endregion
}