﻿namespace SIV.Views
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.MenuRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRegistrationUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRegistrationEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRegistrationClient = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRegistrationSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRegistrationJob = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProductsProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProductsStock = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovements = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovementsCashFlow = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovementsSales = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovementsExpenses = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportSales = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportInputOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportExpenses = new System.Windows.Forms.ToolStripMenuItem();
            this.Exiting = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnCashFlow = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.panelBar = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.labelSIV = new System.Windows.Forms.Label();
            this.logotipo = new System.Windows.Forms.PictureBox();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.MenuMain.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelBar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logotipo)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            this.MenuMain.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.MenuMain, "MenuMain");
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuRegistration, this.MenuProducts, this.MenuMovements, this.MenuReport, this.Exiting });
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // MenuRegistration
            // 
            this.MenuRegistration.BackColor = System.Drawing.Color.Transparent;
            this.MenuRegistration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuRegistrationUser, this.MenuRegistrationSupplier, this.MenuRegistrationJob });
            resources.ApplyResources(this.MenuRegistration, "MenuRegistration");
            this.MenuRegistration.Name = "MenuRegistration";
            // 
            // MenuRegistrationUser
            // 
            this.MenuRegistrationUser.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuRegistrationEmployee, this.MenuRegistrationClient });
            this.MenuRegistrationUser.Name = "MenuRegistrationUser";
            resources.ApplyResources(this.MenuRegistrationUser, "MenuRegistrationUser");
            // 
            // MenuRegistrationEmployee
            // 
            this.MenuRegistrationEmployee.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationEmployee.Name = "MenuRegistrationEmployee";
            resources.ApplyResources(this.MenuRegistrationEmployee, "MenuRegistrationEmployee");
            this.MenuRegistrationEmployee.Click += new System.EventHandler(this.MenuRegistrationEmployee_Click);
            // 
            // MenuRegistrationClient
            // 
            this.MenuRegistrationClient.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationClient.Name = "MenuRegistrationClient";
            resources.ApplyResources(this.MenuRegistrationClient, "MenuRegistrationClient");
            this.MenuRegistrationClient.Click += new System.EventHandler(this.MenuRegistrationClient_Click);
            // 
            // MenuRegistrationSupplier
            // 
            this.MenuRegistrationSupplier.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationSupplier.Name = "MenuRegistrationSupplier";
            resources.ApplyResources(this.MenuRegistrationSupplier, "MenuRegistrationSupplier");
            // 
            // MenuRegistrationJob
            // 
            this.MenuRegistrationJob.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationJob.Name = "MenuRegistrationJob";
            resources.ApplyResources(this.MenuRegistrationJob, "MenuRegistrationJob");
            this.MenuRegistrationJob.Click += new System.EventHandler(this.MenuRegistrationJob_Click);
            // 
            // MenuProducts
            // 
            this.MenuProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuProductsProduct, this.MenuProductsStock });
            this.MenuProducts.Name = "MenuProducts";
            resources.ApplyResources(this.MenuProducts, "MenuProducts");
            // 
            // MenuProductsProduct
            // 
            this.MenuProductsProduct.Name = "MenuProductsProduct";
            resources.ApplyResources(this.MenuProductsProduct, "MenuProductsProduct");
            // 
            // MenuProductsStock
            // 
            this.MenuProductsStock.Name = "MenuProductsStock";
            resources.ApplyResources(this.MenuProductsStock, "MenuProductsStock");
            // 
            // MenuMovements
            // 
            this.MenuMovements.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuMovementsCashFlow });
            this.MenuMovements.Name = "MenuMovements";
            resources.ApplyResources(this.MenuMovements, "MenuMovements");
            // 
            // MenuMovementsCashFlow
            // 
            this.MenuMovementsCashFlow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuMovementsSales, this.MenuMovementsExpenses });
            this.MenuMovementsCashFlow.Name = "MenuMovementsCashFlow";
            resources.ApplyResources(this.MenuMovementsCashFlow, "MenuMovementsCashFlow");
            // 
            // MenuMovementsSales
            // 
            this.MenuMovementsSales.Name = "MenuMovementsSales";
            resources.ApplyResources(this.MenuMovementsSales, "MenuMovementsSales");
            // 
            // MenuMovementsExpenses
            // 
            this.MenuMovementsExpenses.Name = "MenuMovementsExpenses";
            resources.ApplyResources(this.MenuMovementsExpenses, "MenuMovementsExpenses");
            // 
            // MenuReport
            // 
            this.MenuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuReportProducts, this.MenuReportSales, this.MenuReportInputOutput, this.MenuReportExpenses });
            this.MenuReport.Name = "MenuReport";
            resources.ApplyResources(this.MenuReport, "MenuReport");
            // 
            // MenuReportProducts
            // 
            this.MenuReportProducts.Name = "MenuReportProducts";
            resources.ApplyResources(this.MenuReportProducts, "MenuReportProducts");
            // 
            // MenuReportSales
            // 
            this.MenuReportSales.Name = "MenuReportSales";
            resources.ApplyResources(this.MenuReportSales, "MenuReportSales");
            // 
            // MenuReportInputOutput
            // 
            this.MenuReportInputOutput.Name = "MenuReportInputOutput";
            resources.ApplyResources(this.MenuReportInputOutput, "MenuReportInputOutput");
            // 
            // MenuReportExpenses
            // 
            this.MenuReportExpenses.Name = "MenuReportExpenses";
            resources.ApplyResources(this.MenuReportExpenses, "MenuReportExpenses");
            // 
            // Exiting
            // 
            this.Exiting.Name = "Exiting";
            resources.ApplyResources(this.Exiting, "Exiting");
            this.Exiting.Click += new System.EventHandler(this.Exiting_Click);
            // 
            // panelMenu
            // 
            resources.ApplyResources(this.panelMenu, "panelMenu");
            this.panelMenu.BackColor = System.Drawing.Color.LightCyan;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnCashFlow);
            this.panelMenu.Controls.Add(this.btnTables);
            this.panelMenu.Controls.Add(this.btnProducts);
            this.panelMenu.Name = "panelMenu";
            // 
            // btnReport
            // 
            this.btnReport.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.Image = global::SIV.Properties.Resources.icons_relatorio;
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnCashFlow
            // 
            this.btnCashFlow.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCashFlow, "btnCashFlow");
            this.btnCashFlow.Image = global::SIV.Properties.Resources.icons_caixa;
            this.btnCashFlow.Name = "btnCashFlow";
            this.btnCashFlow.UseVisualStyleBackColor = true;
            this.btnCashFlow.Click += new System.EventHandler(this.btnCashFlow_Click);
            // 
            // btnTables
            // 
            this.btnTables.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTables, "btnTables");
            this.btnTables.Image = global::SIV.Properties.Resources.icons_mesa;
            this.btnTables.Name = "btnTables";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnProducts, "btnProducts");
            this.btnProducts.Image = global::SIV.Properties.Resources.icons_produto;
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // panelBar
            // 
            resources.ApplyResources(this.panelBar, "panelBar");
            this.panelBar.BackColor = System.Drawing.Color.LightCyan;
            this.panelBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBar.Controls.Add(this.labelTitle);
            this.panelBar.Controls.Add(this.panelLogo);
            this.panelBar.Name = "panelBar";
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.LightCyan;
            this.panelLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogo.Controls.Add(this.labelSIV);
            this.panelLogo.Controls.Add(this.logotipo);
            resources.ApplyResources(this.panelLogo, "panelLogo");
            this.panelLogo.Name = "panelLogo";
            // 
            // labelSIV
            // 
            resources.ApplyResources(this.labelSIV, "labelSIV");
            this.labelSIV.Name = "labelSIV";
            // 
            // logotipo
            // 
            this.logotipo.Image = global::SIV.Properties.Resources.logotipo;
            resources.ApplyResources(this.logotipo, "logotipo");
            this.logotipo.Name = "logotipo";
            this.logotipo.TabStop = false;
            // 
            // displayPanel
            // 
            resources.ApplyResources(this.displayPanel, "displayPanel");
            this.displayPanel.BackColor = System.Drawing.Color.Transparent;
            this.displayPanel.Name = "displayPanel";
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.MenuMain);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.panelMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logotipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel displayPanel;

        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Label labelSIV;

        private System.Windows.Forms.PictureBox logotipo;

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnCashFlow;
        private System.Windows.Forms.Button btnReport;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Panel panelLogo;

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuRegistration;
        private System.Windows.Forms.ToolStripMenuItem MenuRegistrationUser;
        private System.Windows.Forms.ToolStripMenuItem MenuRegistrationEmployee;
        private System.Windows.Forms.ToolStripMenuItem MenuRegistrationClient;
        private System.Windows.Forms.ToolStripMenuItem MenuRegistrationSupplier;
        private System.Windows.Forms.ToolStripMenuItem MenuRegistrationJob;
        private System.Windows.Forms.ToolStripMenuItem MenuProducts;
        private System.Windows.Forms.ToolStripMenuItem MenuProductsProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuProductsStock;
        private System.Windows.Forms.ToolStripMenuItem MenuMovements;
        private System.Windows.Forms.ToolStripMenuItem MenuMovementsCashFlow;
        private System.Windows.Forms.ToolStripMenuItem MenuMovementsSales;
        private System.Windows.Forms.ToolStripMenuItem MenuMovementsExpenses;
        private System.Windows.Forms.ToolStripMenuItem MenuReport;
        private System.Windows.Forms.ToolStripMenuItem MenuReportProducts;
        private System.Windows.Forms.ToolStripMenuItem MenuReportSales;
        private System.Windows.Forms.ToolStripMenuItem MenuReportInputOutput;
        private System.Windows.Forms.ToolStripMenuItem MenuReportExpenses;
        private System.Windows.Forms.ToolStripMenuItem Exiting;

        #endregion
    }
}