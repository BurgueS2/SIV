using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;
using SIV.Validators;

namespace SIV.Views.Clients;

/// <summary>
/// Formulário responsável por gerenciar os clientes do sistema, permitindo a criação, edição e exclusão de clientes.
/// Além disso, é possível visualizar a lista de clientes cadastrados e suas respectivas informações.
/// </summary>
public partial class FrmClients : Form
{
    private string _selectedUserId;
    
    public FrmClients()
    {
        InitializeComponent();
    }
    
    private void FrmClients_Load(object sender, EventArgs e)
    {
        InitializeForm();
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return;
        
        PopulateFormFields();
        ConfigureUiControls(true);
        btnSave.Enabled = false;
        EnableSearchControls(true);
    }
    
    private void btnNew_Click(object sender, EventArgs e)
    {
        PrepareForNewEntry();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ResetForm();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveFormData();
        EnableSearchControls(true);
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        UpdateFormData();
        EnableSearchControls(true);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteFormData();
        EnableSearchControls(true);
    }
    
    private void btnSearchName_Click(object sender, EventArgs e)
    {
        SearchByName();
    }

    private void btnSearchCpf_Click(object sender, EventArgs e)
    {
        SearchByCpf();
    }
    
    private async void InitializeForm()
    {
        await LoadClientAsync();
        ConfigureUiControls(false);
        EnableSearchControls(true);
    }
    
    private void SaveFormData()
    {
        try
        {
            if (!VerifyCpfAndEmail(AddCpfMask(txtCpf.Text), txtEmail.Text)) return;
            if (!ValidateFormData()) return;
            
            var client = CreateClientFromFormData();
            ClientRepository.SaveClient(client);
            
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
            if (!VerifyCpfAndEmail(AddCpfMask(txtCpf.Text), txtEmail.Text)) return;

            var client = CreateClientFromFormData();
            ClientRepository.UpdateClient(client);
            
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
            
            ClientRepository.DeleteClient(_selectedUserId);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
    }
    
    private Client CreateClientFromFormData()
    {
        return new Client
        {
            Id = _selectedUserId,
            Name = txtName.Text.ToUpper(),
            Cpf = AddCpfMask(txtCpf.Text),
            Status = btnBlocked.Checked ? "BLOQUEADO" : btnUnlocked.Checked ? "DESBLOQUE." : string.Empty,
            Phone = AddPhoneMask(txtPhone.Text),
            Email = txtEmail.Text.ToUpper(),
            Address = txtAddress.Text.ToUpper(),
            ReferencePoint = string.IsNullOrWhiteSpace(txtRefPoint.Text) ? "N/A" : txtRefPoint.Text.ToUpper(),
            Observation = string.IsNullOrWhiteSpace(txtObservation.Text) ? "N/A" : txtObservation.Text.ToUpper(),
            Sex = cbSex.Text.ToUpper()
        };
    }
    
    private static string AddCpfMask(string cpf)
    {
        if (cpf.Length == 11)
        {
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        return cpf;
    }
    
    private static string AddPhoneMask(string phone)
    {
        if (phone.Length == 11)
        {
            return $"({phone.Substring(0, 2)}) {phone.Substring(2, 5)}-{phone.Substring(7, 4)}";
        }

        return phone;
    }
    
    private void SearchByName()
    {
        try
        {
            gridData.DataSource = ClientRepository.SearchByName(txtSearchName.Text.ToUpper());
            FormatGridData();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "buscar pelo nome");
        }
    }

    private void SearchByCpf()
    {
        try
        {
            gridData.DataSource = ClientRepository.SearchByCpf(AddCpfMask(txtSearchCpf.Text));
            FormatGridData();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "buscar pelo CPF");
        }
    }
    
    private async Task LoadClientAsync()
    {
        try
        {
            gridData.DataSource =await Task.Run(ClientRepository.GetAllClients);
            FormatGridData();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "acessar os clientes");
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns[0].Visible = false;
        gridData.Columns[1].HeaderText = @"NOME";
        gridData.Columns[2].HeaderText = @"CPF";
        gridData.Columns[3].HeaderText = @"STATUS";
        gridData.Columns[4].HeaderText = @"TELEFONE";
        gridData.Columns[5].HeaderText = @"EMAIL";
        gridData.Columns[6].HeaderText = @"ENDEREÇO";
        gridData.Columns[7].HeaderText = @"PONTO DE REF.";
        gridData.Columns[8].HeaderText = @"OBSERVAÇÃO";
        gridData.Columns[9].HeaderText = @"SEXO";
        gridData.Columns[10].HeaderText = @"DATA";
    }
    
    private void ConfigureUiControls(bool enable)
    {
        btnNew.Enabled = !enable;
        btnSave.Enabled = enable;
        btnEdit.Enabled = enable;
        btnDelete.Enabled = enable;
        btnCancel.Enabled = enable;
        txtName.Enabled = enable;
        txtCpf.Enabled = enable;
        txtPhone.Enabled = enable;
        txtAddress.Enabled = enable;
        txtRefPoint.Enabled = enable;
        txtEmail.Enabled = enable;
        txtObservation.Enabled = enable;
        cbSex.Enabled = enable;
        gridData.Enabled = !enable;
        btnBlocked.Enabled = enable;
        btnUnlocked.Enabled = enable;
    }
    
    private void EnableSearchControls(bool enable)
    {
        btnSearchCpf.Enabled = enable;
        btnSearchName.Enabled = enable;
        txtSearchName.Enabled = enable;
        txtSearchCpf.Enabled = enable;
    }
    
    private void ClearFields()
    {
        txtName.Text = "";
        txtCpf.Text = "";
        txtPhone.Text = "";
        txtAddress.Text = "";
        txtRefPoint.Text = "";
        txtEmail.Text = "";
        txtObservation.Text = "";
        btnBlocked.Checked = false;
        btnUnlocked.Checked = false;
    }
    
    private async void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        await LoadClientAsync();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
    
    private bool ValidateFormData()
    {
        var validationResult = ClientValidator.ValidateClient(txtName.Text, txtCpf.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text);
        
        if (string.IsNullOrEmpty(validationResult)) return true;
        
        MessageHelper.ShowValidationMessage(validationResult);
        
        return false;
    }

    private static bool VerifyCpfAndEmail(string cpf, string email)
    {
        // Verifica se o CPF já está cadastrado
        if (!ClientRepository.VerifyCpfExistence(cpf))
        {
            MessageHelper.ShowRegisteredCpfMessage();
            return false;
        }

        // Verifica se o e-mail já está cadastrado
        if (!ClientRepository.VerifyEmailExisting(email))
        {
            // Se o e-mail já estiver cadastrado, exibe uma mensagem de confirmação
            return MessageHelper.ShowEmailExistMessage();
        }

        return true;
    }
    
    private void PopulateFormFields()
    {
        // Preenche os campos do formulário com os valores da linha selecionada
        _selectedUserId = gridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do cliente
        txtName.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtCpf.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        
        // Verifica se o status do cliente é bloqueado ou desbloqueado
        var statusValue = gridData.CurrentRow?.Cells[3].Value.ToString().ToUpper();
        btnBlocked.Checked = statusValue == "BLOQUEADO";
        btnUnlocked.Checked = statusValue == "DESBLOQUE.";
        
        // Preenche os campos restantes
        txtPhone.Text = gridData.CurrentRow?.Cells[4].Value.ToString();
        txtEmail.Text = gridData.CurrentRow?.Cells[5].Value.ToString();
        txtAddress.Text = gridData.CurrentRow?.Cells[6].Value.ToString();
        txtRefPoint.Text = gridData.CurrentRow?.Cells[7].Value.ToString();
        txtObservation.Text = gridData.CurrentRow?.Cells[8].Value.ToString();
        cbSex.Text = gridData.CurrentRow?.Cells[9].Value.ToString();
    }
    
    private void PrepareForNewEntry()
    {
        ConfigureUiControls(true);
        EnableSearchControls(false);
        txtName.Focus();
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        gridData.Enabled = false;
    }

    private void ResetForm()
    {
        ClearFields();
        ConfigureUiControls(false);
        EnableSearchControls(true);
        gridData.Enabled = true;
    }
}