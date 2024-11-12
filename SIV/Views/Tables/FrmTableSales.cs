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
    private Timer _timer; // Adiciona a propriedade _timer para controlar o tempo de inatividade

    public FrmTableSales(int tableId)
    {
        InitializeComponent();
        _tableId = tableId;
        _userName = SessionManager.CurrentUser.Name;
        InitializeForm();
        InitializeTimer();
    }
    
    private void InitializeForm()
    {
        txtSale.Text = @$"{_tableId}";
        _table = TableRepository.LoadTable(_tableId);
        LoadTableProducts();
        txtSearchUser.Text = _userName; // Preenche o campo de texto com o nome do usuário logado
        txtClient.Text = @"Passante";
        labelDateStatus.Text = _table.SaveDate?.ToString("dd/MM/yyyy");
        labelTimeStatus.Text = _table.SaveTime.ToString();
    }
    
    private void InitializeTimer()
    {
        _timer = new Timer();
        _timer.Interval = 1000; // Atualiza a cada segundo
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }
    
    private void Timer_Tick(object sender, EventArgs e)
    {
        if (_table.SaveTime.HasValue)
        {
            var duration = DateTime.Now - _table.SaveTime.Value;
            labelStayHours.Text = duration.ToString(@"hh\:mm\:ss");
        }
    }
    
    private void btnOk_Click(object sender, EventArgs e)
    {
        if (IsProductInputValid())
        {
            SaveProductToTable();
        }
        else
        {
            Close();
        }
    }
    
    /*private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }*/

    /*private void btnCancelProduct_Click(object sender, EventArgs e)
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
                MessageBox.Show(@"Invalid product ID.");
            }
        }
        else
        {
            MessageHelper.ShowProductNotFound();
        }
    }*/
    
    private void btnSearchProduct_Click(object sender, EventArgs e)
    {
        SearchProduct();
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

    private void txtProduct_TextChanged(object sender, EventArgs e)
    {
        UpdateProductNameLabel(txtProduct.Text);
    }

    private void LoadTableProducts()
    {
        try
        {
            var tableProducts = TableRepository.GetTableProducts(_tableId);
            gridData.DataSource = tableProducts;
            FormatGridData();
            UpdateTotalValueLabel();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar produtos da mesa");
        }
        finally
        {
            ConnectionManager.CloseConnection();
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

    private static bool IsValidProductInput(string productName, decimal amount)
    {
        return !string.IsNullOrWhiteSpace(productName) && amount > 0; // Verifica se o nome do produto e a quantidade são válidos
    }

    private void ResetProductInputFields()
    {
        txtProduct.Clear();
        txtCost.Clear();
        numericAmount.Value = 1;
        txtProduct.Focus();
    }
    
    private bool IsProductInputValid()
    {
        return !string.IsNullOrWhiteSpace(txtProduct.Text) && numericAmount.Value > 0; // Verifica se o nome do produto e a quantidade são válidos
    }

    private void SearchProduct()
    {
        var frmProductData = new FrmProductData();

        if (frmProductData.ShowDialog() != DialogResult.OK) return;

        txtProduct.Text = frmProductData.SelectedProduct; // Preenche o campo de texto com o nome do produto selecionado
        txtCost.Text = frmProductData.CostPrice; // Preenche o campo de texto com o preço do produto selecionado
        numericAmount.Value = 1;
    }

    /*private void btnTransferProducts_Click(object sender, EventArgs e)
    {
        var frmTransferProducts = new FrmTableTransfer(_tableId);
        frmTransferProducts.ShowDialog();
        Close();
    }*/
}