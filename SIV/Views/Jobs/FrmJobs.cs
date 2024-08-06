using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SIV.Controllers;
using SIV.Core;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Views.Jobs;

/// <summary>
/// A classe é responsável pela interface gráfica relacionada à gestão de cargos no sistema.
/// </summary>
public partial class FrmJobs : Form
{
    private readonly JobController _controller;
    private string _id;
    
    public FrmJobs()
    {
        InitializeComponent();
        _controller = new JobController();
    }
    
    private void FrmJobs_Load(object sender, EventArgs e)
    {
        ConfigureUiControls(false);
        LoadJobs();
        btnNew.Enabled = true;
        gridData.Columns[1].HeaderText = @"NOME";
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return; // Se não houver linhas selecionadas, não faz nada
        
        ConfigureUiControls(true); // Habilita os campos do formulário
        btnSave.Enabled = false;
        
        // Preenche o campo de texto com o nome do cargo selecionado
        _id = gridData.SelectedRows[0].Cells[0].Value.ToString();
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
        SaveJob();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        UpdateJob();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteJob();
    }
    
    private void SaveJob()
    {
        try
        {
            var newJob = new Job { Name = txtName.Text };
            
            if (string.IsNullOrWhiteSpace(txtName.Text) || !Regex.IsMatch(txtName.Text, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
            {
                MessageBox.Show(this, @"O nome do cargo não pode estar vazio, Use apenas letras e espaços.", @"Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        
            if (_controller.JobExists(txtName.Text))
            {
                MessageHelper.ShowJobExistMessage(newJob.Name);
                return; // Se o cargo já existe, não é possível salvar
            }
            
            _controller.SaveJob(newJob);
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowSaveSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex); // Registra a exceção no arquivo de log
            MessageHelper.ShowErrorMessage(ex, "salvar");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void UpdateJob()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(_id))
            {
                MessageHelper.ShowMessageJob("editar");
                return;
            }
            
            var job = new Job { Id = _id, Name = txtName.Text };
            
            _controller.UpdateJob(job);
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowUpdateSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "atualizar");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void DeleteJob()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(_id))
            {
                MessageHelper.ShowMessageJob("excluir");
                return;
            }

            if (!MessageHelper.ConfirmDeletion()) return;
            
            _controller.DeleteJob(_id);
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
        gridData.DataSource = _controller.GetAllJobs();
        gridData.Columns[0].Visible = false;
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
        LoadJobs(); // Atualiza a lista de cargos
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
}