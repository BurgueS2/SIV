using System.ComponentModel;

namespace SIV.Views.Sales.Tables;

partial class FrmTables
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
        this.flowLayoutPanelTables = new System.Windows.Forms.FlowLayoutPanel();
        this.SuspendLayout();
        // 
        // flowLayoutPanelTables
        // 
        this.flowLayoutPanelTables.AutoScroll = true;
        this.flowLayoutPanelTables.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flowLayoutPanelTables.Location = new System.Drawing.Point(0, 0);
        this.flowLayoutPanelTables.Margin = new System.Windows.Forms.Padding(5);
        this.flowLayoutPanelTables.Name = "flowLayoutPanelTables";
        this.flowLayoutPanelTables.Size = new System.Drawing.Size(1080, 720);
        this.flowLayoutPanelTables.TabIndex = 0;
        // 
        // FrmTables
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1080, 720);
        this.Controls.Add(this.flowLayoutPanelTables);
        this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(8);
        this.Name = "FrmTables";
        this.Text = "Mesa";
        this.ResumeLayout(false);
        
        
        
        
        
        
        
        
        
        
        
        
    }

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTables;

    #endregion
}