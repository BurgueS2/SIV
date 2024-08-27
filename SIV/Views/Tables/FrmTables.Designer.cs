using System.ComponentModel;
using System.Windows.Forms;

namespace SIV.Views.Tables;

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
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
        this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
        this.flowLayoutPanelTables = new System.Windows.Forms.FlowLayoutPanel();
        this.panelMain.SuspendLayout();
        this.SuspendLayout();
        // 
        // panelMain
        // 
        this.panelMain.AutoScroll = true;
        this.panelMain.Controls.Add(this.guna2VScrollBar1);
        this.panelMain.Controls.Add(this.flowLayoutPanelTables);
        this.panelMain.CustomizableEdges = customizableEdges1;
        this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelMain.Location = new System.Drawing.Point(0, 0);
        this.panelMain.Name = "panelMain";
        this.panelMain.ShadowDecoration.CustomizableEdges = customizableEdges2;
        this.panelMain.Size = new System.Drawing.Size(1080, 720);
        this.panelMain.TabIndex = 0;
        // 
        // guna2VScrollBar1
        // 
        this.guna2VScrollBar1.AutoRoundedCorners = true;
        this.guna2VScrollBar1.BindingContainer = this.flowLayoutPanelTables;
        this.guna2VScrollBar1.BorderRadius = 8;
        this.guna2VScrollBar1.FillColor = System.Drawing.Color.White;
        this.guna2VScrollBar1.InUpdate = false;
        this.guna2VScrollBar1.LargeChange = 80;
        this.guna2VScrollBar1.Location = new System.Drawing.Point(1062, 0);
        this.guna2VScrollBar1.Name = "guna2VScrollBar1";
        this.guna2VScrollBar1.ScrollbarSize = 18;
        this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 720);
        this.guna2VScrollBar1.TabIndex = 0;
        this.guna2VScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
        // 
        // flowLayoutPanelTables
        // 
        this.flowLayoutPanelTables.AutoScroll = true;
        this.flowLayoutPanelTables.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flowLayoutPanelTables.Location = new System.Drawing.Point(0, 0);
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
        this.Controls.Add(this.panelMain);
        this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(13);
        this.Name = "FrmTables";
        this.Text = "MESA";
        this.panelMain.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTables;

    private Guna.UI2.WinForms.Guna2Panel panelMain;

    #endregion
}