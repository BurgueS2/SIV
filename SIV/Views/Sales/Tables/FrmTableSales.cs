using System;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;
using SIV.teste;

namespace SIV.Views.Sales.Tables;

public partial class FrmTableSales : MetroFramework.Forms.MetroForm
{
    private readonly int _tableId;
    private Table _table;

    public FrmTableSales(int tableId)
    {
        InitializeComponent();
        _tableId = tableId;
        txtSale.Text = @$"{_tableId}";
        _table = TableRepository.LoadTable(_tableId);
        LoadTableProducts();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtProduct.Text) || numericAmount.Value <= 0)
        {
            Close();
        }
        else
        {
            SaveProductToTable();
        }
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
        gridData.Columns[0].HeaderText = @"Nome do Produto";
        gridData.Columns[1].HeaderText = @"Preço do Produto";
        gridData.Columns[2].HeaderText = @"Quantidade";

        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Cells["product_name"].Value?.ToString()))
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

                TableRepository.AddProductToTable(_tableId, product.Name, product.ResalePrice, amount);
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
            if (row.Cells["product_price"].Value != null)
            {
                totalValue += Convert.ToDecimal(row.Cells["product_price"]. Value) * Convert.ToDecimal(row.Cells["amount"].Value);
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
        numericAmount.Value = 1;
        txtProduct.Focus();
    }
}