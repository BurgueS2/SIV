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
            this.panelBar = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.logoTipo = new System.Windows.Forms.PictureBox();
            this.labelLogo = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnRegisters = new System.Windows.Forms.Button();
            this.btnCashFlow = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnExitDisplay = new System.Windows.Forms.Button();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.panelBar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTipo)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBar
            // 
            resources.ApplyResources(this.panelBar, "panelBar");
            this.panelBar.BackColor = System.Drawing.Color.LightCyan;
            this.panelBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBar.Controls.Add(this.panelLogo);
            this.panelBar.Controls.Add(this.labelTitle);
            this.panelBar.Name = "panelBar";
            // 
            // panelLogo
            // 
            resources.ApplyResources(this.panelLogo, "panelLogo");
            this.panelLogo.BackColor = System.Drawing.Color.LightCyan;
            this.panelLogo.Controls.Add(this.logoTipo);
            this.panelLogo.Controls.Add(this.labelLogo);
            this.panelLogo.Name = "panelLogo";
            // 
            // logoTipo
            // 
            this.logoTipo.Image = global::SIV.Properties.Resources.logotipo;
            resources.ApplyResources(this.logoTipo, "logoTipo");
            this.logoTipo.Name = "logoTipo";
            this.logoTipo.TabStop = false;
            // 
            // labelLogo
            // 
            resources.ApplyResources(this.labelLogo, "labelLogo");
            this.labelLogo.Name = "labelLogo";
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
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
            // btnRegisters
            // 
            this.btnRegisters.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnRegisters, "btnRegisters");
            this.btnRegisters.Image = global::SIV.Properties.Resources.icons8_cadastro_32;
            this.btnRegisters.Name = "btnRegisters";
            this.btnRegisters.UseVisualStyleBackColor = true;
            this.btnRegisters.Click += new System.EventHandler(this.btnRegisters_Click);
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
            // btnReport
            // 
            this.btnReport.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.Image = global::SIV.Properties.Resources.icons_relatorio;
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Image = global::SIV.Properties.Resources.icons_closed;
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMenu
            // 
            resources.ApplyResources(this.panelMenu, "panelMenu");
            this.panelMenu.BackColor = System.Drawing.Color.LightCyan;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.btnExitDisplay);
            this.panelMenu.Controls.Add(this.btnTables);
            this.panelMenu.Controls.Add(this.btnCashFlow);
            this.panelMenu.Controls.Add(this.btnRegisters);
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Name = "panelMenu";
            // 
            // btnExitDisplay
            // 
            resources.ApplyResources(this.btnExitDisplay, "btnExitDisplay");
            this.btnExitDisplay.FlatAppearance.BorderSize = 0;
            this.btnExitDisplay.Image = global::SIV.Properties.Resources.icons_close;
            this.btnExitDisplay.Name = "btnExitDisplay";
            this.btnExitDisplay.UseVisualStyleBackColor = true;
            this.btnExitDisplay.Click += new System.EventHandler(this.btnExitDisplay_Click);
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ControlBox = false;
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelBar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTipo)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.PictureBox logoTipo;

        private System.Windows.Forms.Button btnExitDisplay;
        private System.Windows.Forms.Button btnRegisters;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnCashFlow;
        private System.Windows.Forms.Button btnReport;

        #endregion
    }
}