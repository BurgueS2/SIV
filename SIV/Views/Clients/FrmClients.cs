using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Controllers;
using SIV.Core;
using SIV.Models;
using SIV.Repositories;
using SIV.Validators;

namespace SIV.Views.Clients;

/// <summary>
/// Classe responsável por gerenciar a interface gráfica do formulário de clientes.
/// </summary>
public partial class FrmClients : Form
{
    private readonly ClientController _controller;
    private string _id;
    private string _oldCpf; // CPF antigo do cliente, usado para verificações durante a atualização.
    
    public FrmClients()
    {
        InitializeComponent();
        _controller = new ClientController();
    }
    
    private void FrmClients_Load(object sender, EventArgs e)
    {
        ClientList();
        ConfigureUiControls(false);
        EnableSearchControls(true);
        gridData.CellFormatting += GridDataClient_CellFormatting; // Adiciona um evento de formatação de célula
    }
    
    private void GridDataClient_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Verifica se a coluna é a coluna de status
        if (gridData.Columns[e.ColumnIndex].Name != "status") return; // Se não for, interrompe a execução
        
        if (e.Value == null) return;
        
        // Converte o valor para "Bloqueado" ou "Desbloqueado"
        e.Value = e.Value.ToString() == "1" || e.Value.ToString().ToLower() == "true" ? "Bloqueado" : "Desbloqueado";
        e.FormattingApplied = true; // Indica que a formatação foi aplicada
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        // if (e.RowIndex <= -1) return; // Se o índice da linha for menor ou igual a -1, interrompe a execução
        
        ClearFields();
        ConfigureUiControls(true);
        EnableSearchControls(false);

        // Desabilita controles específicos durante a edição
        btnSave.Enabled = false;
        txtCode.Enabled = false;
        
        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _id = gridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do funcionário
        txtCode.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtName.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        txtCpf.Text = gridData.CurrentRow?.Cells[3].Value.ToString();
        _oldCpf = gridData.CurrentRow?.Cells[3].Value.ToString(); // Salva o CPF antigo para verificar se foi alterado
        txtValue.Text = gridData.CurrentRow?.Cells[4].Value.ToString();

        // Verifica se o status do funcionário é bloqueado
        var statusValue = gridData.CurrentRow?.Cells[5].Value.ToString().ToLower();
        var isBlocked = statusValue == "1"; // Se o valor for 1, o funcionário está bloqueado se não, está desbloqueado
        btnBlocked.Checked = isBlocked;
        btnUnlocked.Checked = !isBlocked;

        // Preenche os campos restantes
        txtPhone.Text = gridData.CurrentRow?.Cells[6].Value.ToString();
        txtEmail.Text = gridData.CurrentRow?.Cells[7].Value.ToString();
        txtAddress.Text = gridData.CurrentRow?.Cells[8].Value.ToString();
    }
    
    private void btnNew_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(true);
        EnableSearchControls(false);
        txtName.Focus();
        
        // Desabilita controles específicos durante a edição
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        gridData.Enabled = false;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ClearFields();
        ConfigureUiControls(false);
        EnableSearchControls(true);
        gridData.Enabled = true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveFormData();
        EnableSearchControls(true);
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        UpdateClientData();
        EnableSearchControls(true);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteClient();
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
    
    private void SearchByName()
    {
        try
        {
            var name = txtSearchName.Text;
            var result = _controller.SearchByName(name); // Realiza a busca no banco de dados pelo nome aproximado

            gridData.DataSource = result;
            FormatGridDataClients();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "acessar");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }

    private void SearchByCpf()
    {
        try
        {
            var cpf = txtSearchCpf.Text;
            var result = _controller.SearchByCpf(cpf); // Realiza a busca no banco de dados pelo CPF
            
            gridData.DataSource = result;
            FormatGridDataClients();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "acessar");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void ClientList()
    {
        try
        {
            gridData.DataSource = _controller.GetAllClients();
            FormatGridDataClients();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "acessar");
        }
    }

    private void SaveFormData()
    {
        try
        {
            if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução

            var cpf = txtCpf.Text;
            var email = txtEmail.Text;

            // Verifica se o CPF já está cadastrado
            if (!_controller.VerifyCpfExistence(cpf, _oldCpf))
            {
                MessageHelper.ShowRegisteredCpfMessage();
                return;
            }

            // Verifica se o email já está cadastrado
            if (_controller.VerifyEmailExistence(email))
            {
                // Se o email já estiver cadastrado, exibe uma mensagem de confirmação
                if (!MessageHelper.ShowEmailExistMessage())
                {
                    return; // Se o usuário cancelar a operação, interrompe a execução 
                }
            }
            
            var client = new Client
            {
                Code = txtCode.Text,
                Name = txtName.Text,
                Cpf = txtCpf.Text,
                OpenAmount = txtValue.Text.Replace(",", "."),
                Status = btnBlocked.Checked,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };
            
            _controller.SaveClient(client);
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
    
    private void UpdateClientData()
    {
        try
        {
            if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução
        
            var cpf = txtCpf.Text;
            var email = txtEmail.Text;
        
            // Verifica se o CPF já está cadastrado
            if (!new ClientRepository().VerifyCpfExistence(cpf, _oldCpf))
            {
                MessageHelper.ShowRegisteredCpfMessage();
                return;
            }
        
            // Verifica se o email já está cadastrado
            if (new ClientRepository().VerifyEmailExisting(email))
            {
                // Se o email já estiver cadastrado, exibe uma mensagem de confirmação
                if (!MessageHelper.ShowEmailExistMessage())
                {
                    return; // Se o usuário cancelar a operação, interrompe a execução 
                }
            }
            
            var client = new Client
            {
                Id = _id,
                Name = txtName.Text,
                Cpf = txtCpf.Text,
                OpenAmount = txtValue.Text.Replace(",", "."),
                Status = btnBlocked.Checked,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };
            
            _controller.UpdateClient(client);
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
    
    private void DeleteClient()
    {
        try
        {
            if (!MessageHelper.ConfirmDeletion()) return;
            
            _controller.DeleteClient(_id);
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
    
    private void FormatGridDataClients()
    {
        gridData.Columns[0].HeaderText = @"ID";
        gridData.Columns[1].HeaderText = @"COD.";
        gridData.Columns[2].HeaderText = @"NOME";
        gridData.Columns[3].HeaderText = @"CPF";
        gridData.Columns[4].HeaderText = @"VALOR ABERTO";
        gridData.Columns[5].HeaderText = @"STATUS";
        gridData.Columns[6].HeaderText = @"TELEFONE";
        gridData.Columns[7].HeaderText = @"EMAIL";
        gridData.Columns[8].HeaderText = @"ENDEREÇO";
        gridData.Columns[9].HeaderText = @"DATA";
        
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
        txtCpf.Enabled = enable;
        txtPhone.Enabled = enable;
        txtAddress.Enabled = enable;
        txtCode.Enabled = enable;
        txtEmail.Enabled = enable;
        txtValue.Enabled = enable;
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
        txtCode.Text = "";
        txtEmail.Text = "";
        txtValue.Text = "";
        btnBlocked.Checked = false;
        btnUnlocked.Checked = false;
    }
    
    private void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        ClientList(); // Atualiza a lista de clientes
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
    
    private bool ValidateFormData()
    {
        var validationResult = ClientValidator.ValidateClient(txtName.Text, txtCpf.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text);
        
        if (string.IsNullOrEmpty(validationResult)) return true; // Se a validação passar, retorna verdadeiro
        
        MessageHelper.ShowValidationMessage(validationResult);
        return false; // Se a validação falhar, retorna falso 
    }
}