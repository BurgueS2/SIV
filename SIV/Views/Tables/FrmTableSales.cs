using System;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;
using SIV.Views.Tables.ProductData;
using SIV.Views.Tables.TableOrItemTransfer;

namespace SIV.Views.Tables;

public partial class FrmTableSales : MetroFramework.Forms.MetroForm
{
    private readonly int _tableId;
    private readonly string _userName; // Adiciona a propriedade _UserName para armazenar o nome do usuário logado
    private Table _table; // Instância da mesa
    
    public FrmTableSales(int tableId)
    {
        InitializeComponent();
        _tableId = tableId;
        _userName = SessionManager.CurrentUser.Name;
        InitializeForm();
    }
    
    private void btnExit_Click(object sender, EventArgs e) => Close();
    
    private void btnCancelProduct_Click(object sender, EventArgs e) => HelperToCancel();
    
    private void btnSearchProduct_Click(object sender, EventArgs e) => SearchProduct();
    
    private void btnTransferProducts_Click(object sender, EventArgs e) => OpenForm();

    private void btnOk_Click(object sender, EventArgs e) { if (IsProductInputValid())  SaveProductToTable(); }

    private void txtProduct_TextChanged(object sender, EventArgs e) => UpdateProductNameLabel(txtProduct.Text);
    
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
    
    private void InitializeForm()
    {
        try
        {
            txtSale.Text = @$"{_tableId}";
            _table = TableRepository.LoadTable(_tableId);
            LoadTableProducts();
            txtSearchUser.Text = _userName; // Preenche o campo de texto com o nome do usuário logado
            txtClient.Text = @"Passante";
            labelDateStatus.Text = _table.SaveDate?.ToString("dd/MM/yyyy");
            labelTimeStatus.Text = _table.SaveTime.ToString();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "inicializar formulário");
        }
    }
    
    private void LoadTableProducts()
    {
        try
        {
            gridData.DataSource = TableRepository.GetTableProducts(_tableId);
            FormatGridData();
            UpdateTotalValueLabel();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar produtos da mesa");
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns[0].Visible = false;
        gridData.Columns[1].HeaderText = @"Produto";
        gridData.Columns[2].HeaderText = @"Preço";
        gridData.Columns[3].HeaderText = @"Qtd.";
        gridData.Columns[4].HeaderText = @"Garçom";

        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Cells["ProductName"].Value?.ToString()))
            {
                row.Visible = false;
            }
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

                TableRepository.AddProductToTable(_tableId, product.Name, product.ResalePrice, amount, _userName);
                TableRepository.UpdateTableState(_tableId, "Ocupada", "Khaki");
                LoadTableProducts();
                ResetProductInputFields();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                MessageHelper.HandleException(ex, "adicionar produto");
            }
        }
        else
        {
            MessageHelper.ShowInvalidProductOrQuantity();
        }
    }
    
    private void HelperToCancel()
    {
        if (!MessageHelper.ConfirmDeletion()) return;

        if (gridData.SelectedRows.Count > 0)
        {
            var selectedRow = gridData.SelectedRows[0];
            
            if (int.TryParse(selectedRow.Cells["EntryId"].Value.ToString(), out var productId))
            {
                TableRepository.RemoveProductFromTable(_tableId, productId);
                LoadTableProducts();
            }
            else
            {
                MessageBox.Show(@"Erro ao cancelar o produto.");
            }
        }
        else
        {
            MessageHelper.ShowProductNotFound();
        }
    }
    
    private void HandleProductSearch()
    {
        var product = ProductRepository.GetProductByName(txtProduct.Text);

        if (product != null)
        {
            UpdateProductNameLabel(txtProduct.Text);
            txtCost.Text = product.ResalePrice.ToString("C");
            numericAmount.Value = 1;
            numericAmount.Focus();
        }
        else
        {
            MessageHelper.ShowProductNotFound();
        }
    }
    
    private void UpdateProductNameLabel(string partialProductName)
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
    
    private void ResetProductInputFields()
    {
        txtProduct.Clear();
        txtCost.Text = @"0,00";
        numericAmount.Value = 1;
        txtProduct.Focus();
    }
    
    private static bool IsValidProductInput(string productName, decimal amount)
    {
        return !string.IsNullOrWhiteSpace(productName) && amount > 0; // Verifica se o nome do produto e a quantidade são válidos
    }
    
    private bool IsProductInputValid()
    {
        return !string.IsNullOrWhiteSpace(txtProduct.Text) && numericAmount.Value > 0; // Verifica se o nome do produto e a quantidade são válidos
    }
    
    private void SearchProduct()
    {
        try
        {
            var frmProductData = new FrmProductData();

            if (frmProductData.ShowDialog() != DialogResult.OK) return;

            txtProduct.Text = frmProductData.SelectedProduct; // Preenche o campo de texto com o nome do produto selecionado
            txtCost.Text = frmProductData.CostPrice; // Preenche o campo de texto com o preço do produto selecionado
            numericAmount.Value = 1;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "buscar produto");
        }
    }
    
    private void OpenForm()
    {
        var frmTransferProducts = new FrmTableTransfer(_tableId);
        frmTransferProducts.ShowDialog();
        Close();
    }
    
    private void timer_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!_table.SaveTime.HasValue) return;
            var duration = DateTime.Now - _table.SaveTime.Value;
            labelStayHours.Text = duration.ToString("T");
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar tempo de permanência");
        }
    }
}