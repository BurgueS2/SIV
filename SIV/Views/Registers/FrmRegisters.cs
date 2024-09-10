using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;
using SIV.Views.Clients;
using SIV.Views.Employees;
using SIV.Views.Jobs;
using SIV.Views.Payments;
using SIV.Views.Products;
using SIV.Views.Users;

namespace SIV.Views.Registers;

public partial class FrmRegisters : Form
{
    private const double BrightnessFactor = 0.5;
    //private readonly User _loggedInUser;
    
    public FrmRegisters(/*User loggedInUser*/)
    {
        InitializeComponent();
        //_loggedInUser = loggedInUser;
    }
    
    private void FrmRegisters_Load(object sender, EventArgs e)
    {
        ApplyingTheme();
        LoadClientes();
        LoadEmployees();
        LoadProducts();
    }
    
    private void btnEmployee_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmEmployees(), sender);
    }
    
    private void btnUser_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmUsers(), sender);
    }
    
    private void btnClient_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmClients(), sender);
    }

    private void btnJob_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmJobs(), sender);
    }
    
    private void btnProduct_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmProducts(), sender);
    }

    private void btnSupplier_Click(object sender, EventArgs e)
    {
        // Not implemented
    }

    private void btnAddress_Click(object sender, EventArgs e)
    {
        // Not implemented
    }

    private void btnPayment_Click(object sender, EventArgs e)
    {
        OpenDisplayForm(new FrmPayments(), sender);
    }
    
    private void txtSearchClient_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            SearchClient();
        }
    }
    
    private void txtSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            SearchProduct();
        }
    }
    
    private void txtSearchEmployee_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            SearchEmployee();
        }
    }
    
    private void OpenDisplayForm(Form dashboard, object senderButton)
    {
        /*if (!_loggedInUser.HasPermission("ManageCadastres"))
        {
            MessageHelper.ShowValidationMessage("Usuário não tem permissão para acessar o cadastro de Employees!");
            return;
        }*/
        
        ActivateButton(senderButton);
        dashboard.TopLevel = false;
        dashboard.FormBorderStyle = FormBorderStyle.None;
        dashboard.Dock = DockStyle.Fill;
        tableLayoutPanel.Visible = false;
        displayPanel.Controls.Add(dashboard);
        displayPanel.Tag = dashboard;
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
        
        panelMenuRegister.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
    }
    
    private void ResetButtons(Color color)
    { 
        foreach (Control control in panelMenuRegister.Controls)
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
        
        panelMenuRegister.BackColor = fillColor;
        ApplyThemeToControl(btnEmployee, fillColor);
        ApplyThemeToControl(btnUser, fillColor);
        ApplyThemeToControl(btnClient, fillColor);
        ApplyThemeToControl(btnJob, fillColor);
        ApplyThemeToControl(btnProduct, fillColor);
        ApplyThemeToControl(btnSupplier, fillColor);
        ApplyThemeToControl(btnAddress, fillColor);
        ApplyThemeToControl(btnPayment, fillColor);
    }
    
    private static void ApplyThemeToControl(Control control, Color fillColor)
    {
        if (control is Guna2Button button)
        {
            button.FillColor = fillColor;
        }
    }

    private void LoadClientes()
    {
        try
        {
            gridDataClient.DataSource = ClientRepository.GetAllClients();
            ShowOnlyNameColumn(gridDataClient);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os clientes");
        }
    }

    private void LoadEmployees()
    {
        try
        {
            gridDataEmployee.DataSource = EmployeeRepository.GetAllEmployees();
            ShowOnlySpecificColumns(gridDataEmployee, new[] { 1, 4 });
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os funcionários");
        }
    }

    private void LoadProducts()
    {
        try
        {
            gridDataProduct.DataSource = ProductRepository.GetAllProducts();
            ShowOnlySpecificColumns(gridDataProduct, new[] { 2, 5 });
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os produtos");
        }
    }

    private void LoadSuppliers()
    {
        try
        {
            //gridDataSupplier.DataSource = SupplierRepository.GetAllSuppliers();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os fornecedores");
        }
    }

    private void SearchClient()
    {
        try
        {
            gridDataClient.DataSource = ClientRepository.SearchByName(txtSearchClient.Text);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "pesquisar os clientes");
        }
    }

    private void SearchProduct()
    {
        try
        {
            gridDataProduct.DataSource = ProductRepository.SearchProductsByName(txtSearchProduct.Text);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "pesquisar os produtos");
        }
    }

    private void SearchEmployee()
    {
        try
        {
            gridDataEmployee.DataSource = EmployeeRepository.SearchByName(txtSearchEmployee.Text);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "pesquisar os funcionários");
        }
    }

    private static void ShowOnlyNameColumn(DataGridView grid)
    {
        foreach (DataGridViewColumn column in grid.Columns)
        {
            column.Visible = false;
        }

        grid.Columns[1].Visible = true;
    }

    private static void ShowOnlySpecificColumns(DataGridView grid, int[] columnIndexes)
    {
        foreach (DataGridViewColumn column in grid.Columns)
        {
            column.Visible = false;
        }

        foreach (var index in columnIndexes)
        {
            grid.Columns[index].Visible = true;
        }
    }
}