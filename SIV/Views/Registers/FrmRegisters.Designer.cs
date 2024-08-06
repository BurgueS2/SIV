using System.ComponentModel;

namespace SIV.Views.Registers;

partial class FrmRegisters
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
        this.btnClient = new System.Windows.Forms.Button();
        this.btnEmployee = new System.Windows.Forms.Button();
        this.btnJob = new System.Windows.Forms.Button();
        this.btnSupplier = new System.Windows.Forms.Button();
        this.panelMenuRegister = new System.Windows.Forms.Panel();
        this.btnProduct = new System.Windows.Forms.Button();
        this.displayPanel = new System.Windows.Forms.Panel();
        this.panelMenuRegister.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnClient
        // 
        this.btnClient.AccessibleDescription = "";
        this.btnClient.AccessibleName = "";
        this.btnClient.BackColor = System.Drawing.Color.LightCyan;
        this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClient.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.btnClient.Image = global::SIV.Properties.Resources.icons8_cadastro_32;
        this.btnClient.Location = new System.Drawing.Point(-1, 104);
        this.btnClient.Name = "btnClient";
        this.btnClient.Size = new System.Drawing.Size(199, 106);
        this.btnClient.TabIndex = 0;
        this.btnClient.Text = "   Cadastrar Cliente  ";
        this.btnClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        this.btnClient.UseVisualStyleBackColor = false;
        this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
        // 
        // btnEmployee
        // 
        this.btnEmployee.BackColor = System.Drawing.Color.LightCyan;
        this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Arrow;
        this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnEmployee.Image = global::SIV.Properties.Resources.icons8_cadastro_32;
        this.btnEmployee.Location = new System.Drawing.Point(-1, -1);
        this.btnEmployee.Name = "btnEmployee";
        this.btnEmployee.Size = new System.Drawing.Size(199, 106);
        this.btnEmployee.TabIndex = 0;
        this.btnEmployee.Text = "     C. Funcionário    ";
        this.btnEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        this.btnEmployee.UseVisualStyleBackColor = false;
        this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
        // 
        // btnJob
        // 
        this.btnJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.btnJob.BackColor = System.Drawing.Color.LightCyan;
        this.btnJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnJob.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.btnJob.Image = global::SIV.Properties.Resources.icons8_cadastro_32;
        this.btnJob.Location = new System.Drawing.Point(-1, 209);
        this.btnJob.Name = "btnJob";
        this.btnJob.Size = new System.Drawing.Size(199, 106);
        this.btnJob.TabIndex = 0;
        this.btnJob.Text = "   Cadastrar Cargo   ";
        this.btnJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        this.btnJob.UseVisualStyleBackColor = false;
        this.btnJob.Click += new System.EventHandler(this.btnJob_Click);
        // 
        // btnSupplier
        // 
        this.btnSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSupplier.BackColor = System.Drawing.Color.LightCyan;
        this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSupplier.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.btnSupplier.Image = global::SIV.Properties.Resources.icons8_cadastro_32;
        this.btnSupplier.Location = new System.Drawing.Point(-1, 314);
        this.btnSupplier.Name = "btnSupplier";
        this.btnSupplier.Size = new System.Drawing.Size(197, 106);
        this.btnSupplier.TabIndex = 11;
        this.btnSupplier.Text = "    C. Fornecedor    ";
        this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        this.btnSupplier.UseVisualStyleBackColor = false;
        this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
        // 
        // panelMenuRegister
        // 
        this.panelMenuRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
        this.panelMenuRegister.BackColor = System.Drawing.Color.LightCyan;
        this.panelMenuRegister.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.panelMenuRegister.Controls.Add(this.btnProduct);
        this.panelMenuRegister.Controls.Add(this.btnSupplier);
        this.panelMenuRegister.Controls.Add(this.btnEmployee);
        this.panelMenuRegister.Controls.Add(this.btnClient);
        this.panelMenuRegister.Controls.Add(this.btnJob);
        this.panelMenuRegister.Location = new System.Drawing.Point(-1, -1);
        this.panelMenuRegister.Name = "panelMenuRegister";
        this.panelMenuRegister.Size = new System.Drawing.Size(197, 685);
        this.panelMenuRegister.TabIndex = 11;
        // 
        // btnProduct
        // 
        this.btnProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.btnProduct.BackColor = System.Drawing.Color.LightCyan;
        this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.btnProduct.Image = global::SIV.Properties.Resources.icons8_cadastro_32;
        this.btnProduct.Location = new System.Drawing.Point(-1, 419);
        this.btnProduct.Name = "btnProduct";
        this.btnProduct.Size = new System.Drawing.Size(199, 106);
        this.btnProduct.TabIndex = 12;
        this.btnProduct.Text = "  Cadastrar Produto";
        this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        this.btnProduct.UseVisualStyleBackColor = false;
        this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
        // 
        // displayPanel
        // 
        this.displayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.displayPanel.Location = new System.Drawing.Point(203, 12);
        this.displayPanel.Name = "displayPanel";
        this.displayPanel.Size = new System.Drawing.Size(1046, 657);
        this.displayPanel.TabIndex = 12;
        // 
        // FrmRegisters
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1261, 681);
        this.Controls.Add(this.displayPanel);
        this.Controls.Add(this.panelMenuRegister);
        this.Name = "FrmRegisters";
        this.Text = "CADASTRO";
        this.Load += new System.EventHandler(this.FrmRegisters_Load);
        this.panelMenuRegister.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel displayPanel;

    private System.Windows.Forms.Button btnProduct;

    private System.Windows.Forms.Panel panelMenuRegister;

    private System.Windows.Forms.Button btnSupplier;

    private System.Windows.Forms.Button btnJob;

    private System.Windows.Forms.Button btnEmployee;

    private System.Windows.Forms.Button btnClient;

    #endregion
}