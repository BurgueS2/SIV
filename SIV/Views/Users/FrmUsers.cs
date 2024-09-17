using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;
using SIV.Validators;

namespace SIV.Views.Users;

/// <summary>
/// Formulário responsável por gerenciar os usuários do sistema, permitindo a criação, edição e exclusão de funcionários.
/// Além disso, é possível visualizar a lista de funcionários cadastrados e suas respectivas informações.
/// </summary>
public partial class FrmUsers : Form
{
    private string _selectedUserId;
    
    public FrmUsers()
    {
        InitializeComponent();
    }
    
    private async void FrmUsers_Load(object sender, EventArgs e)
    {
        await LoadUserAsync();
        LoadJob();
        ConfigureUiControls(false);
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        ClearFields();
        ConfigureUiControls(true);
        PopulateFormFields();
        btnSave.Enabled = false; // Desabilita o botão de salvar, pois o usuário não está criando um novo registro
    }
    
    private void btnNew_Click(object sender, EventArgs e) => PrepareForNewEntry();

    private void btnCancel_Click(object sender, EventArgs e) => ResetForm();

    private void btnSave_Click(object sender, EventArgs e) => SaveFormData();

    private void btnEdit_Click(object sender, EventArgs e) => UpdateFormData();

    private void btnDelete_Click(object sender, EventArgs e) => DeleteFormData();
    
    private void SaveFormData()
    {
        try
        {
            if (!ValidateFormData()) return;
            
            var user = CreateUserFromFormData();
            UserRepository.SaveUser(user);
            
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

            var user = CreateUserFromFormData();
            UserRepository.UpdateUser(user);
            
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
            
            UserRepository.DeleteUser(_selectedUserId);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "deletar");
        }
    }
    
    private User CreateUserFromFormData()
    {
        return new User
        {
            Id = _selectedUserId,
            Name = txtName.Text.ToUpper().Trim(),
            Password = txtPassword.Text.Trim(),
            Job = cbJob.Text.ToUpper(),
            Access = GetAccessLevel(),
            Active = btnActive.Checked ? "ATIVO" : "INATIVO", // Se o botão de ativo estiver marcado, retorna "ATIVO", senão, retorna "INATIVO"
            Permissions = GetPermissions()
        };
    }
    
    private async Task LoadUserAsync()
    {
        try
        {
            gridData.DataSource = await Task.Run(UserRepository.GetAllUsers);
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar a lista de usuários");
        }
    }
    
    private void LoadJob()
    {
        try
        {
            cbJob.DataSource = JobRepository.GetAllJobs();
            cbJob.DisplayMember = "Name";
            cbJob.ValueMember = "Id";
            cbJob.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar cargos");
        }
    }

    /// <summary>
    /// Retorna o nível de acesso selecionado no formulário.
    /// Será utilizado para definir as permissões do usuário, conforme o nível de acesso selecionado.
    /// </summary>
    private string GetAccessLevel()
    {
        if (btnFullAccess.Checked) return "FULL";
        return btnPartialAccess.Checked ? "PARCIAL" : "SEM ACESSO"; // Se nenhum dos dois estiver marcado, retorna "SEM ACESSO"
    }

    /// <summary>
    /// Retorna a lista de permissões conforme o nível de acesso selecionado.
    /// </summary>
    /// <example>Se o nível de acesso for "FULL", retorna todas as permissões disponíveis.</example>
    /// <example>Se o nível de acesso for "PARCIAL", retorna apenas as permissões de acesso ao sistema e criação de pedidos.</example>
    /// <returns>Se nenhum dos dois estiver marcado, retorna uma lista vazia.</returns>
    private List<string> GetPermissions()
    {
        if (btnFullAccess.Checked)
        {
            return new List<string> { "AccessSystem", "ManageCadastres", "ManageCashFlow", "CreateOrders" };
        }
        
        if (btnPartialAccess.Checked)
        {
            return new List<string> { "AccessSystem", "CreateOrders" };
        }
        
        return []; // Se nenhum dos dois estiver marcado, retorna uma lista vazia
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
    
    private async void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        await LoadUserAsync();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }

    private bool ValidateFormData()
    {
        var validationResult = UserValidator.ValidateUser(txtName.Text, txtPassword.Text, txtRepeatPassword.Text, cbJob.Text);
        
        if (string.IsNullOrEmpty(validationResult)) return true;
        
        MessageHelper.ShowValidationMessage(validationResult);
        return false;
    }

    private void PopulateFormFields()
    {
        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _selectedUserId = gridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do funcionário
        txtName.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtPassword.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        txtRepeatPassword.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        cbJob.Text = gridData.CurrentRow?.Cells[3].Value.ToString();
        
        // Verifica o nível de acesso do usuário
        var accessLevel = gridData.CurrentRow?.Cells[4].Value.ToString().ToUpper();
        btnFullAccess.Checked = accessLevel == "FULL";
        btnPartialAccess.Checked = accessLevel == "PARCIAL";
        
        // Verifica se a condição do usuário é ativo ou inativo
        var activeStatus = gridData.CurrentRow?.Cells[5].Value.ToString().ToUpper();
        btnActive.Checked = activeStatus == "ATIVO";
    }

    private void PrepareForNewEntry()
    {
        ClearFields();
        ConfigureUiControls(true);
        txtName.Focus();
        btnDelete.Enabled = false;
        btnEdit.Enabled = false;
        gridData.Enabled = false;
        cbJob.SelectedIndex = -1;
    }

    private void ResetForm()
    {
        ClearFields();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
}