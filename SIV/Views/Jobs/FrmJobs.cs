using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

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
        ConfigureUiControls(false);
        LoadJobs();
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
        _selectedJobId = gridData.SelectedRows[0].Cells[0].Value.ToString();
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
            var newJob = new Job { Name = txtName.Text };
            
            if (string.IsNullOrWhiteSpace(txtName.Text) || !Regex.IsMatch(txtName.Text, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
            {
                MessageBox.Show(this, @"O nome do cargo não pode estar vazio, Use apenas letras e espaços.", @"Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        
            if (JobController.JobExists(txtName.Text))
            {
                MessageHelper.ShowJobExistMessage(newJob.Name);
                return;
            }
            
            JobController.SaveJob(newJob);
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
            if (string.IsNullOrWhiteSpace(_selectedJobId))
            {
                MessageHelper.ShowMessageJob("editar");
                return;
            }
            
            var job = new Job { Id = _selectedJobId, Name = txtName.Text };
            JobController.UpdateJob(job);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowUpdateSuccessMessage();
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
            if (string.IsNullOrWhiteSpace(_selectedJobId))
            {
                MessageHelper.ShowMessageJob("excluir");
                return;
            }

            if (!MessageHelper.ConfirmDeletion()) return;
            
            JobController.DeleteJob(_selectedJobId);
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
    
    private void LoadJobs()
    {
        try
        {
            gridData.DataSource = JobController.GetAllJobs();
            gridData.Columns[0].Visible = false;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar");
        }
        finally
        {
            ConnectionManager.CloseConnection();
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
        LoadJobs();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
}