using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Views.Jobs;

/// <summary>
/// A classe é responsável pela interface gráfica relacionada à gestão de cargos no sistema.
/// </summary>
public partial class FrmJobs : Form
{
    private string _selectedJobId;
    
    public FrmJobs()
    {
        InitializeComponent();
    }
    
    private void FrmJobs_Load(object sender, EventArgs e)
    {
        InitializeForm();
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return;
        
        ConfigureUiControls(true);
        btnSave.Enabled = false; // Desabilita o botão de salvar, pois o usuário não está criando um novo registro
        
        // Preenche o campo de texto com o nome do cargo selecionado
        _selectedJobId = gridData.SelectedRows[0].Cells[0].Value.ToString();
        txtName.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
    }

    private void btnNew_Click(object sender, EventArgs e) => PrepareForNewEntry();

    private void btnCancel_Click(object sender, EventArgs e) => ResetForm();

    private void btnSave_Click(object sender, EventArgs e) => SaveFormData();

    private void btnEdit_Click(object sender, EventArgs e) => UpdateFormData();

    private void btnDelete_Click(object sender, EventArgs e) => DeleteFormData();
    
    private void InitializeForm()
    {
        ConfigureUiControls(false);
        LoadJobs();
        ConfigureGridHeaders();
    }
    
    private void SaveFormData()
    {
        try
        {
            if (!ValidadeJobName(txtName.Text)) return;
            
            var newJob = new Job { Name = txtName.Text };
            
            if (JobRepository.JobExists(txtName.Text))
            {
                MessageHelper.ShowJobExistMessage(newJob.Name);
                return;
            }
            
            JobRepository.SaveJob(newJob);
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
            if (string.IsNullOrWhiteSpace(_selectedJobId))
            {
                MessageHelper.ShowMessageJob("editar");
                return;
            }
            
            var job = new Job { Id = _selectedJobId, Name = txtName.Text };
            JobRepository.UpdateJob(job);
            
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
            if (string.IsNullOrWhiteSpace(_selectedJobId))
            {
                MessageHelper.ShowMessageJob("excluir");
                return;
            }

            if (!MessageHelper.ConfirmDeletion()) return;
            
            JobRepository.DeleteJob(_selectedJobId);
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
    }
    
    private void LoadJobs()
    {
        try
        {
            gridData.DataSource = JobRepository.GetAllJobs();
            gridData.Columns[0].Visible = false;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar");
        }
    }
    
    private void ConfigureGridHeaders()
    {
        gridData.Columns[1].HeaderText = @"NOME";
        gridData.Columns[2].HeaderText = @"DATA DE CADASTRO";
    }
    
    private void PrepareForNewEntry()
    {
        ConfigureUiControls(true);
        txtName.Focus();
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
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
        LoadJobs();
        ConfigureUiControls(false);
    }
    
    private void ResetForm()
    {
        ConfigureUiControls(false);
        txtName.Clear();
    }

    private static bool ValidadeJobName(string jobName)
    {
        if (!string.IsNullOrWhiteSpace(jobName) &&
            Regex.IsMatch(jobName, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{3,}$")) return true;
        
        MessageHelper.ShowValidationMessage(@"O nome do cargo não pode estar vazio, Use apenas letras e espaços.");
        return false;
    }
}