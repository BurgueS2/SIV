using System;
using System.Drawing;
using System.Windows.Forms;
using SIV.Core;
using SIV.Views.Clients;
using SIV.Views.Employees;
using SIV.Views.Jobs;

namespace SIV.Views;

public partial class FrmMain : MetroFramework.Forms.MetroForm
{
    private Button _currentButton;
    private readonly Random _random = new();
    private int _tempIndex;
    private Form _enableFormDisplay;
    
    public FrmMain()
    {
        InitializeComponent();
    }
    
    private void Exiting_Click(object sender, EventArgs e)
    {
        if (MessageHelper.ConfirmExit())
        {
            Application.Exit();
        }
    }
    
    private void MenuRegistrationEmployee_Click(object sender, EventArgs e)
    {
        var frmEmployees = new FrmEmployees();
        frmEmployees.ShowDialog();
    }

    private void MenuRegistrationClient_Click(object sender, EventArgs e)
    {
        var frmClients = new FrmClients();
        frmClients.ShowDialog();
    }

    private void MenuRegistrationJob_Click(object sender, EventArgs e)
    {
        var frmJobs = new FrmJobs();
        frmJobs.ShowDialog();
    }
    
    private void btnProducts_Click(object sender, EventArgs e)
    {
        try
        {
            // ActivateButton(sender);
            OpenDisplayForm(new Views.Clients.FrmClients(), sender);
        }
        catch (Exception exception)
        {
            Logger.LogException(exception);
            MessageBox.Show(@"An error occurred: " + exception.Message);
        }
    }

    private void btnTables_Click(object sender, EventArgs e)
    {
        try
        {
            ActivateButton(sender);
        }
        catch (Exception exception)
        {
            Logger.LogException(exception);
            MessageBox.Show(@"An error occurred: " + exception.Message);
        }
    }

    private void btnCashFlow_Click(object sender, EventArgs e)
    {
        try
        {
            ActivateButton(sender);
        }
        catch (Exception exception)
        {
            Logger.LogException(exception);
            MessageBox.Show(@"An error occurred: " + exception.Message);
        }
    }

    private void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            ActivateButton(sender);
        }
        catch (Exception exception)
        {
            Logger.LogException(exception);
            MessageBox.Show(@"An error occurred: " + exception.Message);
        }
    }
    
    private void ActivateButton(object senderButton)
    {
        try
        {
            var color = RandomColor();
            Reset(color);
            _currentButton = (Button)senderButton;
            _currentButton.BackColor = color;
            _currentButton.ForeColor = Color.Black;
            _currentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            
            panelBar.BackColor = ColorThemes.ChangeBrightness(color, 0.5);
            panelLogo.BackColor = ColorThemes.ChangeBrightness(color, 0.5);
            panelMenu.BackColor = ColorThemes.ChangeBrightness(color, 0.5);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show(@"An error occurred in ActivateButton: " + ex.Message);
        }
    }
    
    private void Reset(Color color)
    {
        try
        {
            foreach (Control control in panelMenu.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.BackColor = ColorThemes.ChangeBrightness(color, 0.5);
                    control.ForeColor = Color.Black;
                    control.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show(@"An error occurred in Reset: " + ex.Message);
        }
    }
    
    private Color RandomColor()
    {
        try
        {
            var index = _random.Next(ColorThemes.ColorList.Count);

            while (_tempIndex == index)
            {
                index = _random.Next(ColorThemes.ColorList.Count);
            }

            _tempIndex = index;
            var color = ColorThemes.ColorList[index];

            return ColorTranslator.FromHtml(color);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show(@"An error occurred in RandomColor: " + ex.Message);
            return Color.Black; // Retorna uma cor padrão em caso de erro
        }
    }

    private void OpenDisplayForm(Form Dashboard, object senderButton)
    {
        if (_enableFormDisplay != null)
        {
            _enableFormDisplay.Close();
        }
        
        ActivateButton(senderButton);
        _enableFormDisplay = Dashboard;
        Dashboard.TopLevel = false;
        Dashboard.FormBorderStyle = FormBorderStyle.None;
        Dashboard.Dock = DockStyle.Fill;
        displayPanel.Controls.Add(Dashboard);
        displayPanel.Tag = Dashboard;
        Dashboard.BringToFront();
        Dashboard.Show();
        labelTitle.Text = Dashboard.Text;
    }
}