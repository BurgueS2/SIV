using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;
using SIV.Views.Login;
using SIV.Views.Registers;
using SIV.Views.Tables;
using SIV.Views.Tables.Sales;

namespace SIV.Views;

public partial class FrmMain : Form
{
    private const double BrightnessFactor = 0.5;
    private Guna2Button _currentButton;
    private readonly Random _random = new();
    private int _tempIndex; // Armazena o índice da cor temporária
    private Form _enableFormDisplay; // Armazena o formulário que está sendo exibido
    
    public FrmMain() => InitializeComponent();
    
    private void btnExitDisplay_Click(object sender, EventArgs e) => CloseDisplayForm();
    
    private void btnTables_Click(object sender, EventArgs e) => OpenForm(new FrmTables(), sender);
    
    private void btnCashFlow_Click(object sender, EventArgs e) => OpenForm(new FrmSales(), sender);
    
    private void btnRegisters_Click(object sender, EventArgs e) => OpenForm(new FrmRegisters(), sender);
    
    private void btnReport_Click(object sender, EventArgs e) => HandleButtonClick(sender);
    
    private void btnExit_Click(object sender, EventArgs e) => ExitTheApplication();
    
    private void btnLogoff_Click(object sender, EventArgs e) => OpenLogin();
    
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
            
            return ColorTranslator.FromHtml(ColorThemes.ColorList[index]);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "gerar uma cor aleatória");
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
        var brightColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
        panelBar.BackColor = brightColor;
        panelStatus.FillColor = brightColor;
        panelMenu.BackColor = brightColor;
        btnConf.FillColor = brightColor;
        btnLogoff.FillColor = brightColor;
    }
    
    private void OpenDisplayForm(Form dashboard, object senderButton)
    {
        _enableFormDisplay?.Close();
        
        ActivateButton(senderButton);
        _enableFormDisplay = dashboard;
        ConfigureForm(dashboard);
        
        displayPanel.Controls.Add(dashboard);
        displayPanel.Tag = dashboard;
        
        dashboard.BringToFront();
        dashboard.Show();
        labelTitle.Text = dashboard.Text;
    }
    
    private static void ConfigureForm(Form form)
    {
        form.TopLevel = false; // Define o formulário como não principal
        form.FormBorderStyle = FormBorderStyle.None; // Remove a borda do formulário
        form.Dock = DockStyle.Fill; // Preenche o formulário no painel
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
        timeStatusBar.Text = DateTime.Now.ToString("HH:mm:ss");
    }
    
    private void OpenLogin()
    {
        try
        {
            UserController.Logoff();
            
            var loginForm = new FrmLogin();
            loginForm.ShowDialog();
            Close();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "abrir ao fazer logoff");
        }
    }
    
    public void UpdateUserLabel(string userName)
    {
        labelUser.Text = @$"Usuário: {userName}";
    }
    
    private void OpenForm(Form form, object sender)
    {
        try
        {
            OpenDisplayForm(form, sender);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "abrir o formulário");
        }
    }
    
    private static void ExitTheApplication()
    {
        if (!MessageHelper.ConfirmExit()) return;
        Application.Exit();
    }
}