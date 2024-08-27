using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using SIV.Helpers;
using SIV.Repositories; // Adicione a referência ao repositório de mesas

namespace SIV.Views.Tables.Sales;

public partial class FrmSales : Form
{
    private const double BrightnessFactor = 0.5; // Fator de brilho para a cor de destaque
    
    public FrmSales()
    {
        InitializeComponent();
    }
    
    private void FrmSales_Load(object sender, EventArgs e)
    {
        ApplyingTheme();
    }
    
    private void btnSale_Click(object sender, EventArgs e)
    {
        RequestTableIdAndShowSalesForm();
    }
    
    private void timer_Tick(object sender, EventArgs e)
    {
        UpdateStatusBar();
    }
    
    private void RequestTableIdAndShowSalesForm()
    {
        var input = Interaction.InputBox("Digite o número da mesa para abrir:", "Abrir Mesa", "1");

        if (int.TryParse(input, out var tableId))
        {
            var table = TableRepository.LoadTable(tableId); // Carrega a mesa do repositório

            MessageBox.Show(@$"A mesa {tableId} está {table.State}.");

            if (table.State == "Fechada")
            {
                MessageBox.Show(@"A mesa está fechada. Por favor, abra a mesa antes de realizar vendas.");
                return;
            }

            OpenFrmTableSales(tableId);
        }
        else
        {
            MessageBox.Show(@"ID da mesa inválido. Por favor, tente novamente.");
        }
    }

    private void OpenFrmTableSales(int tableId)
    {
        var frmTableSales = new FrmTableSales(tableId);
        
        panelDisplayForm.Controls.Clear();
        OpenDisplayForm(frmTableSales, btnSale);
    }
    
    
    
    private void OpenDisplayForm(Form dashboard, object senderButton)
    {
        /*if (!_loggedInUser.HasPermission("ManageCadastres"))
        {
            MessageHelper.ShowValidationMessage("Usuário não tem permissão para acessar!");
            return;
        }*/
        
        ActivateButton(senderButton);
        
        dashboard.TopLevel = false;
        dashboard.FormBorderStyle = FormBorderStyle.None;
        dashboard.Dock = DockStyle.Fill;
        
        panelDisplayForm.Controls.Add(dashboard);
        panelDisplayForm.Tag = dashboard;
        
        dashboard.BringToFront();
        dashboard.Show();
    }
    
    private void ActivateButton(object senderButton)
    {
        var color = ColorThemes.PrimaryColor;
        ResetButtons(color);
        var currentButton = (Guna2Button)senderButton;
        
        currentButton.FillColor = color;
        currentButton.ForeColor = Color.Black;
        currentButton.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
        
        panelStatusv.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
    }
    
    private void ResetButtons(Color color)
    { 
        foreach (Control control in panelStatusv.Controls)
        {
            if (control is not Guna2Button button) continue;
            
            button.FillColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
            button.ForeColor = Color.Black;
            button.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular);
        }
    }
    
    private void ApplyingTheme()
    {
        var fillColor = ColorThemes.ChangeBrightness(ColorThemes.PrimaryColor, 0.5);
        
        panelStatusv.BackColor = fillColor;
        ApplyThemeToControl(btnLogoff, fillColor);
        ApplyThemeToControl(btnSale, fillColor);
        ApplyThemeToControl(btnItemTransfer, fillColor);
        ApplyThemeToControl(btnTableTransfer, fillColor);
        ApplyThemeToControl(btnItemRelease, fillColor);
        ApplyThemeToControl(btnConf, fillColor);
    }
    
    private static void ApplyThemeToControl(Control control, Color fillColor)
    {
        if (control is Guna2Button button)
        {
            button.FillColor = fillColor;
        }
    }
    
    private void UpdateStatusBar()
    {
        labelTimeStatusBar.Text = DateTime.Now.ToString("HH:mm:ss");
        labelDateStatusBar.Text = DateTime.Today.ToString("dd/MMMM/yyyy");
    }
}