using System.ComponentModel;

namespace SIV.Views.Login;

partial class FrmLogin
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
        this.components = new System.ComponentModel.Container();
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
        this.design = new Guna.UI2.WinForms.Guna2PictureBox();
        this.labelDiscretionLogo = new System.Windows.Forms.Label();
        this.labelDiscretion = new System.Windows.Forms.Label();
        this.labelWelcome = new System.Windows.Forms.Label();
        this.logoTipo = new System.Windows.Forms.PictureBox();
        this.labelLogo = new System.Windows.Forms.Label();
        this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
        this.btnEnter = new Guna.UI2.WinForms.Guna2Button();
        this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
        this.labelPassword = new System.Windows.Forms.Label();
        this.labelTop = new System.Windows.Forms.Label();
        this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
        this.labelUser = new System.Windows.Forms.Label();
        this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
        this.btnExit = new Guna.UI2.WinForms.Guna2Button();
        ((System.ComponentModel.ISupportInitialize)(this.design)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.logoTipo)).BeginInit();
        this.SuspendLayout();
        // 
        // design
        // 
        this.design.CustomizableEdges = customizableEdges1;
        this.design.Image = global::SIV.Properties.Resources.painelLogo;
        this.design.ImageRotate = 0F;
        this.design.Location = new System.Drawing.Point(0, -1);
        this.design.Name = "design";
        this.design.ShadowDecoration.CustomizableEdges = customizableEdges2;
        this.design.Size = new System.Drawing.Size(741, 392);
        this.design.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.design.TabIndex = 15;
        this.design.TabStop = false;
        // 
        // labelDiscretionLogo
        // 
        this.labelDiscretionLogo.BackColor = System.Drawing.Color.LightCyan;
        this.labelDiscretionLogo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelDiscretionLogo.Location = new System.Drawing.Point(61, 78);
        this.labelDiscretionLogo.Name = "labelDiscretionLogo";
        this.labelDiscretionLogo.Size = new System.Drawing.Size(203, 23);
        this.labelDiscretionLogo.TabIndex = 32;
        this.labelDiscretionLogo.Text = "Sistema Inteligente de Vendas";
        // 
        // labelDiscretion
        // 
        this.labelDiscretion.BackColor = System.Drawing.Color.LightCyan;
        this.labelDiscretion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelDiscretion.Location = new System.Drawing.Point(45, 226);
        this.labelDiscretion.Name = "labelDiscretion";
        this.labelDiscretion.Size = new System.Drawing.Size(248, 45);
        this.labelDiscretion.TabIndex = 31;
        this.labelDiscretion.Text = "Acesse sua conta, usando usuário e senha!";
        // 
        // labelWelcome
        // 
        this.labelWelcome.BackColor = System.Drawing.Color.LightCyan;
        this.labelWelcome.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelWelcome.Location = new System.Drawing.Point(45, 181);
        this.labelWelcome.Name = "labelWelcome";
        this.labelWelcome.Size = new System.Drawing.Size(205, 45);
        this.labelWelcome.TabIndex = 30;
        this.labelWelcome.Text = "Seja Bem-Vindo";
        // 
        // logoTipo
        // 
        this.logoTipo.BackColor = System.Drawing.Color.LightCyan;
        this.logoTipo.Image = global::SIV.Properties.Resources.logotipo;
        this.logoTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.logoTipo.Location = new System.Drawing.Point(96, 29);
        this.logoTipo.Name = "logoTipo";
        this.logoTipo.Size = new System.Drawing.Size(46, 46);
        this.logoTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.logoTipo.TabIndex = 28;
        this.logoTipo.TabStop = false;
        // 
        // labelLogo
        // 
        this.labelLogo.AutoSize = true;
        this.labelLogo.BackColor = System.Drawing.Color.LightCyan;
        this.labelLogo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
        this.labelLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.labelLogo.Location = new System.Drawing.Point(135, 31);
        this.labelLogo.Name = "labelLogo";
        this.labelLogo.Size = new System.Drawing.Size(61, 40);
        this.labelLogo.TabIndex = 29;
        this.labelLogo.Text = "SIV";
        // 
        // btnCancel
        // 
        this.btnCancel.Animated = true;
        this.btnCancel.AutoRoundedCorners = true;
        this.btnCancel.BackColor = System.Drawing.Color.Transparent;
        this.btnCancel.BorderRadius = 13;
        this.btnCancel.CustomizableEdges = customizableEdges3;
        this.btnCancel.DefaultAutoSize = true;
        this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnCancel.FillColor = System.Drawing.Color.Black;
        this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11.25F);
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(596, 279);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
        this.btnCancel.Size = new System.Drawing.Size(101, 29);
        this.btnCancel.TabIndex = 4;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.UseTransparentBackground = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnEnter
        // 
        this.btnEnter.Animated = true;
        this.btnEnter.AutoRoundedCorners = true;
        this.btnEnter.BackColor = System.Drawing.Color.Transparent;
        this.btnEnter.BorderColor = System.Drawing.Color.DarkRed;
        this.btnEnter.BorderRadius = 13;
        this.btnEnter.CustomizableEdges = customizableEdges5;
        this.btnEnter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnEnter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnEnter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnEnter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnEnter.FillColor = System.Drawing.Color.Black;
        this.btnEnter.Font = new System.Drawing.Font("Century Gothic", 11.25F);
        this.btnEnter.ForeColor = System.Drawing.Color.White;
        this.btnEnter.Location = new System.Drawing.Point(489, 279);
        this.btnEnter.Name = "btnEnter";
        this.btnEnter.ShadowDecoration.CustomizableEdges = customizableEdges6;
        this.btnEnter.Size = new System.Drawing.Size(101, 29);
        this.btnEnter.TabIndex = 3;
        this.btnEnter.Text = "Entrar";
        this.btnEnter.UseTransparentBackground = true;
        this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
        // 
        // txtPassword
        // 
        this.txtPassword.Animated = true;
        this.txtPassword.AutoRoundedCorners = true;
        this.txtPassword.BackColor = System.Drawing.Color.Transparent;
        this.txtPassword.BorderRadius = 17;
        this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtPassword.CustomizableEdges = customizableEdges7;
        this.txtPassword.DefaultText = "";
        this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtPassword.Location = new System.Drawing.Point(489, 213);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.PasswordChar = '●';
        this.txtPassword.PlaceholderText = "";
        this.txtPassword.SelectedText = "";
        this.txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
        this.txtPassword.Size = new System.Drawing.Size(208, 36);
        this.txtPassword.TabIndex = 2;
        this.txtPassword.UseSystemPasswordChar = true;
        // 
        // labelPassword
        // 
        this.labelPassword.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelPassword.Location = new System.Drawing.Point(361, 211);
        this.labelPassword.Name = "labelPassword";
        this.labelPassword.Size = new System.Drawing.Size(122, 45);
        this.labelPassword.TabIndex = 24;
        this.labelPassword.Text = "Senha";
        // 
        // labelTop
        // 
        this.labelTop.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelTop.Location = new System.Drawing.Point(411, 40);
        this.labelTop.Name = "labelTop";
        this.labelTop.Size = new System.Drawing.Size(248, 45);
        this.labelTop.TabIndex = 23;
        this.labelTop.Text = "Preencha os Dados";
        // 
        // txtUser
        // 
        this.txtUser.Animated = true;
        this.txtUser.AutoRoundedCorners = true;
        this.txtUser.BackColor = System.Drawing.Color.Transparent;
        this.txtUser.BorderRadius = 17;
        this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtUser.CustomizableEdges = customizableEdges9;
        this.txtUser.DefaultText = "";
        this.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
        this.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
        this.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
        this.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
        this.txtUser.Location = new System.Drawing.Point(489, 138);
        this.txtUser.Name = "txtUser";
        this.txtUser.PasswordChar = '\0';
        this.txtUser.PlaceholderText = "";
        this.txtUser.SelectedText = "";
        this.txtUser.ShadowDecoration.CustomizableEdges = customizableEdges10;
        this.txtUser.Size = new System.Drawing.Size(208, 36);
        this.txtUser.TabIndex = 1;
        // 
        // labelUser
        // 
        this.labelUser.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelUser.Location = new System.Drawing.Point(361, 136);
        this.labelUser.Name = "labelUser";
        this.labelUser.Size = new System.Drawing.Size(122, 45);
        this.labelUser.TabIndex = 21;
        this.labelUser.Text = "Usuário";
        // 
        // guna2AnimateWindow1
        // 
        this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
        this.guna2AnimateWindow1.TargetForm = this;
        // 
        // btnExit
        // 
        this.btnExit.Animated = true;
        this.btnExit.AutoRoundedCorners = true;
        this.btnExit.BackColor = System.Drawing.Color.Transparent;
        this.btnExit.BorderColor = System.Drawing.Color.DarkRed;
        this.btnExit.BorderRadius = 13;
        this.btnExit.CustomizableEdges = customizableEdges11;
        this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnExit.FillColor = System.Drawing.Color.Transparent;
        this.btnExit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnExit.ForeColor = System.Drawing.Color.DimGray;
        this.btnExit.Location = new System.Drawing.Point(718, -1);
        this.btnExit.Name = "btnExit";
        this.btnExit.ShadowDecoration.CustomizableEdges = customizableEdges12;
        this.btnExit.Size = new System.Drawing.Size(36, 29);
        this.btnExit.TabIndex = 33;
        this.btnExit.Text = "X";
        this.btnExit.UseTransparentBackground = true;
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        // 
        // FrmLogin
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.ClientSize = new System.Drawing.Size(753, 391);
        this.ControlBox = false;
        this.Controls.Add(this.btnExit);
        this.Controls.Add(this.labelDiscretionLogo);
        this.Controls.Add(this.labelDiscretion);
        this.Controls.Add(this.labelWelcome);
        this.Controls.Add(this.logoTipo);
        this.Controls.Add(this.labelLogo);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnEnter);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.labelPassword);
        this.Controls.Add(this.labelTop);
        this.Controls.Add(this.txtUser);
        this.Controls.Add(this.labelUser);
        this.Controls.Add(this.design);
        this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Margin = new System.Windows.Forms.Padding(5);
        this.MaximumSize = new System.Drawing.Size(753, 391);
        this.MinimumSize = new System.Drawing.Size(753, 391);
        this.Name = "FrmLogin";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "LOGIN";
        ((System.ComponentModel.ISupportInitialize)(this.design)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.logoTipo)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Guna.UI2.WinForms.Guna2Button btnExit;

    private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;

    private System.Windows.Forms.Label labelDiscretionLogo;
    private System.Windows.Forms.Label labelDiscretion;
    private System.Windows.Forms.Label labelWelcome;
    private System.Windows.Forms.PictureBox logoTipo;
    private System.Windows.Forms.Label labelLogo;
    private Guna.UI2.WinForms.Guna2Button btnCancel;
    private Guna.UI2.WinForms.Guna2Button btnEnter;
    private Guna.UI2.WinForms.Guna2TextBox txtPassword;
    private System.Windows.Forms.Label labelPassword;
    private System.Windows.Forms.Label labelTop;
    private Guna.UI2.WinForms.Guna2TextBox txtUser;
    private System.Windows.Forms.Label labelUser;

    private Guna.UI2.WinForms.Guna2PictureBox design;

    #endregion
}