using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Views.Products;

public partial class FrmProducts : Form
{
    private int _selectedProductId;
    
    public FrmProducts()
    {
        InitializeComponent();
    }
    
    private void FrmProducts_Load(object sender, EventArgs e)
    {
        LoadProducts();
        LoadSupplier();
        LoadStockGroup();
    }

    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return; // Verifica se há linhas selecionadas
        
        ConfigureUiControls(true);
        btnSave.Enabled = false;

        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _selectedProductId = Convert.ToInt32(gridData.CurrentRow?.Cells[0].Value.ToString()); // Armazena o ID do produto selecionado
        txtCode.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtName.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        txtDescription.Text = gridData.CurrentRow?.Cells[3].Value.ToString();
        txtManufacturingExpenses.Text = gridData.CurrentRow?.Cells[4].Value.ToString();
        txtResalePrice.Text = gridData.CurrentRow?.Cells[5].Value.ToString();
        cbStockGroup.Text = gridData.CurrentRow?.Cells[6].Value.ToString();
        cbSupplier.Text = gridData.CurrentRow?.Cells[7].Value.ToString();
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(true);
        ClearFields();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(false);
        ClearFields();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveFormData();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        UpdateFormData();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteFormData();
    }
    
    private void SaveFormData()
    {
        try
        {
            //if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução

            var product = CreateProductFromFormData();
            ProductController.SaveProduct(product);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowSaveSuccessMessage();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro ao salvar no banco de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro inesperado: {ex.Message}");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void UpdateFormData()
    {
        try
        {
            //if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução

            var product = CreateProductFromFormData();
            ProductController.UpdateProduct(product);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowSaveSuccessMessage();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro ao salvar no banco de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro inesperado: {ex.Message}");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void DeleteFormData()
    {
        try
        {
            if (!MessageHelper.ConfirmDeletion()) return;
            
            ProductController.DeleteProduct(_selectedProductId);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private Product CreateProductFromFormData()
    {
        return new Product
        {
            Id = _selectedProductId,
            Code = txtCode.Text,
            Name = txtName.Text.ToUpper(),
            Description = txtDescription.Text.ToUpper(),
            CostPrice = Convert.ToDecimal(txtManufacturingExpenses.Text.Trim()),
            ResalePrice = Convert.ToDecimal(txtResalePrice.Text.Trim()),
            StockGroup = cbStockGroup.Text.ToUpper(),
            Supplier = cbSupplier.Text.ToUpper()
        };
    }
    
    private void LoadProducts()
    {
        try
        {
            gridData.DataSource = ProductController.GetAllProducts();
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar produtos");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void LoadSupplier()
    {
        try
        {
            //cbSupplier.DataSource = JobController.GetAllJobs();
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar fornecedores");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void LoadStockGroup()
    {
        try
        {
            //cbStockGroup.DataSource = StockGroupController.GetAllStockGroups();
            cbStockGroup.DisplayMember = "Name";
            cbStockGroup.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar grupos de estoque");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns[0].Visible = false;
        gridData.Columns[1].HeaderText = @"CÓD";
        gridData.Columns[2].HeaderText = @"NOME";
        gridData.Columns[3].HeaderText = @"DESCRIÇÃO";
        gridData.Columns[4].HeaderText = @"PREÇO DE CUSTO";
        gridData.Columns[5].HeaderText = @"PREÇO DE REVENDA";
        gridData.Columns[6].HeaderText = @"GRUPO DE ESTOQUE";
        gridData.Columns[7].HeaderText = @"FORNECEDOR";
    }
    
    private void ConfigureUiControls(bool enable)
    {
        btnNew.Enabled = !enable;
        btnSave.Enabled = enable;
        btnEdit.Enabled = enable;
        btnDelete.Enabled = enable;
        btnCancel.Enabled = enable;
        txtName.Enabled = enable;
        txtCode.Enabled = enable;
        txtDescription.Enabled = enable;
        txtManufacturingExpenses.Enabled = enable;
        txtResalePrice.Enabled = enable;
        cbStockGroup.Enabled = enable;
        cbSupplier.Enabled = enable;
        gridData.Enabled = !enable;
    }
    
    private void ClearFields()
    {
        txtName.Text = "";
        txtCode.Text = "";
        txtDescription.Text = "";
        txtManufacturingExpenses.Text = "";
        txtResalePrice.Text = "";
        cbStockGroup.SelectedIndex = -1;
        cbSupplier.SelectedIndex = -1;
    }
    
    private void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        LoadProducts();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
}