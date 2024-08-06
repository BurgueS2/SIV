using System;
using System.Drawing;
using System.Windows.Forms;
using Org.BouncyCastle.Pqc.Crypto.Frodo;
using SIV.Core;
using SIV.Views.Registers;

namespace SIV.Views;

public partial class FrmMain : MetroFramework.Forms.MetroForm
{
    private const double BrightnessFactor = 0.5;
    private Button _currentButton;
    private readonly Random _random = new();
    private int _tempIndex; // Armazena o índice da cor temporária
    private Form _enableFormDisplay; // Armazena o formulário que está sendo exibido
    
    public FrmMain()
    {
        InitializeComponent();
    }
    
    private void btnTables_Click(object sender, EventArgs e)
    {
        HandleButtonClick(sender);
    }

    private void btnCashFlow_Click(object sender, EventArgs e)
    {
        HandleButtonClick(sender);
    }

    private void btnReport_Click(object sender, EventArgs e)
    {
        HandleButtonClick(sender);
    }
    
    private void btnRegisters_Click(object sender, EventArgs e)
    {
        try
        {
            OpenDisplayForm(new FrmRegisters(), sender);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show($@"Ocorreu um erro: {ex.Message}");
        }
    }
    
    private void btnExit_Click(object sender, EventArgs e)
    {
        if (!MessageHelper.ConfirmExit()) return;
        Application.Exit();
    }
    
    private void btnExitDisplay_Click(object sender, EventArgs e)
    {
        CloseDisplayForm();
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
        
        _currentButton = (Button)senderButton;
        _currentButton.BackColor = color;
        _currentButton.ForeColor = Color.Black;
        _currentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        ColorThemes.PrimaryColor = color;
        
        UpdatePanelColors(color);
    }
    
    private void ResetButtons(Color color)
    {
        foreach (Control control in panelMenu.Controls)
        {
            if (control.GetType() != typeof(Button)) continue; // Verifica se o controle é um botão
            
            control.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
            control.ForeColor = Color.Black;
            control.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
        }
    }
    
    private void UpdatePanelColors(Color color)
    {
        panelBar.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
        //panelLogo.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
        panelMenu.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
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
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        DateStatusBar.Text = DateTime.Today.ToString("dd/MMMM/yyyy - dddd");
        TimeStatusBar.Text = DateTime.Now.ToString("HH:mm:ss");
    }
}