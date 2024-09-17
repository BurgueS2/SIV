using System;
using System.Drawing;
using System.Threading.Tasks;
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

    public FrmRegisters()
    {
        InitializeComponent();
    }
    
    private async void FrmRegisters_Load(object sender, EventArgs e)
    {
        ApplyingTheme();
        await LoadDataAsync();
    }
    
    private void btnEmployee_Click(object sender, EventArgs e) => OpenDisplayForm(new FrmEmployees(), sender);
    
    private void btnUser_Click(object sender, EventArgs e) => OpenDisplayForm(new FrmUsers(), sender);

    private void btnClient_Click(object sender, EventArgs e) => OpenDisplayForm(new FrmClients(), sender);
    
    private void btnJob_Click(object sender, EventArgs e) => OpenDisplayForm(new FrmJobs(), sender);
    
    private void btnProduct_Click(object sender, EventArgs e) => OpenDisplayForm(new FrmProducts(), sender);
    
    private void btnSupplier_Click(object sender, EventArgs e) { /* Not implemented */ }
    
    private void btnAddress_Click(object sender, EventArgs e) { /* Not implemented */ }
    
    private void btnPayment_Click(object sender, EventArgs e) => OpenDisplayForm(new FrmPayments(), sender);
    
    private void txtSearchClient_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) SearchClient();
    }
    
    private void txtSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) SearchProduct();
    }
    
    private void txtSearchEmployee_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) SearchEmployee();
    }
    
    private void OpenDisplayForm(Form dashboard, object senderButton)
    {
        if (SessionManager.CurrentUser.HasPermission("ManageCadastres") == false)
        {
            MessageHelper.NoPermissionMessage();
            return;
        }
        
        ActivateButton(senderButton);
        DisplayForm(dashboard);
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
    
    private async Task LoadDataAsync()
    {
        await LoadClientesAsync();
        await LoadEmployeesAsync();
        await LoadProductsAsync();
        await LoadSuppliersAsync();
    }

    private async Task LoadClientesAsync()
    {
        try
        {
            gridDataClient.DataSource = await Task.Run(ClientRepository.GetAllClients);
            ShowOnlyNameColumn(gridDataClient);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os clientes");
        }
    }

    private async Task LoadEmployeesAsync()
    {
        try
        {
            gridDataEmployee.DataSource = await Task.Run(EmployeeRepository.GetAllEmployees);
            ShowOnlySpecificColumns(gridDataEmployee, [1, 4]);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os funcionários");
        }
    }

    private async Task LoadProductsAsync()
    {
        try
        {
            gridDataProduct.DataSource = await Task.Run(ProductRepository.GetAllProducts);
            ShowOnlySpecificColumns(gridDataProduct, [2, 5]);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os produtos");
        }
    }

    private async Task LoadSuppliersAsync()
    {
        try
        {
            //gridDataSupplier.DataSource = await Task.Run(SupplierRepository.GetAllSuppliers);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os fornecedores");
        }
    }

    private void SearchClient()
    {
        SearchData(ClientRepository.SearchByName, txtSearchClient.Text, gridDataClient, "pesquisar os clientes");
    }

    private void SearchProduct()
    {
        SearchData(EmployeeRepository.SearchByName, txtSearchProduct.Text, gridDataProduct, "pesquisar os produtos");
    }

    private void SearchEmployee()
    {
        SearchData(EmployeeRepository.SearchByName, txtSearchEmployee.Text, gridDataEmployee, "pesquisar os funcionários");
    }
    
    private static void SearchData(Func<string, object> searchFunc, string searchText, DataGridView grid, string action)
    {
        try
        {
            grid.DataSource = searchFunc(searchText);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, action);
        }
    }
    
    private static void ShowOnlyNameColumn(DataGridView grid)
    {
        ShowOnlySpecificColumns(grid, [1]);
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
    
    private void DisplayForm(Form dashboard)
    {
        dashboard.TopLevel = false;
        dashboard.FormBorderStyle = FormBorderStyle.None;
        dashboard.Dock = DockStyle.Fill;
        
        tableLayoutPanel.Visible = false;
        
        displayPanel.Controls.Add(dashboard);
        displayPanel.Tag = dashboard;
        
        dashboard.BringToFront();
        dashboard.Show();
    }
}