using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Views.StockGroup;

public partial class FrmStockGroup : MetroFramework.Forms.MetroForm
{
    private string _selectedStockGroupId;
    
    public FrmStockGroup()
    {
        InitializeComponent();
    }
    
    private void FrmStockGroup_Load(object sender, EventArgs e)
    {
        ConfigureUiControls(false);
        LoadStockGroup();
        btnNew.Enabled = true;
        gridData.Columns[1].HeaderText = @"NOME";
        gridData.Columns[2].HeaderText = @"DATA DE CADASTRO";
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return; // Verifica se há linhas selecionadas
        
        ConfigureUiControls(true);
        btnSave.Enabled = false;
        
        // Preenche o campo de texto com o nome do cargo selecionado
        _selectedStockGroupId = gridData.SelectedRows[0].Cells[0].Value.ToString(); // Armazena o ID do grupo de estoque selecionado
        txtName.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(true);
        txtName.Focus();
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        gridData.Enabled = false;
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(false);
        txtName.Clear();
        gridData.Enabled = true;
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
            if (string.IsNullOrWhiteSpace(_selectedStockGroupId))
            {
                MessageHelper.ShowMessageJob("excluir");
                return;
            }

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
    
    private void LoadStockGroup()
    {
        try
        {
            gridData.DataSource = StockGroupRepository.GetAllStockGroup();
            gridData.Columns[0].Visible = false;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar os grupos de estoque");
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
    
    private void UpdateUiAfterSaveOrUpdate()
    {
        txtName.Clear();
        LoadStockGroup();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
}