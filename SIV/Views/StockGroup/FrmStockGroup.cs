using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Views.StockGroup;

public partial class FrmStockGroup : MetroFramework.Forms.MetroForm
{
    private string _selectedStockGroupId;
    
    public FrmStockGroup() => InitializeComponent();
    
    private void FrmStockGroup_Load(object sender, EventArgs e) => InitializeForm();
    
    private void btnNew_Click(object sender, EventArgs e) => PrepareForNewEntry();
    
    private void btnCancel_Click(object sender, EventArgs e) => ResetForm();
    
    private void btnSave_Click(object sender, EventArgs e) => SaveFormData();
    
    private void btnEdit_Click(object sender, EventArgs e) => UpdateFormData();
    
    private void btnDelete_Click(object sender, EventArgs e) => DeleteFormData();
    
    private void btnSearch_Click(object sender, EventArgs e) => SearchStockGroup();
    
    private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) SearchStockGroup();
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return;
        
        ConfigureUiControls(true);
        PopulateFormFields();
        btnSave.Enabled = false; // Desabilita o botão de salvar, pois o usuário não está criando um novo registro
    }

    private async void InitializeForm()
    {
        ConfigureUiControls(false);
        await LoadStockGroupAsync();
        btnNew.Enabled = true;
        gridData.Columns[1].HeaderText = @"NOME";
        gridData.Columns[2].HeaderText = @"DATA DE CADASTRO";
    }
    
    private void SaveFormData()
    {
        try
        {
            var newStockGroup = new Stock { Name = txtName.Text.ToUpper() };
            
            if (string.IsNullOrWhiteSpace(txtName.Text) || !Regex.IsMatch(txtName.Text, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
            {
                MessageBox.Show(this, @"O nome do estoque não pode estar vazio, Use apenas letras e espaços.", @"Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            StockGroupRepository.SaveStockGroup(newStockGroup);
            
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
            var newStockGroup  = new Stock { Id = _selectedStockGroupId, Name = txtName.Text.ToUpper() };
            StockGroupRepository.UpdateStockGroup(newStockGroup);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowUpdateSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "editar");
        }
    }
    
    private void DeleteFormData()
    {
        try
        {
            if (!MessageHelper.ConfirmDeletion()) return;
            
            StockGroupRepository.DeleteStockGroup(_selectedStockGroupId);
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
    }
    
    private async Task LoadStockGroupAsync()
    {
        try
        {
            gridData.DataSource = await Task.Run(StockGroupRepository.GetAllStockGroup);
            gridData.Columns[0].Visible = false;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os grupos de estoque");
        }
    }
    
    private void SearchStockGroup()
    {
        try
        {
            gridData.DataSource = StockGroupRepository.SearchByName(txtSearch.Text);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "pesquisar os grupos de estoque");
        }
    }
    
    private void ConfigureUiControls(bool enable)
    {
        btnNew.Enabled = !enable;
        btnSave.Enabled = enable;
        btnEdit.Enabled = enable;
        btnDelete.Enabled = enable;
        btnCancel.Enabled = enable;
        txtName.Enabled = enable;
        gridData.Enabled = !enable;
    }

    private void ResetForm()
    {
        ConfigureUiControls(false);
        txtName.Clear();
    }

    private void PrepareForNewEntry()
    {
        ConfigureUiControls(true);
        txtName.Focus();
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        gridData.Enabled = false;
    }
    
    private async void UpdateUiAfterSaveOrUpdate()
    {
        txtName.Clear();
        await LoadStockGroupAsync();
        ConfigureUiControls(false);
    }

    private void PopulateFormFields()
    {
        // Preenche o campo de texto com o nome do cargo selecionado
        _selectedStockGroupId = gridData.SelectedRows[0].Cells[0].Value.ToString(); // Armazena o ID do grupo de estoque selecionado
        txtName.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
    }
}