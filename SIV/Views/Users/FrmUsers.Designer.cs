using System.ComponentModel;

namespace SIV.Views.Users;

partial class FrmUsers
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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        this.labelName = new System.Windows.Forms.Label();
        this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
        this.labelPassword = new System.Windows.Forms.Label();
        this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
        this.btnPartialAccess = new Guna.UI2.WinForms.Guna2RadioButton();
        this.btnFullAccess = new Guna.UI2.WinForms.Guna2RadioButton();
        this.cbJob = new Guna.UI2.WinForms.Guna2ComboBox();
        this.labelJob = new System.Windows.Forms.Label();
        this.labelAccess = new System.Windows.Forms.Label();
        this.btnSave = new Guna.UI2.WinForms.Guna2Button();
        this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
        this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
        this.btnNew = new Guna.UI2.WinForms.Guna2Button();
        this.txtRepeatPassword = new Guna.UI2.WinForms.Guna2TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.labelActive = new System.Windows.Forms.Label();
        this.btnActive = new Guna.UI2.WinForms.Guna2CheckBox();
        this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
        this.gridData = new Guna.UI2.WinForms.Guna2DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
        this.SuspendLayout();
        // 
        // labelName
        // 
        this.labelName.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelName.Location = new System.Drawing.Point(12, 39);
        this.labelName.Name = "labelName";
        this.labelName.Size = new System.Drawing.Size(93, 36);
        this.labelName.TabIndex = 1;
        this.labelName.Text = "Nome";
        this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
        this.txtName.TabIndex = 2;
        // 
        // labelPassword
        // 
        this.labelPassword.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelPassword.Location = new System.Drawing.Point(12, 108);
        this.labelPassword.Name = "labelPassword";
        this.labelPassword.Size = new System.Drawing.Size(93, 36);
        this.labelPassword.TabIndex = 3;
        this.labelPassword.Text = "Senha";
        this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // txtPassword
        // 
        this.txtPassword.Animated = true;
        this.txtPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.txtPassword.BorderRadius = 10;
        this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtPassword.CustomizableEdges = customizableEdges3;
        this.txtPassword.DefaultText = "";
        this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtPassword.Location = new System.Drawing.Point(111, 108);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.PasswordChar = '●';
        this.txtPassword.PlaceholderText = "";
        this.txtPassword.SelectedText = "";
        this.txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
        this.txtPassword.Size = new System.Drawing.Size(295, 36);
        this.txtPassword.TabIndex = 4;
        this.txtPassword.UseSystemPasswordChar = true;
        // 
        // btnPartialAccess
        // 
        this.btnPartialAccess.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.btnPartialAccess.CheckedState.BorderThickness = 0;
        this.btnPartialAccess.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
        this.btnPartialAccess.CheckedState.InnerColor = System.Drawing.Color.Aqua;
        this.btnPartialAccess.CheckedState.InnerOffset = -4;
        this.btnPartialAccess.Location = new System.Drawing.Point(435, 108);
        this.btnPartialAccess.Name = "btnPartialAccess";
        this.btnPartialAccess.Size = new System.Drawing.Size(213, 24);
        this.btnPartialAccess.TabIndex = 6;
        this.btnPartialAccess.Text = "Acesso Parcial";
        this.btnPartialAccess.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
        this.btnPartialAccess.UncheckedState.BorderThickness = 2;
        this.btnPartialAccess.UncheckedState.FillColor = System.Drawing.Color.Transparent;
        this.btnPartialAccess.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
        // 
        // btnFullAccess
        // 
        this.btnFullAccess.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.btnFullAccess.CheckedState.BorderThickness = 0;
        this.btnFullAccess.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
        this.btnFullAccess.CheckedState.InnerColor = System.Drawing.Color.Aqua;
        this.btnFullAccess.CheckedState.InnerOffset = -4;
        this.btnFullAccess.Location = new System.Drawing.Point(435, 78);
        this.btnFullAccess.Name = "btnFullAccess";
        this.btnFullAccess.Size = new System.Drawing.Size(213, 24);
        this.btnFullAccess.TabIndex = 7;
        this.btnFullAccess.Text = "Acesso Completo";
        this.btnFullAccess.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
        this.btnFullAccess.UncheckedState.BorderThickness = 2;
        this.btnFullAccess.UncheckedState.FillColor = System.Drawing.Color.Transparent;
        this.btnFullAccess.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
        // 
        // cbJob
        // 
        this.cbJob.BackColor = System.Drawing.Color.Transparent;
        this.cbJob.BorderRadius = 10;
        this.cbJob.CustomizableEdges = customizableEdges5;
        this.cbJob.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.cbJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbJob.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.cbJob.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.cbJob.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cbJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
        this.cbJob.ItemHeight = 30;
        this.cbJob.Items.AddRange(new object[] { "fvdfv", "dfvbsdfv", "dfvsfv" });
        this.cbJob.Location = new System.Drawing.Point(111, 246);
        this.cbJob.Name = "cbJob";
        this.cbJob.ShadowDecoration.CustomizableEdges = customizableEdges6;
        this.cbJob.Size = new System.Drawing.Size(295, 36);
        this.cbJob.TabIndex = 8;
        // 
        // labelJob
        // 
        this.labelJob.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelJob.Location = new System.Drawing.Point(12, 246);
        this.labelJob.Name = "labelJob";
        this.labelJob.Size = new System.Drawing.Size(93, 36);
        this.labelJob.TabIndex = 9;
        this.labelJob.Text = "Gargo";
        this.labelJob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // labelAccess
        // 
        this.labelAccess.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelAccess.Location = new System.Drawing.Point(429, 39);
        this.labelAccess.Name = "labelAccess";
        this.labelAccess.Size = new System.Drawing.Size(219, 36);
        this.labelAccess.TabIndex = 10;
        this.labelAccess.Text = "Permitir Acesso?";
        this.labelAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnSave
        // 
        this.btnSave.Animated = true;
        this.btnSave.BackColor = System.Drawing.Color.Transparent;
        this.btnSave.BorderRadius = 10;
        this.btnSave.CustomizableEdges = customizableEdges7;
        this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnSave.FillColor = System.Drawing.Color.Black;
        this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(236, 320);
        this.btnSave.Name = "btnSave";
        this.btnSave.ShadowDecoration.CustomizableEdges = customizableEdges8;
        this.btnSave.Size = new System.Drawing.Size(106, 29);
        this.btnSave.TabIndex = 11;
        this.btnSave.Text = "Salvar";
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
        this.btnEdit.Location = new System.Drawing.Point(348, 320);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges10;
        this.btnEdit.Size = new System.Drawing.Size(106, 29);
        this.btnEdit.TabIndex = 12;
        this.btnEdit.Text = "Editar";
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Animated = true;
        this.btnDelete.BackColor = System.Drawing.Color.Transparent;
        this.btnDelete.BorderRadius = 10;
        this.btnDelete.CustomizableEdges = customizableEdges11;
        this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnDelete.FillColor = System.Drawing.Color.Black;
        this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnDelete.ForeColor = System.Drawing.Color.White;
        this.btnDelete.Location = new System.Drawing.Point(460, 320);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges12;
        this.btnDelete.Size = new System.Drawing.Size(106, 29);
        this.btnDelete.TabIndex = 13;
        this.btnDelete.Text = "Excluir";
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnNew
        // 
        this.btnNew.Animated = true;
        this.btnNew.BackColor = System.Drawing.Color.Transparent;
        this.btnNew.BorderRadius = 10;
        this.btnNew.CustomizableEdges = customizableEdges13;
        this.btnNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnNew.FillColor = System.Drawing.Color.Black;
        this.btnNew.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.btnNew.ForeColor = System.Drawing.Color.White;
        this.btnNew.Location = new System.Drawing.Point(12, 320);
        this.btnNew.Name = "btnNew";
        this.btnNew.ShadowDecoration.CustomizableEdges = customizableEdges14;
        this.btnNew.Size = new System.Drawing.Size(106, 29);
        this.btnNew.TabIndex = 14;
        this.btnNew.Text = "Novo";
        this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
        // 
        // txtRepeatPassword
        // 
        this.txtRepeatPassword.Animated = true;
        this.txtRepeatPassword.BorderRadius = 10;
        this.txtRepeatPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtRepeatPassword.CustomizableEdges = customizableEdges15;
        this.txtRepeatPassword.DefaultText = "";
        this.txtRepeatPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtRepeatPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtRepeatPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtRepeatPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtRepeatPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtRepeatPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtRepeatPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtRepeatPassword.Location = new System.Drawing.Point(111, 177);
        this.txtRepeatPassword.Name = "txtRepeatPassword";
        this.txtRepeatPassword.PasswordChar = '●';
        this.txtRepeatPassword.PlaceholderText = "";
        this.txtRepeatPassword.SelectedText = "";
        this.txtRepeatPassword.ShadowDecoration.CustomizableEdges = customizableEdges16;
        this.txtRepeatPassword.Size = new System.Drawing.Size(295, 36);
        this.txtRepeatPassword.TabIndex = 16;
        this.txtRepeatPassword.UseSystemPasswordChar = true;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(12, 177);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(104, 36);
        this.label1.TabIndex = 15;
        this.label1.Text = "Repetir";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // labelActive
        // 
        this.labelActive.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelActive.Location = new System.Drawing.Point(429, 156);
        this.labelActive.Name = "labelActive";
        this.labelActive.Size = new System.Drawing.Size(219, 36);
        this.labelActive.TabIndex = 17;
        this.labelActive.Text = "Usuario Ativo?";
        this.labelActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnActive
        // 
        this.btnActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.btnActive.CheckedState.BorderRadius = 0;
        this.btnActive.CheckedState.BorderThickness = 0;
        this.btnActive.CheckedState.FillColor = System.Drawing.Color.Aqua;
        this.btnActive.CheckMarkColor = System.Drawing.Color.Black;
        this.btnActive.Location = new System.Drawing.Point(435, 195);
        this.btnActive.Name = "btnActive";
        this.btnActive.Size = new System.Drawing.Size(213, 24);
        this.btnActive.TabIndex = 18;
        this.btnActive.Text = "Ativado";
        this.btnActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
        this.btnActive.UncheckedState.BorderRadius = 0;
        this.btnActive.UncheckedState.BorderThickness = 0;
        this.btnActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
        // 
        // btnCancel
        // 
        this.btnCancel.Animated = true;
        this.btnCancel.BackColor = System.Drawing.Color.Transparent;
        this.btnCancel.BorderRadius = 10;
        this.btnCancel.CustomizableEdges = customizableEdges17;
        this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnCancel.FillColor = System.Drawing.Color.Black;
        this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(124, 320);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges18;
        this.btnCancel.Size = new System.Drawing.Size(106, 29);
        this.btnCancel.TabIndex = 19;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.gridData.DefaultCellStyle = dataGridViewCellStyle3;
        this.gridData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
        this.gridData.Location = new System.Drawing.Point(12, 405);
        this.gridData.Name = "gridData";
        this.gridData.ReadOnly = true;
        this.gridData.RowHeadersVisible = false;
        this.gridData.Size = new System.Drawing.Size(1040, 264);
        this.gridData.TabIndex = 20;
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
        this.gridData.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.gridData.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
        this.gridData.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        this.gridData.ThemeStyle.HeaderStyle.Height = 23;
        this.gridData.ThemeStyle.ReadOnly = true;
        this.gridData.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
        this.gridData.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.gridData.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.gridData.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.gridData.ThemeStyle.RowsStyle.Height = 22;
        this.gridData.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
        this.gridData.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
        this.gridData.DoubleClick += new System.EventHandler(this.gridData_DoubleClick);
        // 
        // FrmUsers
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1064, 681);
        this.Controls.Add(this.gridData);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnActive);
        this.Controls.Add(this.labelActive);
        this.Controls.Add(this.txtRepeatPassword);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.btnNew);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.labelAccess);
        this.Controls.Add(this.labelJob);
        this.Controls.Add(this.cbJob);
        this.Controls.Add(this.btnFullAccess);
        this.Controls.Add(this.btnPartialAccess);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.labelPassword);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.labelName);
        this.Font = new System.Drawing.Font("Century Gothic", 12F);
        this.Margin = new System.Windows.Forms.Padding(5);
        this.Name = "FrmUsers";
        this.Text = "FrmUsers";
        this.Load += new System.EventHandler(this.FrmUsers_Load);
        ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
        this.ResumeLayout(false);
    }

    private Guna.UI2.WinForms.Guna2DataGridView gridData;

    private Guna.UI2.WinForms.Guna2Button btnCancel;

    private System.Windows.Forms.Label labelActive;
    private Guna.UI2.WinForms.Guna2CheckBox btnActive;

    private Guna.UI2.WinForms.Guna2TextBox txtRepeatPassword;
    private System.Windows.Forms.Label label1;

    private Guna.UI2.WinForms.Guna2Button btnEdit;
    private Guna.UI2.WinForms.Guna2Button btnDelete;
    private Guna.UI2.WinForms.Guna2Button btnNew;

    private Guna.UI2.WinForms.Guna2Button btnSave;

    private System.Windows.Forms.Label labelAccess;

    private System.Windows.Forms.Label labelJob;

    private Guna.UI2.WinForms.Guna2ComboBox cbJob;

    private Guna.UI2.WinForms.Guna2RadioButton btnFullAccess;

    private Guna.UI2.WinForms.Guna2RadioButton btnPartialAccess;

    private System.Windows.Forms.Label labelPassword;
    private Guna.UI2.WinForms.Guna2TextBox txtPassword;

    private System.Windows.Forms.Label labelName;
    private Guna.UI2.WinForms.Guna2TextBox txtName;

    #endregion
}