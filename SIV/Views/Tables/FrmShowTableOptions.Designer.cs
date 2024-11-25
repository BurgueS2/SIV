using System.ComponentModel;

namespace SIV.Views.Tables;

partial class FrmShowTableOptions
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
        this.btnOpenTable = new Guna.UI2.WinForms.Guna2Button();
        this.btnPartial = new Guna.UI2.WinForms.Guna2Button();
        this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
        this.btnCloseTable = new Guna.UI2.WinForms.Guna2Button();
        this.labelStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.SuspendLayout();
        // 
        // btnOpenTable
        // 
        this.btnOpenTable.Animated = true;
        this.btnOpenTable.BorderColor = System.Drawing.Color.Gainsboro;
        this.btnOpenTable.BorderRadius = 15;
        this.btnOpenTable.BorderThickness = 1;
        this.btnOpenTable.CustomizableEdges = customizableEdges1;
        this.btnOpenTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnOpenTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnOpenTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnOpenTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnOpenTable.FillColor = System.Drawing.Color.WhiteSmoke;
        this.btnOpenTable.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
        this.btnOpenTable.ForeColor = System.Drawing.Color.Black;
        this.btnOpenTable.Location = new System.Drawing.Point(25, 149);
        this.btnOpenTable.Margin = new System.Windows.Forms.Padding(5);
        this.btnOpenTable.Name = "btnOpenTable";
        this.btnOpenTable.ShadowDecoration.CustomizableEdges = customizableEdges2;
        this.btnOpenTable.Size = new System.Drawing.Size(137, 107);
        this.btnOpenTable.TabIndex = 0;
        this.btnOpenTable.Text = "Abrir";
        this.btnOpenTable.Click += new System.EventHandler(this.btnOpenTable_Click);
        // 
        // btnPartial
        // 
        this.btnPartial.Animated = true;
        this.btnPartial.BorderColor = System.Drawing.Color.Gainsboro;
        this.btnPartial.BorderRadius = 15;
        this.btnPartial.BorderThickness = 1;
        this.btnPartial.CustomizableEdges = customizableEdges3;
        this.btnPartial.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnPartial.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnPartial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnPartial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnPartial.FillColor = System.Drawing.Color.WhiteSmoke;
        this.btnPartial.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
        this.btnPartial.ForeColor = System.Drawing.Color.Black;
        this.btnPartial.Location = new System.Drawing.Point(172, 149);
        this.btnPartial.Margin = new System.Windows.Forms.Padding(5);
        this.btnPartial.Name = "btnPartial";
        this.btnPartial.ShadowDecoration.CustomizableEdges = customizableEdges4;
        this.btnPartial.Size = new System.Drawing.Size(137, 107);
        this.btnPartial.TabIndex = 1;
        this.btnPartial.Text = "Parcial";
        // 
        // btnCancel
        // 
        this.btnCancel.Animated = true;
        this.btnCancel.BorderColor = System.Drawing.Color.LightGray;
        this.btnCancel.BorderRadius = 15;
        this.btnCancel.BorderThickness = 1;
        this.btnCancel.CustomizableEdges = customizableEdges5;
        this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnCancel.FillColor = System.Drawing.Color.WhiteSmoke;
        this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
        this.btnCancel.ForeColor = System.Drawing.Color.Black;
        this.btnCancel.Location = new System.Drawing.Point(466, 149);
        this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges6;
        this.btnCancel.Size = new System.Drawing.Size(137, 107);
        this.btnCancel.TabIndex = 2;
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnCloseTable
        // 
        this.btnCloseTable.Animated = true;
        this.btnCloseTable.BorderColor = System.Drawing.Color.Gainsboro;
        this.btnCloseTable.BorderRadius = 15;
        this.btnCloseTable.BorderThickness = 1;
        this.btnCloseTable.CustomizableEdges = customizableEdges7;
        this.btnCloseTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
        this.btnCloseTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
        this.btnCloseTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
        this.btnCloseTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        this.btnCloseTable.FillColor = System.Drawing.Color.WhiteSmoke;
        this.btnCloseTable.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
        this.btnCloseTable.ForeColor = System.Drawing.Color.Black;
        this.btnCloseTable.Location = new System.Drawing.Point(319, 149);
        this.btnCloseTable.Margin = new System.Windows.Forms.Padding(5);
        this.btnCloseTable.Name = "btnCloseTable";
        this.btnCloseTable.ShadowDecoration.CustomizableEdges = customizableEdges8;
        this.btnCloseTable.Size = new System.Drawing.Size(137, 107);
        this.btnCloseTable.TabIndex = 3;
        this.btnCloseTable.Text = "Fechar";
        this.btnCloseTable.Click += new System.EventHandler(this.btnCloseTable_Click);
        // 
        // labelStatus
        // 
        this.labelStatus.AutoSize = false;
        this.labelStatus.BackColor = System.Drawing.Color.Transparent;
        this.labelStatus.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelStatus.Location = new System.Drawing.Point(25, 73);
        this.labelStatus.Name = "labelStatus";
        this.labelStatus.Size = new System.Drawing.Size(578, 50);
        this.labelStatus.TabIndex = 35;
        this.labelStatus.Text = "A mesa {mesa} está {status}";
        this.labelStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // FrmShowTableOptions
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.ClientSize = new System.Drawing.Size(637, 307);
        this.ControlBox = false;
        this.Controls.Add(this.labelStatus);
        this.Controls.Add(this.btnCloseTable);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnPartial);
        this.Controls.Add(this.btnOpenTable);
        this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Margin = new System.Windows.Forms.Padding(5);
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(637, 307);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(637, 307);
        this.Name = "FrmShowTableOptions";
        this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
        this.Text = "Opções da Mesa";
        this.ResumeLayout(false);
    }

    private Guna.UI2.WinForms.Guna2HtmlLabel labelStatus;

    private Guna.UI2.WinForms.Guna2Button btnCancel;

    private Guna.UI2.WinForms.Guna2Button btnPartial;

    private Guna.UI2.WinForms.Guna2Button btnCloseTable;

    private Guna.UI2.WinForms.Guna2Button btnOpenTable;

    #endregion
}