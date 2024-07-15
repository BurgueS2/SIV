using System.ComponentModel;

namespace SIV.Registers.Jobs;

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
        this.logotipo = new System.Windows.Forms.PictureBox();
        this.txtName = new MetroFramework.Controls.MetroTextBox();
        this.LabelName = new MetroFramework.Controls.MetroLabel();
        this.btnCancel = new MetroFramework.Controls.MetroButton();
        this.btnSave = new MetroFramework.Controls.MetroButton();
        this.btnEdit = new MetroFramework.Controls.MetroButton();
        this.btnDelete = new MetroFramework.Controls.MetroButton();
        this.btnNew = new MetroFramework.Controls.MetroButton();
        this.dgvJobs = new MetroFramework.Controls.MetroGrid();
        ((System.ComponentModel.ISupportInitialize)(this.logotipo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
        this.SuspendLayout();
        // 
        // logotipo
        // 
        this.logotipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.logotipo.Location = new System.Drawing.Point(9, 18);
        this.logotipo.Name = "logotipo";
        this.logotipo.Size = new System.Drawing.Size(39, 39);
        this.logotipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.logotipo.TabIndex = 19;
        this.logotipo.TabStop = false;
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
        this.txtName.Location = new System.Drawing.Point(136, 89);
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
        this.LabelName.Location = new System.Drawing.Point(26, 87);
        this.LabelName.Name = "LabelName";
        this.LabelName.Size = new System.Drawing.Size(61, 25);
        this.LabelName.TabIndex = 26;
        this.LabelName.Text = "Nome";
        this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(140, 433);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 42;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.UseSelectable = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(245, 433);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 23);
        this.btnSave.TabIndex = 41;
        this.btnSave.Text = "Salvar";
        this.btnSave.UseSelectable = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.Location = new System.Drawing.Point(350, 433);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new System.Drawing.Size(75, 23);
        this.btnEdit.TabIndex = 40;
        this.btnEdit.Text = "Editar";
        this.btnEdit.UseSelectable = true;
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(453, 433);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 39;
        this.btnDelete.Text = "Excluir";
        this.btnDelete.UseSelectable = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnNew
        // 
        this.btnNew.Location = new System.Drawing.Point(30, 433);
        this.btnNew.Name = "btnNew";
        this.btnNew.Size = new System.Drawing.Size(75, 23);
        this.btnNew.TabIndex = 38;
        this.btnNew.Text = "Novo";
        this.btnNew.UseSelectable = true;
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // dgvJobs
        // 
        this.dgvJobs.AllowUserToAddRows = false;
        this.dgvJobs.AllowUserToDeleteRows = false;
        this.dgvJobs.AllowUserToResizeRows = false;
        this.dgvJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvJobs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
        this.dgvJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvJobs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
        this.dgvJobs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.dgvJobs.DefaultCellStyle = dataGridViewCellStyle2;
        this.dgvJobs.EnableHeadersVisualStyles = false;
        this.dgvJobs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.dgvJobs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.dgvJobs.Location = new System.Drawing.Point(23, 178);
        this.dgvJobs.Name = "dgvJobs";
        this.dgvJobs.ReadOnly = true;
        this.dgvJobs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvJobs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        this.dgvJobs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        this.dgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvJobs.Size = new System.Drawing.Size(855, 199);
        this.dgvJobs.TabIndex = 37;
        this.dgvJobs.UseStyleColors = true;
        this.dgvJobs.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobs_CellContentDoubleClick);
        // 
        // FrmJobs
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(901, 489);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.dgvJobs);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.LabelName);
        this.Controls.Add(this.logotipo);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmJobs";
        this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
        this.ShowInTaskbar = false;
        this.Text = "Cadastro de Cargos";
        this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
        this.Load += new System.EventHandler(this.FrmJobs_Load);
        ((System.ComponentModel.ISupportInitialize)(this.logotipo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private MetroFramework.Controls.MetroButton btnCancel;
    private MetroFramework.Controls.MetroButton btnSave;
    private MetroFramework.Controls.MetroButton btnEdit;
    private MetroFramework.Controls.MetroButton btnDelete;
    private MetroFramework.Controls.MetroButton btnNew;
    private MetroFramework.Controls.MetroGrid dgvJobs;

    private MetroFramework.Controls.MetroTextBox txtName;
    private MetroFramework.Controls.MetroLabel LabelName;

    private System.Windows.Forms.PictureBox logotipo;

    #endregion
}