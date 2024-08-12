using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIV.Controllers;
using SIV.Core;
using SIV.Models;
using SIV.Validators;

namespace SIV.Views.Users;

public partial class FrmUsers : Form
{
    private readonly UserController _controller = new();
    private string _selectedUserId;
    public FrmUsers()
    {
        InitializeComponent();
    }
    
    private void FrmUsers_Load(object sender, EventArgs e)
    {
        UserList();
        ListJob();
        ConfigureUiControls(false);
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        ClearFields();
        ConfigureUiControls(true);

        // Desabilita controles específicos durante a edição
        btnSave.Enabled = false;
        
        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _selectedUserId = gridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do funcionário
        txtName.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtPassword.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        txtRepeatPassword.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        cbJob.Text = gridData.CurrentRow?.Cells[3].Value.ToString();
        
        var accessLevel = gridData.CurrentRow?.Cells[4].Value.ToString().ToLower();
        btnFullAccess.Checked = accessLevel == "full";
        btnPartialAccess.Checked = accessLevel == "parcial";
        
        // Verifica se o status do funcionário é bloqueado
        var activeStatus = gridData.CurrentRow?.Cells[5].Value.ToString().ToLower();
        btnActive.Checked = activeStatus == "ativo";
    }
    
    private void btnNew_Click(object sender, EventArgs e)
    {
        txtName.Focus();
        ConfigureUiControls(true);
        gridData.Enabled = false;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ClearFields();
        ConfigureUiControls(false);
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
        throw new System.NotImplementedException();
    }
    
    private void SaveFormData()
    {
        try
        {
            if (!ValidateFormData()) return;
            
            var name = txtName.Text;
            var password = txtPassword.Text;
            var job = cbJob.Text;
            var accessLevel = btnFullAccess.Checked ? "Full" : btnPartialAccess.Checked ? "Parcial" : "None";
            var active = btnActive.Checked ? "Ativo" : "Inativo";
            var permissions = new List<string>();

            if (btnFullAccess.Checked)
            {
                permissions.Add("AccessSystem");
                permissions.Add("ManageCadastres");
                permissions.Add("ManageCashFlow");
                permissions.Add("CreateOrders");
            }
            else if (btnPartialAccess.Checked)
            {
                permissions.Add("AccessSystem");
                permissions.Add("CreateOrders");
            }
            
            var user = new User
            {
                Name = name,
                Password = password,
                Job = job,
                Access = accessLevel,
                Active = active,
                Permissions = permissions
            };
            
            _controller.SaveUser(user);
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowSaveSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "salvar");
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
            if (!ValidateFormData()) return;

            var user = new User
            {
                Id = _selectedUserId,
                Name = txtName.Text,
                Password = txtPassword.Text,
                Job = cbJob.Text,
                Access = btnFullAccess.Checked ? "Full" : btnPartialAccess.Checked ? "Parcial" : "None",
                Active = btnActive.Checked ? "Ativo" : "Inativo",
                Permissions = btnFullAccess.Checked
                    ?
                    new List<string> { "AccessSystem", "ManageCadastres", "ManageCashFlow", "CreateOrders" }
                    : btnPartialAccess.Checked
                        ? new List<string> { "AccessSystem", "CreateOrders" }
                        : new List<string>()
            };

            _controller.UpdateUser(user);
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
    
    private void UserList()
    {
        try
        {
            gridData.DataSource = _controller.GetAllUsers();
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar a lista de usuários");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void ListJob()
    {
        try
        {
            var jobs = new JobController().GetAllJobs();
            
            cbJob.DataSource = jobs;
            cbJob.DisplayMember = "Name";
            cbJob.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar cargos");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns[1].HeaderText = @"NOME";
        gridData.Columns[3].HeaderText = @"GARGO";
        gridData.Columns[4].HeaderText = @"ACESSO";
        gridData.Columns[5].HeaderText = @"STATUS";
        gridData.Columns[0].Visible = false;
        gridData.Columns[2].Visible = false;
        gridData.Columns[6].Visible = false;
    }
    
    private void ConfigureUiControls(bool enable)
    {
        btnNew.Enabled = !enable;
        btnSave.Enabled = enable;
        btnEdit.Enabled = enable;
        btnDelete.Enabled = enable;
        btnCancel.Enabled = enable;
        btnActive.Enabled = enable;
        btnFullAccess.Enabled = enable;
        btnPartialAccess.Enabled = enable;
        txtName.Enabled = enable;
        txtPassword.Enabled = enable;
        txtRepeatPassword.Enabled = enable;
        cbJob.Enabled = enable;
    }
    
    private void ClearFields()
    {
        txtName.Text = "";
        txtPassword.Text = "";
        txtRepeatPassword.Text = "";
        cbJob.Text = "";
        btnActive.Checked = false;
        btnFullAccess.Checked = false;
        btnPartialAccess.Checked = false;
    }
    
    private void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        UserList();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }

    private bool ValidateFormData()
    {
        var validationResult = UserValidator.ValidateUser(txtName.Text, txtPassword.Text, txtRepeatPassword.Text, cbJob.Text);
        
        if (string.IsNullOrEmpty(validationResult)) return true; // Se a validação passar, retorna verdadeiro
        
        MessageHelper.ShowValidationMessage(validationResult);
        return false; // Se a validação falhar, retorna falso 
    }
}