using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Views.Login;
using SIV.Views.Registers;
using SIV.Views.Sales;
using SIV.Views.Sales.Tables;

namespace SIV.Views;

public partial class FrmMain : Form
{
    private const double BrightnessFactor = 0.5;
    private Guna2Button _currentButton;
    private readonly Random _random = new();
    private int _tempIndex; // Armazena o índice da cor temporária
    private Form _enableFormDisplay; // Armazena o formulário que está sendo exibido
    private readonly User _loggedInUser;
    
    public FrmMain(/*User loggedInUser*/)
    {
        InitializeComponent();
        //_loggedInUser = loggedInUser;\
    }
    
    private void btnExitDisplay_Click(object sender, EventArgs e)
    {
        CloseDisplayForm();
    }
    
    private void btnTables_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmTables(), sender);
    }

    private void btnCashFlow_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmSalas(), sender);
    }

    private void btnRegisters_Click(object sender, EventArgs e)
    {
        try
        {
            OpenDisplayForm(new FrmRegisters(/*_loggedInUser*/), sender);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show($@"Ocorreu um erro: {ex.Message}");
        }
    }

    private void btnReport_Click(object sender, EventArgs e)
    {
        HandleButtonClick(sender);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        if (!MessageHelper.ConfirmExit()) return;
        Application.Exit();
    }
    
    private void btnLogoff_Click(object sender, EventArgs e)
    {
        OpenLogin();
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
            MessageBox.Show(@$"Ocorreu um erro em RandomColor: {ex.Message}");
            return Color.Black; // Retorna uma cor padrão em caso de erro
        }
    }
    
    private void ActivateButton(object senderButton)
    {
        btnExitDisplay.Visible = true; // Exibe o botão de sair do formulário
        
        var color = RandomColor();
        ResetButtons(color);
        
        _currentButton = (Guna2Button)senderButton;
        _currentButton.FillColor = color;
        _currentButton.ForeColor = Color.Black;
        _currentButton.Font = new Font("Century Gothic", 15F, FontStyle.Bold);
        ColorThemes.PrimaryColor = color;
        
        UpdatePanelColors(color);
    }
    
    private void ResetButtons(Color color)
    {
        foreach (Control control in panelMenu.Controls)
        {
            if (control is not Guna2Button button) continue;
            
            button.FillColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
            button.ForeColor = Color.Black;
            button.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular);
        }
    }
    
    private void UpdatePanelColors(Color color)
    {
        panelBar.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
        panelStatus.FillColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
        panelMenu.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
        btnConf.FillColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
        btnLogoff.FillColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
    }
    
    private void OpenDisplayForm(Form dashboard, object senderButton)
    {
        _enableFormDisplay?.Close();

        ActivateButton(senderButton);
        _enableFormDisplay = dashboard;
        
        dashboard.TopLevel = false;
        dashboard.FormBorderStyle = FormBorderStyle.None;
        dashboard.Dock = DockStyle.Fill;
        
        displayPanel.Controls.Add(dashboard);
        displayPanel.Tag = dashboard;
        
        dashboard.BringToFront();
        dashboard.Show();
        labelTitle.Text = dashboard.Text;
    }
    
    public void OpenFormInDisplayPanel(Form form)
    {
        _enableFormDisplay?.Close();
        _enableFormDisplay = form;
        
        form.TopLevel = false;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;
        
        displayPanel.Controls.Add(form);
        displayPanel.Tag = form;
        
        form.BringToFront();
        form.Show();
        labelTitle.Text = form.Text;
    }
    
    /// <summary>
    /// Manipula o clique do botão. Método genérico para todos os botões.
    /// </summary>
    private void HandleButtonClick(object sender)
    {
        try
        {
            ActivateButton(sender);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show($@"Ocorreu um erro: {ex.Message}");
        }
    }
    
    private void CloseDisplayForm()
    {
        _enableFormDisplay?.Close();

        labelTitle.Text = @"HOME";
        btnExitDisplay.Visible = false;
        
        ResetButtons(ColorThemes.PrimaryColor);
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        DateStatusBar.Text = DateTime.Today.ToString("dd/MMMM/yyyy");
        TimeStatusBar.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    private void OpenLogin()
    {
        try
        {
            var controller = new UserController();
            UserController.Logoff();

            var loginForm = new FrmLogin();
            loginForm.ShowDialog();
            Close();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show(@$"Ocorreu um erro: {ex.Message}");
        }
    }
}