using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;
using SIV.Views.Tables.ProductData;
using SIV.Views.Tables.TableOrItemTransfer; // Adicione a referência ao repositório de mesas

namespace SIV.Views.Tables.Sales;

public partial class FrmSales : Form
{
    private const double BrightnessFactor = 0.5; // Fator de brilho para a cor de destaque
    private int _tableId; // ID da mesa
    
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
        txtSale.Enabled = true;
        txtSale.Focus();
        btnCancelProduct.Enabled = true;
        txtClient.Enabled = true;
        txtSearchUser.Enabled = true;
        btnSearchUser.Visible = true;
        numericAmount.Enabled = true;
        btnSearchProduct.Visible = true;
    }
    
    private void btnTableTransfer_Click(object sender, EventArgs e)
    {
        var frmTableTransfer = new FrmTableTransfer(0);
        
        panelDisplayForm.Controls.Clear();
        OpenDisplayForm(frmTableTransfer, btnTableTransfer);
    }
    
    private void btnCancelProduct_Click(object sender, EventArgs e)
    {
        if (!MessageHelper.ConfirmDeletion()) return;

        if (gridData.SelectedRows.Count > 0)
        {
            var selectedRow = gridData.SelectedRows[0];
            if (int.TryParse(selectedRow.Cells["EntryId"].Value.ToString(), out int productId))
            {
                TableRepository.RemoveProductFromTable(_tableId, productId);
                LoadTableProducts();
            }
            else
            {
                MessageBox.Show(@"Invalid product ID.");
            }
        }
        else
        {
            MessageHelper.ShowProductNotFound();
        }
    }
    
    private void txtSale_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        
        var input = txtSale.Text;

        if (int.TryParse(input, out var tableId))
        {
            var table = TableRepository.LoadTable(tableId); // Carrega a mesa do repositório

            MessageBox.Show(@$"A mesa {tableId} está {table.State}.");
                
            _tableId = tableId;
            LoadTableProducts();

            if (table.State == "Fechada")
            {
                MessageBox.Show(@"A mesa está fechada. Por favor, abra a mesa antes de realizar vendas.");
            }
        }
        else
        {
            MessageBox.Show(@"ID da mesa inválido. Por favor, tente novamente.");
        }
    }
    
    private void LoadTableProducts()
    {
        try
        {
            var products = TableRepository.GetTableProducts(_tableId);
            gridData.DataSource = products;
            UpdateTotalValueLabel();
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar produtos da mesa");
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns["EntryId"]!.Visible = false;
        gridData.Columns["ProductName"]!.HeaderText = @"Produto";
        gridData.Columns["ProductPrice"]!.Visible = false;
        gridData.Columns["Amount"]!.HeaderText = @"Quant.";

        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Cells["ProductName"].Value?.ToString()))
            {
                row.Visible = false;
            }
        }
    }
    
    private void UpdateTotalValueLabel()
    {
        decimal totalValue = 0;

        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (row.Cells["ProductPrice"].Value != null)
            {
                totalValue += Convert.ToDecimal(row.Cells["ProductPrice"]. Value) * Convert.ToDecimal(row.Cells["Amount"].Value);
            }
        }
        
        labelValue.Text = totalValue.ToString("C");
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
        currentButton.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
        
        panelStatusv.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
    }
    
    private void ResetButtons(Color color)
    { 
        foreach (Control control in panelStatusv.Controls)
        {
            if (control is not Guna2Button button) continue;
            
            button.FillColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
            button.ForeColor = Color.Black;
            button.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular);
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
        ApplyThemeToControl(btnCancelProduct, fillColor);
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
    
    private void timer_Tick(object sender, EventArgs e)
    {
        UpdateStatusBar();
    }

    private void txtProduct_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        
        HandleProductSearch();
        e.Handled = true;
        e.SuppressKeyPress = true;
    }

    private void numericAmount_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        
        SaveProductToTable();
        e.Handled = true;
        e.SuppressKeyPress = true;
    }
    
    private void HandleProductSearch()
    {
        var productName = txtProduct.Text;
        var product = ProductRepository.GetProductByName(productName);

        if (product != null)
        {
            UpdateProductNameLabel(productName);
            txtCost.Text = product.ResalePrice.ToString("C");
            numericAmount.Value = 1;
            numericAmount.Focus();
        }
        else
        {
            MessageHelper.ShowProductNotFound();
        }
    }
    
    private void SaveProductToTable()
    {
        var productName = txtProduct.Text;
        var amount = numericAmount.Value;

        if (IsValidProductInput(productName, amount))
        {
            try
            {
                var product = ProductRepository.GetProductByName(productName);
                if (product == null) return;

                //TableRepository.AddProductToTable(_tableId, product.Name, product.ResalePrice, amount);
                TableRepository.UpdateTableState(_tableId, "Ocupada", "Khaki");
                LoadTableProducts();
                ResetProductInputFields();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                MessageHelper.HandleException(ex, "adicionar produto");
            }
            finally
            {
                ConnectionManager.CloseConnection();
            }
        }
        else
        {
            MessageHelper.ShowInvalidProductOrQuantity();
        }
    }
    
    private static bool IsValidProductInput(string productName, decimal amount)
    {
        return !string.IsNullOrWhiteSpace(productName) && amount > 0; // Verifica se o nome do produto e a quantidade são válidos
    }
    
    private void UpdateProductNameLabel(string partialProductName)
    {
        try
        {
            var product = ProductRepository.GetProductByName(partialProductName);

            if (product != null)
            {
                labelNameProduct.Text = product.Name;
                labelNameProduct.Visible = true;
            }
            else
            {
                labelNameProduct.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "buscar produto");
            labelNameProduct.Text = @$"Não encontrado: {ex.Message}";
            labelNameProduct.Visible = true;
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void ResetProductInputFields()
    {
        txtProduct.Clear();
        txtCost.Clear();
        numericAmount.Value = 1;
        txtProduct.Focus();
    }
    
    private void SearchProduct()
    {
        var frmProductData = new FrmProductData();

        if (frmProductData.ShowDialog() != DialogResult.OK) return;

        txtProduct.Text = frmProductData.SelectedProduct; // Preenche o campo de texto com o nome do produto selecionado
        txtCost.Text = frmProductData.CostPrice; // Preenche o campo de texto com o preço do produto selecionado
        numericAmount.Value = 1;
    }

    private void txtProduct_TextChanged(object sender, EventArgs e)
    {
        UpdateProductNameLabel(txtProduct.Text);
    }

    private void btnSearchProduct_Click(object sender, EventArgs e)
    {
        SearchProduct();
    }
}