using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;
using SIV.Validators;
using SIV.Views.StockGroup;

namespace SIV.Views.Products;

public partial class FrmProducts : Form
{
    private string _selectedProductId;
    
    public FrmProducts()
    {
        InitializeComponent();
    }
    
    private async void FrmProducts_Load(object sender, EventArgs e)
    {
        await LoadProductsAsync();
        LoadSupplier();
        LoadStockGroup();
        ConfigureUiControls(false);
    }

    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return;
        
        ConfigureUiControls(true);
        PopulateFormFields();
        btnSave.Enabled = false; // Desabilita o botão de salvar, pois o usuário não está criando um novo registro
    }

    private void btnNew_Click(object sender, EventArgs e) => PrepareForNewEntry();

    private void btnCancel_Click(object sender, EventArgs e) => ResetForm();

    private void btnSave_Click(object sender, EventArgs e) => SaveFormData();

    private void btnEdit_Click(object sender, EventArgs e) => UpdateFormData(); 

    private void btnDelete_Click(object sender, EventArgs e) => DeleteFormData();
    
    private void btnAddStockGroup_Click(object sender, EventArgs e)
    {
        var frmStockGroup = new FrmStockGroup();
        frmStockGroup.ShowDialog();
    }
    
    private void SaveFormData()
    {
        try
        {
            if (!ValidateFormData()) return;

            var product = CreateProductFromFormData();
            ProductRepository.SaveProduct(product);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowSaveSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "salvar");
        }
    }
    
    private void UpdateFormData()
    {
        try
        {
            if (!ValidateFormData()) return;
            
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                txtCode.Text = GenerateProductCode();
            }

            var product = CreateProductFromFormData();
            ProductRepository.UpdateProduct(product);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowUpdateSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "atualizar");
        }
    }
    
    private void DeleteFormData()
    {
        try
        {
            if (!MessageHelper.ConfirmDeletion()) return;
            
            ProductRepository.DeleteProduct(_selectedProductId);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
    }
    
    private Product CreateProductFromFormData()
    {
        return new Product
        {
            Id = _selectedProductId,
            Code = string.IsNullOrWhiteSpace(txtCode.Text) ? GenerateProductCode() : txtCode.Text,
            Name = txtName.Text.ToUpper(),
            Description = string.IsNullOrEmpty(txtDescription.Text) ? "N/A" : txtDescription.Text.ToUpper(),
            CostPrice = string.IsNullOrEmpty(txtManufacturingExpenses.Text) ? 0 : Convert.ToDecimal(txtManufacturingExpenses.Text.Trim()),
            ResalePrice = string.IsNullOrEmpty(txtResalePrice.Text) ? 0 : Convert.ToDecimal(txtResalePrice.Text.Trim()),
            StockGroup = string.IsNullOrEmpty(cbStockGroup.Text) ? "N/A" : cbStockGroup.Text.ToUpper(),
            Supplier = string.IsNullOrEmpty(cbSupplier.Text) ? "N/A" : cbSupplier.Text.ToUpper()
        };
    }
    
    private async Task LoadProductsAsync()
    {
        try
        {
            gridData.DataSource = await Task.Run(ProductRepository.GetAllProducts);
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar produtos");
        }
    }
    
    private void LoadSupplier()
    {
        try
        {
            //cbSupplier.DataSource = SupplierController.GetAllSuppliers();
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "Id";
            cbSupplier.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar fornecedores");
        }
    }
    
    private void LoadStockGroup()
    {
        try
        {
            cbStockGroup.DataSource = StockGroupRepository.GetAllStockGroup();
            cbStockGroup.DisplayMember = "Name"; 
            cbStockGroup.ValueMember = "Id";
            cbStockGroup.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar grupos de estoque");
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
    
    private void ResetForm()
    {
        ConfigureUiControls(false);
        ClearFields();
        cbStockGroup.SelectedIndex = -1;
        cbSupplier.SelectedIndex = -1;
    }
    
    private void PrepareForNewEntry()
    {
        ConfigureUiControls(true);
        txtName.Focus();
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
    }
    
    private async void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        await LoadProductsAsync();
        ConfigureUiControls(false);
    }
    
    private static string GenerateProductCode()
    {
        return DateTime.Now.ToString("MdHmss");
    }
    
    private bool ValidateFormData()
    {
        var validationResult = ProductValidator.ValidateProduct(
            txtCode.Text, txtName.Text, txtManufacturingExpenses.Text, txtResalePrice.Text);
        
        if (string.IsNullOrEmpty(validationResult)) return true;
        
        MessageHelper.ShowValidationMessage(validationResult);
        return false;
    }

    private void PopulateFormFields()
    {
        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _selectedProductId = gridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do produto selecionado
        txtCode.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtName.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        txtDescription.Text = gridData.CurrentRow?.Cells[3].Value.ToString();
        txtManufacturingExpenses.Text = gridData.CurrentRow?.Cells[4].Value.ToString();
        txtResalePrice.Text = gridData.CurrentRow?.Cells[5].Value.ToString();
        cbStockGroup.Text = gridData.CurrentRow?.Cells[6].Value.ToString();
        cbSupplier.Text = gridData.CurrentRow?.Cells[7].Value.ToString();
    }
}