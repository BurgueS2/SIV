namespace SIV.Views
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
            this.logotipo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logotipo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            resources.ApplyResources(this.MenuMain, "MenuMain");
            this.MenuMain.BackColor = System.Drawing.Color.Transparent;
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuRegistration, this.MenuProducts, this.MenuMovements, this.MenuReport, this.Exiting });
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Stretch = false;
            // 
            // MenuRegistration
            // 
            resources.ApplyResources(this.MenuRegistration, "MenuRegistration");
            this.MenuRegistration.BackColor = System.Drawing.Color.White;
            this.MenuRegistration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuRegistrationUser, this.MenuRegistrationSupplier, this.MenuRegistrationJob });
            this.MenuRegistration.Name = "MenuRegistration";
            // 
            // MenuRegistrationUser
            // 
            resources.ApplyResources(this.MenuRegistrationUser, "MenuRegistrationUser");
            this.MenuRegistrationUser.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuRegistrationEmployee, this.MenuRegistrationClient });
            this.MenuRegistrationUser.Name = "MenuRegistrationUser";
            // 
            // MenuRegistrationEmployee
            // 
            resources.ApplyResources(this.MenuRegistrationEmployee, "MenuRegistrationEmployee");
            this.MenuRegistrationEmployee.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationEmployee.Name = "MenuRegistrationEmployee";
            this.MenuRegistrationEmployee.Click += new System.EventHandler(this.MenuRegistrationEmployee_Click);
            // 
            // MenuRegistrationClient
            // 
            resources.ApplyResources(this.MenuRegistrationClient, "MenuRegistrationClient");
            this.MenuRegistrationClient.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationClient.Name = "MenuRegistrationClient";
            this.MenuRegistrationClient.Click += new System.EventHandler(this.MenuRegistrationClient_Click);
            // 
            // MenuRegistrationSupplier
            // 
            resources.ApplyResources(this.MenuRegistrationSupplier, "MenuRegistrationSupplier");
            this.MenuRegistrationSupplier.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationSupplier.Name = "MenuRegistrationSupplier";
            // 
            // MenuRegistrationJob
            // 
            resources.ApplyResources(this.MenuRegistrationJob, "MenuRegistrationJob");
            this.MenuRegistrationJob.BackColor = System.Drawing.Color.White;
            this.MenuRegistrationJob.Name = "MenuRegistrationJob";
            this.MenuRegistrationJob.Click += new System.EventHandler(this.MenuRegistrationJob_Click);
            // 
            // MenuProducts
            // 
            resources.ApplyResources(this.MenuProducts, "MenuProducts");
            this.MenuProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuProductsProduct, this.MenuProductsStock });
            this.MenuProducts.Name = "MenuProducts";
            // 
            // MenuProductsProduct
            // 
            resources.ApplyResources(this.MenuProductsProduct, "MenuProductsProduct");
            this.MenuProductsProduct.Name = "MenuProductsProduct";
            // 
            // MenuProductsStock
            // 
            resources.ApplyResources(this.MenuProductsStock, "MenuProductsStock");
            this.MenuProductsStock.Name = "MenuProductsStock";
            // 
            // MenuMovements
            // 
            resources.ApplyResources(this.MenuMovements, "MenuMovements");
            this.MenuMovements.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuMovementsCashFlow });
            this.MenuMovements.Name = "MenuMovements";
            // 
            // MenuMovementsCashFlow
            // 
            resources.ApplyResources(this.MenuMovementsCashFlow, "MenuMovementsCashFlow");
            this.MenuMovementsCashFlow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuMovementsSales, this.MenuMovementsExpenses });
            this.MenuMovementsCashFlow.Name = "MenuMovementsCashFlow";
            // 
            // MenuMovementsSales
            // 
            resources.ApplyResources(this.MenuMovementsSales, "MenuMovementsSales");
            this.MenuMovementsSales.Name = "MenuMovementsSales";
            // 
            // MenuMovementsExpenses
            // 
            resources.ApplyResources(this.MenuMovementsExpenses, "MenuMovementsExpenses");
            this.MenuMovementsExpenses.Name = "MenuMovementsExpenses";
            // 
            // MenuReport
            // 
            resources.ApplyResources(this.MenuReport, "MenuReport");
            this.MenuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuReportProducts, this.MenuReportSales, this.MenuReportInputOutput, this.MenuReportExpenses });
            this.MenuReport.Name = "MenuReport";
            // 
            // MenuReportProducts
            // 
            resources.ApplyResources(this.MenuReportProducts, "MenuReportProducts");
            this.MenuReportProducts.Name = "MenuReportProducts";
            // 
            // MenuReportSales
            // 
            resources.ApplyResources(this.MenuReportSales, "MenuReportSales");
            this.MenuReportSales.Name = "MenuReportSales";
            // 
            // MenuReportInputOutput
            // 
            resources.ApplyResources(this.MenuReportInputOutput, "MenuReportInputOutput");
            this.MenuReportInputOutput.Name = "MenuReportInputOutput";
            // 
            // MenuReportExpenses
            // 
            resources.ApplyResources(this.MenuReportExpenses, "MenuReportExpenses");
            this.MenuReportExpenses.Name = "MenuReportExpenses";
            // 
            // Exiting
            // 
            resources.ApplyResources(this.Exiting, "Exiting");
            this.Exiting.Name = "Exiting";
            this.Exiting.Click += new System.EventHandler(this.Exiting_Click);
            // 
            // logotipo
            // 
            resources.ApplyResources(this.logotipo, "logotipo");
            this.logotipo.Image = global::SIV.Properties.Resources.logotipo;
            this.logotipo.Name = "logotipo";
            this.logotipo.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.logotipo);
            this.panel1.Name = "panel1";
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MenuMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logotipo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.PictureBox logotipo;

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