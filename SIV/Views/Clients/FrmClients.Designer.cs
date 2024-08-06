using System.ComponentModel;

namespace SIV.Views.Clients;

partial class FrmClients
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
        this.btnCancel = new MetroFramework.Controls.MetroButton();
        this.btnSave = new MetroFramework.Controls.MetroButton();
        this.btnEdit = new MetroFramework.Controls.MetroButton();
        this.btnDelete = new MetroFramework.Controls.MetroButton();
        this.btnNew = new MetroFramework.Controls.MetroButton();
        this.txtCpf = new System.Windows.Forms.MaskedTextBox();
        this.txtAddress = new MetroFramework.Controls.MetroTextBox();
        this.txtName = new MetroFramework.Controls.MetroTextBox();
        this.txtPhone = new MetroFramework.Controls.MetroTextBox();
        this.labelCpf = new MetroFramework.Controls.MetroLabel();
        this.labelAddress = new MetroFramework.Controls.MetroLabel();
        this.labelPhone = new MetroFramework.Controls.MetroLabel();
        this.labelName = new MetroFramework.Controls.MetroLabel();
        this.txtCode = new MetroFramework.Controls.MetroTextBox();
        this.labelCode = new MetroFramework.Controls.MetroLabel();
        this.txtEmail = new MetroFramework.Controls.MetroTextBox();
        this.labelEmail = new MetroFramework.Controls.MetroLabel();
        this.txtValue = new MetroFramework.Controls.MetroTextBox();
        this.labelDebt = new MetroFramework.Controls.MetroLabel();
        this.txtSearchCpf = new System.Windows.Forms.MaskedTextBox();
        this.logotipo = new System.Windows.Forms.PictureBox();
        this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
        this.btnUnlocked = new MetroFramework.Controls.MetroRadioButton();
        this.btnBlocked = new MetroFramework.Controls.MetroRadioButton();
        this.panelGrid = new System.Windows.Forms.Panel();
        this.btnSearchCpf = new System.Windows.Forms.Button();
        this.btnSearchName = new System.Windows.Forms.Button();
        this.txtSearchName = new MetroFramework.Controls.MetroTextBox();
        this.labelRegisteredEmployees = new System.Windows.Forms.Label();
        this.gridData = new MetroFramework.Controls.MetroGrid();
        ((System.ComponentModel.ISupportInitialize)(this.logotipo)).BeginInit();
        this.panelGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
        this.SuspendLayout();
        // 
        // btnCancel
        // 
        this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnCancel.Location = new System.Drawing.Point(134, 553);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 53;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.UseSelectable = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnSave
        // 
        this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnSave.Location = new System.Drawing.Point(233, 553);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 23);
        this.btnSave.TabIndex = 52;
        this.btnSave.Text = "Salvar";
        this.btnSave.UseSelectable = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnEdit.Location = new System.Drawing.Point(337, 553);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new System.Drawing.Size(75, 23);
        this.btnEdit.TabIndex = 51;
        this.btnEdit.Text = "Editar";
        this.btnEdit.UseSelectable = true;
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnDelete.Location = new System.Drawing.Point(435, 553);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 50;
        this.btnDelete.Text = "Excluir";
        this.btnDelete.UseSelectable = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnNew
        // 
        this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnNew.Location = new System.Drawing.Point(34, 553);
        this.btnNew.Name = "btnNew";
        this.btnNew.Size = new System.Drawing.Size(75, 23);
        this.btnNew.TabIndex = 49;
        this.btnNew.Text = "Novo";
        this.btnNew.UseSelectable = true;
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // txtCpf
        // 
        this.txtCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtCpf.Enabled = false;
        this.txtCpf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtCpf.Location = new System.Drawing.Point(691, 33);
        this.txtCpf.Mask = "000.000.000-00";
        this.txtCpf.Name = "txtCpf";
        this.txtCpf.Size = new System.Drawing.Size(318, 23);
        this.txtCpf.TabIndex = 4;
        // 
        // txtAddress
        // 
        // 
        // 
        // 
        this.txtAddress.CustomButton.Image = null;
        this.txtAddress.CustomButton.Location = new System.Drawing.Point(380, 1);
        this.txtAddress.CustomButton.Name = "";
        this.txtAddress.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtAddress.CustomButton.TabIndex = 1;
        this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtAddress.CustomButton.UseSelectable = true;
        this.txtAddress.CustomButton.Visible = false;
        this.txtAddress.Enabled = false;
        this.txtAddress.Lines = new string[0];
        this.txtAddress.Location = new System.Drawing.Point(109, 153);
        this.txtAddress.MaxLength = 255;
        this.txtAddress.Name = "txtAddress";
        this.txtAddress.PasswordChar = '\0';
        this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtAddress.SelectedText = "";
        this.txtAddress.SelectionLength = 0;
        this.txtAddress.SelectionStart = 0;
        this.txtAddress.ShortcutsEnabled = true;
        this.txtAddress.Size = new System.Drawing.Size(402, 23);
        this.txtAddress.TabIndex = 7;
        this.txtAddress.UseSelectable = true;
        this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // txtName
        // 
        // 
        // 
        // 
        this.txtName.CustomButton.Image = null;
        this.txtName.CustomButton.Location = new System.Drawing.Point(246, 1);
        this.txtName.CustomButton.Name = "";
        this.txtName.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtName.CustomButton.TabIndex = 1;
        this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtName.CustomButton.UseSelectable = true;
        this.txtName.CustomButton.Visible = false;
        this.txtName.Enabled = false;
        this.txtName.Lines = new string[0];
        this.txtName.Location = new System.Drawing.Point(109, 33);
        this.txtName.MaxLength = 255;
        this.txtName.Name = "txtName";
        this.txtName.PasswordChar = '\0';
        this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtName.SelectedText = "";
        this.txtName.SelectionLength = 0;
        this.txtName.SelectionStart = 0;
        this.txtName.ShortcutsEnabled = true;
        this.txtName.Size = new System.Drawing.Size(268, 23);
        this.txtName.TabIndex = 3;
        this.txtName.UseSelectable = true;
        this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // txtPhone
        // 
        // 
        // 
        // 
        this.txtPhone.CustomButton.Image = null;
        this.txtPhone.CustomButton.Location = new System.Drawing.Point(296, 1);
        this.txtPhone.CustomButton.Name = "";
        this.txtPhone.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtPhone.CustomButton.TabIndex = 1;
        this.txtPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtPhone.CustomButton.UseSelectable = true;
        this.txtPhone.CustomButton.Visible = false;
        this.txtPhone.Enabled = false;
        this.txtPhone.Lines = new string[0];
        this.txtPhone.Location = new System.Drawing.Point(691, 93);
        this.txtPhone.MaxLength = 11;
        this.txtPhone.Name = "txtPhone";
        this.txtPhone.PasswordChar = '\0';
        this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtPhone.SelectedText = "";
        this.txtPhone.SelectionLength = 0;
        this.txtPhone.SelectionStart = 0;
        this.txtPhone.ShortcutsEnabled = true;
        this.txtPhone.Size = new System.Drawing.Size(318, 23);
        this.txtPhone.TabIndex = 6;
        this.txtPhone.UseSelectable = true;
        this.txtPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // labelCpf
        // 
        this.labelCpf.AutoSize = true;
        this.labelCpf.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelCpf.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelCpf.Location = new System.Drawing.Point(587, 33);
        this.labelCpf.Name = "labelCpf";
        this.labelCpf.Size = new System.Drawing.Size(42, 25);
        this.labelCpf.TabIndex = 41;
        this.labelCpf.Text = "CPF";
        this.labelCpf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelAddress
        // 
        this.labelAddress.AutoSize = true;
        this.labelAddress.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelAddress.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelAddress.Location = new System.Drawing.Point(12, 153);
        this.labelAddress.Name = "labelAddress";
        this.labelAddress.Size = new System.Drawing.Size(85, 25);
        this.labelAddress.TabIndex = 40;
        this.labelAddress.Text = "Endereço";
        // 
        // labelPhone
        // 
        this.labelPhone.AutoSize = true;
        this.labelPhone.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelPhone.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelPhone.Location = new System.Drawing.Point(587, 93);
        this.labelPhone.Name = "labelPhone";
        this.labelPhone.Size = new System.Drawing.Size(77, 25);
        this.labelPhone.TabIndex = 39;
        this.labelPhone.Text = "Telefone";
        this.labelPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelName
        // 
        this.labelName.AutoSize = true;
        this.labelName.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelName.Location = new System.Drawing.Point(12, 33);
        this.labelName.Name = "labelName";
        this.labelName.Size = new System.Drawing.Size(61, 25);
        this.labelName.TabIndex = 38;
        this.labelName.Text = "Nome";
        this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txtCode
        // 
        // 
        // 
        // 
        this.txtCode.CustomButton.Image = null;
        this.txtCode.CustomButton.Location = new System.Drawing.Point(51, 1);
        this.txtCode.CustomButton.Name = "";
        this.txtCode.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtCode.CustomButton.TabIndex = 1;
        this.txtCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtCode.CustomButton.UseSelectable = true;
        this.txtCode.CustomButton.Visible = false;
        this.txtCode.Enabled = false;
        this.txtCode.Lines = new string[0];
        this.txtCode.Location = new System.Drawing.Point(438, 33);
        this.txtCode.MaxLength = 255;
        this.txtCode.Name = "txtCode";
        this.txtCode.PasswordChar = '\0';
        this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtCode.SelectedText = "";
        this.txtCode.SelectionLength = 0;
        this.txtCode.SelectionStart = 0;
        this.txtCode.ShortcutsEnabled = true;
        this.txtCode.Size = new System.Drawing.Size(73, 23);
        this.txtCode.TabIndex = 55;
        this.txtCode.UseSelectable = true;
        this.txtCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // labelCode
        // 
        this.labelCode.AutoSize = true;
        this.labelCode.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelCode.Location = new System.Drawing.Point(383, 33);
        this.labelCode.Name = "labelCode";
        this.labelCode.Size = new System.Drawing.Size(49, 25);
        this.labelCode.TabIndex = 54;
        this.labelCode.Text = "Cod.";
        this.labelCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txtEmail
        // 
        // 
        // 
        // 
        this.txtEmail.CustomButton.Image = null;
        this.txtEmail.CustomButton.Location = new System.Drawing.Point(380, 1);
        this.txtEmail.CustomButton.Name = "";
        this.txtEmail.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtEmail.CustomButton.TabIndex = 1;
        this.txtEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtEmail.CustomButton.UseSelectable = true;
        this.txtEmail.CustomButton.Visible = false;
        this.txtEmail.Enabled = false;
        this.txtEmail.Lines = new string[0];
        this.txtEmail.Location = new System.Drawing.Point(109, 93);
        this.txtEmail.MaxLength = 255;
        this.txtEmail.Name = "txtEmail";
        this.txtEmail.PasswordChar = '\0';
        this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtEmail.SelectedText = "";
        this.txtEmail.SelectionLength = 0;
        this.txtEmail.SelectionStart = 0;
        this.txtEmail.ShortcutsEnabled = true;
        this.txtEmail.Size = new System.Drawing.Size(402, 23);
        this.txtEmail.TabIndex = 5;
        this.txtEmail.UseSelectable = true;
        this.txtEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // labelEmail
        // 
        this.labelEmail.AutoSize = true;
        this.labelEmail.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelEmail.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelEmail.Location = new System.Drawing.Point(12, 93);
        this.labelEmail.Name = "labelEmail";
        this.labelEmail.Size = new System.Drawing.Size(61, 25);
        this.labelEmail.TabIndex = 56;
        this.labelEmail.Text = "E-Mail";
        // 
        // txtValue
        // 
        // 
        // 
        // 
        this.txtValue.CustomButton.Image = null;
        this.txtValue.CustomButton.Location = new System.Drawing.Point(296, 1);
        this.txtValue.CustomButton.Name = "";
        this.txtValue.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtValue.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtValue.CustomButton.TabIndex = 1;
        this.txtValue.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtValue.CustomButton.UseSelectable = true;
        this.txtValue.CustomButton.Visible = false;
        this.txtValue.Lines = new string[0];
        this.txtValue.Location = new System.Drawing.Point(691, 153);
        this.txtValue.MaxLength = 11;
        this.txtValue.Name = "txtValue";
        this.txtValue.PasswordChar = '\0';
        this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtValue.SelectedText = "";
        this.txtValue.SelectionLength = 0;
        this.txtValue.SelectionStart = 0;
        this.txtValue.ShortcutsEnabled = true;
        this.txtValue.Size = new System.Drawing.Size(318, 23);
        this.txtValue.TabIndex = 8;
        this.txtValue.UseSelectable = true;
        this.txtValue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtValue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // labelDebt
        // 
        this.labelDebt.AutoSize = true;
        this.labelDebt.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.labelDebt.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.labelDebt.Location = new System.Drawing.Point(587, 153);
        this.labelDebt.Name = "labelDebt";
        this.labelDebt.Size = new System.Drawing.Size(66, 25);
        this.labelDebt.TabIndex = 58;
        this.labelDebt.Text = "Debito";
        this.labelDebt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txtSearchCpf
        // 
        this.txtSearchCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtSearchCpf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtSearchCpf.Location = new System.Drawing.Point(306, 26);
        this.txtSearchCpf.Mask = "000.000.000-00";
        this.txtSearchCpf.Name = "txtSearchCpf";
        this.txtSearchCpf.Size = new System.Drawing.Size(239, 23);
        this.txtSearchCpf.TabIndex = 2;
        // 
        // logotipo
        // 
        this.logotipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.logotipo.Location = new System.Drawing.Point(9, 18);
        this.logotipo.Name = "logotipo";
        this.logotipo.Size = new System.Drawing.Size(39, 39);
        this.logotipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.logotipo.TabIndex = 37;
        this.logotipo.TabStop = false;
        // 
        // metroLabel1
        // 
        this.metroLabel1.AutoSize = true;
        this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        this.metroLabel1.Location = new System.Drawing.Point(1083, 33);
        this.metroLabel1.Name = "metroLabel1";
        this.metroLabel1.Size = new System.Drawing.Size(153, 25);
        this.metroLabel1.TabIndex = 79;
        this.metroLabel1.Text = "Status do Cliente?";
        this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnUnlocked
        // 
        this.btnUnlocked.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
        this.btnUnlocked.Location = new System.Drawing.Point(1083, 112);
        this.btnUnlocked.Name = "btnUnlocked";
        this.btnUnlocked.Size = new System.Drawing.Size(148, 24);
        this.btnUnlocked.TabIndex = 78;
        this.btnUnlocked.Text = "Desbloqueado ";
        this.btnUnlocked.UseSelectable = true;
        // 
        // btnBlocked
        // 
        this.btnBlocked.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
        this.btnBlocked.Location = new System.Drawing.Point(1083, 82);
        this.btnBlocked.Name = "btnBlocked";
        this.btnBlocked.Size = new System.Drawing.Size(148, 24);
        this.btnBlocked.TabIndex = 77;
        this.btnBlocked.Text = "Bloqueado";
        this.btnBlocked.UseSelectable = true;
        // 
        // panelGrid
        // 
        this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.panelGrid.Controls.Add(this.btnSearchCpf);
        this.panelGrid.Controls.Add(this.btnSearchName);
        this.panelGrid.Controls.Add(this.txtSearchName);
        this.panelGrid.Controls.Add(this.labelRegisteredEmployees);
        this.panelGrid.Controls.Add(this.gridData);
        this.panelGrid.Controls.Add(this.txtSearchCpf);
        this.panelGrid.Location = new System.Drawing.Point(0, 268);
        this.panelGrid.Name = "panelGrid";
        this.panelGrid.Size = new System.Drawing.Size(1252, 245);
        this.panelGrid.TabIndex = 81;
        // 
        // btnSearchCpf
        // 
        this.btnSearchCpf.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnSearchCpf.FlatAppearance.BorderSize = 0;
        this.btnSearchCpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSearchCpf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSearchCpf.Image = global::SIV.Properties.Resources.icons8_localizar_e_substituir_26;
        this.btnSearchCpf.Location = new System.Drawing.Point(545, 26);
        this.btnSearchCpf.Name = "btnSearchCpf";
        this.btnSearchCpf.Size = new System.Drawing.Size(34, 23);
        this.btnSearchCpf.TabIndex = 82;
        this.btnSearchCpf.UseVisualStyleBackColor = true;
        this.btnSearchCpf.Click += new System.EventHandler(this.btnSearchCpf_Click);
        // 
        // btnSearchName
        // 
        this.btnSearchName.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.btnSearchName.FlatAppearance.BorderSize = 0;
        this.btnSearchName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSearchName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSearchName.Image = global::SIV.Properties.Resources.icons8_localizar_e_substituir_26;
        this.btnSearchName.Location = new System.Drawing.Point(266, 26);
        this.btnSearchName.Name = "btnSearchName";
        this.btnSearchName.Size = new System.Drawing.Size(34, 23);
        this.btnSearchName.TabIndex = 40;
        this.btnSearchName.UseVisualStyleBackColor = true;
        this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
        // 
        // txtSearchName
        // 
        // 
        // 
        // 
        this.txtSearchName.CustomButton.Image = null;
        this.txtSearchName.CustomButton.Location = new System.Drawing.Point(245, 1);
        this.txtSearchName.CustomButton.Name = "";
        this.txtSearchName.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.txtSearchName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.txtSearchName.CustomButton.TabIndex = 1;
        this.txtSearchName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.txtSearchName.CustomButton.UseSelectable = true;
        this.txtSearchName.CustomButton.Visible = false;
        this.txtSearchName.Lines = new string[0];
        this.txtSearchName.Location = new System.Drawing.Point(0, 26);
        this.txtSearchName.MaxLength = 255;
        this.txtSearchName.Name = "txtSearchName";
        this.txtSearchName.PasswordChar = '\0';
        this.txtSearchName.PromptText = "Buscar";
        this.txtSearchName.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.txtSearchName.SelectedText = "";
        this.txtSearchName.SelectionLength = 0;
        this.txtSearchName.SelectionStart = 0;
        this.txtSearchName.ShortcutsEnabled = true;
        this.txtSearchName.Size = new System.Drawing.Size(267, 23);
        this.txtSearchName.TabIndex = 40;
        this.txtSearchName.UseSelectable = true;
        this.txtSearchName.WaterMark = "Buscar";
        this.txtSearchName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.txtSearchName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // labelRegisteredEmployees
        // 
        this.labelRegisteredEmployees.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelRegisteredEmployees.Location = new System.Drawing.Point(0, 0);
        this.labelRegisteredEmployees.Name = "labelRegisteredEmployees";
        this.labelRegisteredEmployees.Size = new System.Drawing.Size(174, 23);
        this.labelRegisteredEmployees.TabIndex = 0;
        this.labelRegisteredEmployees.Text = "Clientes Cadastrados";
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
        this.gridData.Size = new System.Drawing.Size(1252, 224);
        this.gridData.TabIndex = 30;
        this.gridData.UseStyleColors = true;
        this.gridData.DoubleClick += new System.EventHandler(this.gridData_DoubleClick);
        // 
        // FrmClients
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.ClientSize = new System.Drawing.Size(1254, 681);
        this.Controls.Add(this.panelGrid);
        this.Controls.Add(this.metroLabel1);
        this.Controls.Add(this.btnUnlocked);
        this.Controls.Add(this.btnBlocked);
        this.Controls.Add(this.txtValue);
        this.Controls.Add(this.labelDebt);
        this.Controls.Add(this.txtEmail);
        this.Controls.Add(this.labelEmail);
        this.Controls.Add(this.txtCode);
        this.Controls.Add(this.labelCode);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.txtCpf);
        this.Controls.Add(this.txtAddress);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.txtPhone);
        this.Controls.Add(this.labelCpf);
        this.Controls.Add(this.labelAddress);
        this.Controls.Add(this.labelPhone);
        this.Controls.Add(this.labelName);
        this.Location = new System.Drawing.Point(15, 15);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmClients";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Cadastro de Clientes";
        this.Load += new System.EventHandler(this.FrmClients_Load);
        ((System.ComponentModel.ISupportInitialize)(this.logotipo)).EndInit();
        this.panelGrid.ResumeLayout(false);
        this.panelGrid.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button btnSearchCpf;

    private System.Windows.Forms.Panel panelGrid;
    
    private System.Windows.Forms.Label labelRegisteredEmployees;
    private MetroFramework.Controls.MetroGrid gridData;

    private MetroFramework.Controls.MetroLabel metroLabel1;

    private MetroFramework.Controls.MetroRadioButton btnUnlocked;

    private System.Windows.Forms.PictureBox logotipo;

    private System.Windows.Forms.Button btnSearchName;

    private MetroFramework.Controls.MetroTextBox txtSearchName;
    private System.Windows.Forms.MaskedTextBox txtSearchCpf;

    private MetroFramework.Controls.MetroRadioButton btnBlocked;

    private MetroFramework.Controls.MetroTextBox txtValue;
    private MetroFramework.Controls.MetroLabel labelDebt;

    private MetroFramework.Controls.MetroTextBox txtEmail;
    private MetroFramework.Controls.MetroLabel labelEmail;

    private MetroFramework.Controls.MetroTextBox txtCode;
    private MetroFramework.Controls.MetroLabel labelCode;

    private MetroFramework.Controls.MetroButton btnCancel;
    private MetroFramework.Controls.MetroButton btnSave;
    private MetroFramework.Controls.MetroButton btnEdit;
    private MetroFramework.Controls.MetroButton btnDelete;
    private MetroFramework.Controls.MetroButton btnNew;
    private System.Windows.Forms.MaskedTextBox txtCpf;
    private MetroFramework.Controls.MetroTextBox txtAddress;
    private MetroFramework.Controls.MetroTextBox txtName;
    private MetroFramework.Controls.MetroTextBox txtPhone;
    private MetroFramework.Controls.MetroLabel labelCpf;
    private MetroFramework.Controls.MetroLabel labelAddress;
    private MetroFramework.Controls.MetroLabel labelPhone;
    private MetroFramework.Controls.MetroLabel labelName;

    #endregion
}