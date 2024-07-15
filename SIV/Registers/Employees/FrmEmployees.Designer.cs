using System.ComponentModel;

namespace SIV.Registers.Employees;

partial class FrmEmployees
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
        this.LabelName = new MetroFramework.Controls.MetroLabel();
        this.labelPhone = new MetroFramework.Controls.MetroLabel();
        this.labelAddress = new MetroFramework.Controls.MetroLabel();
        this.labelCpf = new MetroFramework.Controls.MetroLabel();
        this.labelJob = new MetroFramework.Controls.MetroLabel();
        this.txtPhone = new MetroFramework.Controls.MetroTextBox();
        this.txtName = new MetroFramework.Controls.MetroTextBox();
        this.txtAddress = new MetroFramework.Controls.MetroTextBox();
        this.cbJob = new MetroFramework.Controls.MetroComboBox();
        this.photo = new System.Windows.Forms.PictureBox();
        this.txtCpf = new System.Windows.Forms.MaskedTextBox();
        this.GridData = new MetroFramework.Controls.MetroGrid();
        this.btnNew = new MetroFramework.Controls.MetroButton();
        this.btnPhoto = new MetroFramework.Controls.MetroButton();
        this.btnDelete = new MetroFramework.Controls.MetroButton();
        this.btnEdit = new MetroFramework.Controls.MetroButton();
        this.btnSave = new MetroFramework.Controls.MetroButton();
        this.btnCancel = new MetroFramework.Controls.MetroButton();
        ((System.ComponentModel.ISupportInitialize)(this.logotipo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
        this.SuspendLayout();
        // 
        // logotipo
        // 
        this.logotipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.logotipo.Location = new System.Drawing.Point(9, 18);
        this.logotipo.Name = "logotipo";
        this.logotipo.Size = new System.Drawing.Size(39, 39);
        this.logotipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.logotipo.TabIndex = 18;
        this.logotipo.TabStop = false;
        // 
        // LabelName
        // 
        this.LabelName.AutoSize = true;
        this.LabelName.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.LabelName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.LabelName.Location = new System.Drawing.Point(26, 87);
        this.LabelName.Name = "LabelName";
        this.LabelName.Size = new System.Drawing.Size(61, 25);
        this.LabelName.TabIndex = 19;
        this.LabelName.Text = "Nome";
        this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelPhone
        // 
        this.labelPhone.AutoSize = true;
        this.labelPhone.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelPhone.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelPhone.Location = new System.Drawing.Point(26, 150);
        this.labelPhone.Name = "labelPhone";
        this.labelPhone.Size = new System.Drawing.Size(77, 25);
        this.labelPhone.TabIndex = 20;
        this.labelPhone.Text = "Telefone";
        this.labelPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelAddress
        // 
        this.labelAddress.AutoSize = true;
        this.labelAddress.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelAddress.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelAddress.Location = new System.Drawing.Point(26, 213);
        this.labelAddress.Name = "labelAddress";
        this.labelAddress.Size = new System.Drawing.Size(85, 25);
        this.labelAddress.TabIndex = 21;
        this.labelAddress.Text = "Endereço";
        // 
        // labelCpf
        // 
        this.labelCpf.AutoSize = true;
        this.labelCpf.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelCpf.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelCpf.Location = new System.Drawing.Point(449, 87);
        this.labelCpf.Name = "labelCpf";
        this.labelCpf.Size = new System.Drawing.Size(42, 25);
        this.labelCpf.TabIndex = 22;
        this.labelCpf.Text = "CPF";
        this.labelCpf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelJob
        // 
        this.labelJob.AutoSize = true;
        this.labelJob.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelJob.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelJob.Location = new System.Drawing.Point(449, 152);
        this.labelJob.Name = "labelJob";
        this.labelJob.Size = new System.Drawing.Size(60, 25);
        this.labelJob.TabIndex = 23;
        this.labelJob.Text = "Cargo";
        this.labelJob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txtPhone
        // 
        // 
        // 
        // 
        this.txtPhone.CustomButton.Image = null;
        this.txtPhone.CustomButton.Location = new System.Drawing.Point(196, 1);
        this.txtPhone.CustomButton.Name = "";
        this.txtPhone.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtPhone.CustomButton.TabIndex = 1;
        this.txtPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtPhone.CustomButton.UseSelectable = true;
        this.txtPhone.CustomButton.Visible = false;
        this.txtPhone.Lines = new string[0];
        this.txtPhone.Location = new System.Drawing.Point(136, 152);
        this.txtPhone.MaxLength = 11;
        this.txtPhone.Name = "txtPhone";
        this.txtPhone.PasswordChar = '\0';
        this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtPhone.SelectedText = "";
        this.txtPhone.SelectionLength = 0;
        this.txtPhone.SelectionStart = 0;
        this.txtPhone.ShortcutsEnabled = true;
        this.txtPhone.Size = new System.Drawing.Size(218, 23);
        this.txtPhone.TabIndex = 24;
        this.txtPhone.UseSelectable = true;
        this.txtPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
        this.txtName.TabIndex = 25;
        this.txtName.UseSelectable = true;
        this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // txtAddress
        // 
        // 
        // 
        // 
        this.txtAddress.CustomButton.Image = null;
        this.txtAddress.CustomButton.Location = new System.Drawing.Point(196, 1);
        this.txtAddress.CustomButton.Name = "";
        this.txtAddress.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtAddress.CustomButton.TabIndex = 1;
        this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtAddress.CustomButton.UseSelectable = true;
        this.txtAddress.CustomButton.Visible = false;
        this.txtAddress.Lines = new string[0];
        this.txtAddress.Location = new System.Drawing.Point(136, 215);
        this.txtAddress.MaxLength = 255;
        this.txtAddress.Name = "txtAddress";
        this.txtAddress.PasswordChar = '\0';
        this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtAddress.SelectedText = "";
        this.txtAddress.SelectionLength = 0;
        this.txtAddress.SelectionStart = 0;
        this.txtAddress.ShortcutsEnabled = true;
        this.txtAddress.Size = new System.Drawing.Size(218, 23);
        this.txtAddress.TabIndex = 26;
        this.txtAddress.UseSelectable = true;
        this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // cbJob
        // 
        this.cbJob.FormattingEnabled = true;
        this.cbJob.ItemHeight = 23;
        this.cbJob.Location = new System.Drawing.Point(537, 150);
        this.cbJob.Name = "cbJob";
        this.cbJob.Size = new System.Drawing.Size(218, 29);
        this.cbJob.TabIndex = 27;
        this.cbJob.UseSelectable = true;
        this.cbJob.UseStyleColors = true;
        // 
        // photo
        // 
        this.photo.Location = new System.Drawing.Point(867, 72);
        this.photo.Name = "photo";
        this.photo.Size = new System.Drawing.Size(174, 174);
        this.photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.photo.TabIndex = 28;
        this.photo.TabStop = false;
        // 
        // txtCpf
        // 
        this.txtCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtCpf.Enabled = false;
        this.txtCpf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtCpf.Location = new System.Drawing.Point(537, 89);
        this.txtCpf.Mask = "000.000.000-00";
        this.txtCpf.Name = "txtCpf";
        this.txtCpf.Size = new System.Drawing.Size(218, 23);
        this.txtCpf.TabIndex = 29;
        // 
        // GridData
        // 
        this.GridData.AllowUserToAddRows = false;
        this.GridData.AllowUserToDeleteRows = false;
        this.GridData.AllowUserToResizeRows = false;
        this.GridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.GridData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.GridData.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.GridData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
        this.GridData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.GridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        this.GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.GridData.DefaultCellStyle = dataGridViewCellStyle2;
        this.GridData.EnableHeadersVisualStyles = false;
        this.GridData.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.GridData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.GridData.Location = new System.Drawing.Point(26, 312);
        this.GridData.Name = "GridData";
        this.GridData.ReadOnly = true;
        this.GridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.GridData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        this.GridData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        this.GridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.GridData.Size = new System.Drawing.Size(1015, 199);
        this.GridData.TabIndex = 30;
        this.GridData.UseStyleColors = true;
        this.GridData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridData_CellContentDoubleClick);
        // 
        // btnNew
        // 
        this.btnNew.Location = new System.Drawing.Point(26, 539);
        this.btnNew.Name = "btnNew";
        this.btnNew.Size = new System.Drawing.Size(75, 23);
        this.btnNew.TabIndex = 31;
        this.btnNew.Text = "Novo";
        this.btnNew.UseSelectable = true;
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // btnPhoto
        // 
        this.btnPhoto.Location = new System.Drawing.Point(919, 269);
        this.btnPhoto.Name = "btnPhoto";
        this.btnPhoto.Size = new System.Drawing.Size(75, 23);
        this.btnPhoto.TabIndex = 32;
        this.btnPhoto.Text = "Foto";
        this.btnPhoto.UseSelectable = true;
        this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(449, 539);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 33;
        this.btnDelete.Text = "Excluir";
        this.btnDelete.UseSelectable = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.Location = new System.Drawing.Point(346, 539);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new System.Drawing.Size(75, 23);
        this.btnEdit.TabIndex = 34;
        this.btnEdit.Text = "Editar";
        this.btnEdit.UseSelectable = true;
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(241, 539);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 23);
        this.btnSave.TabIndex = 35;
        this.btnSave.Text = "Salvar";
        this.btnSave.UseSelectable = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(136, 539);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 36;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.UseSelectable = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // FrmEmployees
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1067, 588);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnPhoto);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.GridData);
        this.Controls.Add(this.txtCpf);
        this.Controls.Add(this.photo);
        this.Controls.Add(this.cbJob);
        this.Controls.Add(this.txtAddress);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.txtPhone);
        this.Controls.Add(this.labelJob);
        this.Controls.Add(this.labelCpf);
        this.Controls.Add(this.labelAddress);
        this.Controls.Add(this.labelPhone);
        this.Controls.Add(this.LabelName);
        this.Controls.Add(this.logotipo);
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(1067, 588);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(1067, 588);
        this.Name = "FrmEmployees";
        this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
        this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
        this.ShowInTaskbar = false;
        this.Text = "CADASTRO DE FUNCIONÁRIOS";
        this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
        this.Load += new System.EventHandler(this.FrmEmployees_Load);
        ((System.ComponentModel.ISupportInitialize)(this.logotipo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private MetroFramework.Controls.MetroButton btnNew;
    private MetroFramework.Controls.MetroButton btnPhoto;
    private MetroFramework.Controls.MetroButton btnDelete;
    private MetroFramework.Controls.MetroButton btnEdit;
    private MetroFramework.Controls.MetroButton btnSave;
    private MetroFramework.Controls.MetroButton btnCancel;

    private MetroFramework.Controls.MetroGrid GridData;

    private System.Windows.Forms.MaskedTextBox txtCpf;

    private System.Windows.Forms.PictureBox photo;

    private MetroFramework.Controls.MetroComboBox cbJob;

    private MetroFramework.Controls.MetroLabel LabelName;
    private MetroFramework.Controls.MetroLabel labelPhone;
    private MetroFramework.Controls.MetroLabel labelAddress;
    private MetroFramework.Controls.MetroLabel labelCpf;
    private MetroFramework.Controls.MetroLabel labelJob;
    private MetroFramework.Controls.MetroTextBox txtPhone;
    private MetroFramework.Controls.MetroTextBox txtName;
    private MetroFramework.Controls.MetroTextBox txtAddress;

    private System.Windows.Forms.PictureBox logotipo;

    #endregion
}