using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;

namespace SIV.Views.Tables.ProductData;

public partial class FrmProductData : MetroFramework.Forms.MetroForm
{
    public string SelectedProduct { get; private set; }
    public string CostPrice { get; private set; }
    
    public FrmProductData()
    {
        InitializeComponent();
        LoadProduct();
    }
    
    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.CurrentRow == null) return;
        
        SelectedProduct = gridData.CurrentRow.Cells["Name"].Value.ToString();
        CostPrice = gridData.CurrentRow.Cells["ResalePrice"].Value.ToString();
        DialogResult = DialogResult.OK;
        Close();
    }
    
    private void LoadProduct()
    {
        try
        {
            var products = ProductRepository.GetAllProducts();
            UpdateGridData(products);
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "acessar");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void UpdateGridData(object dataSource)
    {
        gridData.DataSource = dataSource;
        FormatGridData();
    }

    private void FormatGridData()
    {
        gridData.Columns[0].Visible = false;
        gridData.Columns[3].Visible = false;
        gridData.Columns[4].Visible = false;
        gridData.Columns[6].Visible = false;
        gridData.Columns[7].Visible = false;
        gridData.Columns[1].HeaderText = @"Cód.";
        gridData.Columns[2].HeaderText = @"NOME";
        gridData.Columns[5].HeaderText = @"PREÇO";
    }

    private void txtProduct_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        
        SearchProductsByName(txtProduct.Text);
        e.Handled = true;
        e.SuppressKeyPress = true;
    }

    private void SearchProductsByName(string productName)
    {
        try
        {
            var products = ProductRepository.SearchProductsByName(productName);
            UpdateGridData(products);
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "buscar por produtos");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
}