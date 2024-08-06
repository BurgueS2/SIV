using System;
using System.Drawing;
using System.Windows.Forms;
using SIV.Views.Clients;
using SIV.Views.Employees;
using SIV.Views.Jobs;

namespace SIV.Views.Registers;

public partial class FrmRegisters : Form
{
    private const double BrightnessFactor = 0.5;
    //private Button _currentButton;
    
    public FrmRegisters()
    {
        InitializeComponent();
    }

    private void FrmRegisters_Load(object sender, EventArgs e)
    {
        ApplyingTheme();
    }

    private void btnEmployee_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmEmployees(), sender);
    }

    private void btnClient_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmClients(), sender);
    }
    
    private void btnJob_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmJobs(), sender);
    }

    private void btnSupplier_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void btnProduct_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    private void OpenDisplayForm(Form dashboard, object senderButton)
    {
        //_enableFormDisplay = dashboard;
        ActivateButton(senderButton);
        dashboard.TopLevel = false;
        dashboard.FormBorderStyle = FormBorderStyle.None;
        dashboard.Dock = DockStyle.Fill;
        displayPanel.Controls.Add(dashboard);
        displayPanel.Tag = dashboard;
        dashboard.BringToFront();
        dashboard.Show();
        //labelTitle.Text = dashboard.Text;
    }
    
    private void ActivateButton(object senderButton)
    {
        var color = ColorThemes.PrimaryColor;
        ResetButtons(color);
        var currentButton = (Button)senderButton;
        
        currentButton.BackColor = color;
        currentButton.ForeColor = Color.Black;
        currentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        
        ColorThemes.PrimaryColor = color;
        panelMenuRegister.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
    }
    
    private void ResetButtons(Color color)
    {
        foreach (Control control in panelMenuRegister.Controls)
        {
            if (control.GetType() != typeof(Button)) continue; // Verifica se o controle é um botão
            
            control.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
            control.ForeColor = Color.Black;
            control.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
        }
    }
    
    private void ApplyingTheme()
    {
        ApplyThemeToControl(panelMenuRegister);
        ApplyThemeToControl(btnEmployee);
        ApplyThemeToControl(btnClient);
        ApplyThemeToControl(btnJob);
        ApplyThemeToControl(btnSupplier);
        ApplyThemeToControl(btnProduct);
    }
    
    private static void ApplyThemeToControl(Control control)
    {
        control.BackColor = ColorThemes.ChangeBrightness(ColorThemes.PrimaryColor, 0.5);
    }
}