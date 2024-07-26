using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Repositories;
using SIV.Validators;

namespace SIV.Views.Clients;

/// <summary>
/// Classe responsável por gerenciar a interface gráfica do formulário de clientes.
/// </summary>
public partial class FrmClients : MetroFramework.Forms.MetroForm
{
    private string _id;
    private string _oldCpf;
    
    /// <summary>
    /// Construtor da classe, inicializa os componentes do formulário.
    /// </summary>
    public FrmClients()
    {
        InitializeComponent();
    }
    
    private void FrmClients_Load(object sender, EventArgs e)
    {
        ClientList();
        ConfigureUiControls(false);
        EnableSearchControls(true);
        
        GridDataClient.CellFormatting += GridDataClient_CellFormatting; // Adiciona um evento de formatação de célula
    }
    
    private void GridDataClient_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Verifica se a coluna é a coluna de status
        if (GridDataClient.Columns[e.ColumnIndex].Name != "status") return; // Se não for, interrompe a execução
        
        if (e.Value == null) return;
        
        // Converte o valor para "Bloqueado" ou "Desbloqueado"
        e.Value = e.Value.ToString() == "1" || e.Value.ToString().ToLower() == "true" ? "Bloqueado" : "Desbloqueado";
        e.FormattingApplied = true; // Indica que a formatação foi aplicada
    }
    
    private void GridDataClient_CellDoubleClickFormatting(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex <= -1) return; // Se o índice da linha for menor ou igual a -1, interrompe a execução
        
        
        ClearFields();
        ConfigureUiControls(true);
        EnableSearchControls(false);
        
        // Desabilita controles específicos durante a edição
        btnSave.Enabled = false;
        txtCode.Enabled = false;
        

        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _id = GridDataClient.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do funcionário
        txtCode.Text = GridDataClient.CurrentRow?.Cells[1].Value.ToString();
        txtName.Text = GridDataClient.CurrentRow?.Cells[2].Value.ToString();
        txtCpf.Text = GridDataClient.CurrentRow?.Cells[3].Value.ToString();
        _oldCpf = GridDataClient.CurrentRow?.Cells[3].Value.ToString(); // Salva o CPF antigo para verificar se foi alterado
        txtValue.Text = GridDataClient.CurrentRow?.Cells[4].Value.ToString();
        
        // Verifica se o status do funcionário é bloqueado
        var statusValue = GridDataClient.CurrentRow?.Cells[5].Value.ToString().ToLower(); 
        bool isBlocked = statusValue == "1"; // Se o valor for 1, o funcionário está bloqueado se não, está desbloqueado
        btnBlocked.Checked = isBlocked; 
        btnUnlocked.Checked = !isBlocked;
        
        // Preenche os campos restantes
        txtPhone.Text = GridDataClient.CurrentRow?.Cells[6].Value.ToString();
        txtEmail.Text = GridDataClient.CurrentRow?.Cells[7].Value.ToString();
        txtAddress.Text = GridDataClient.CurrentRow?.Cells[8].Value.ToString();
    }
    
    private void btnSearchName_Click(object sender, EventArgs e)
    {
        SearchByName();
    }

    private void btnSearchCpf_Click(object sender, EventArgs e)
    {
        SearchByCpf(); 
    }
    
    private void btnNew_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(true);
        EnableSearchControls(false);
        txtName.Focus();
        
        // Desabilita controles específicos durante a edição
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        GridDataClient.Enabled = false;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ClearFields();
        ConfigureUiControls(false);
        EnableSearchControls(true);
        GridDataClient.Enabled = true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução

        var cpf = txtCpf.Text;
        var email = txtEmail.Text;

        // Verifica se o CPF já está cadastrado
        if (!new ClientRepository().VerifyCpfExistence(cpf, _oldCpf))
        {
            MessageHelper.ShowRegisteredCpfMessage();
            return; // Se o CPF já estiver cadastrado, interrompe a execução
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
        
        SaveFormData();
        EnableSearchControls(true);
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução
        
        var cpf = txtCpf.Text;
        var email = txtEmail.Text;
        
        // Verifica se o CPF já está cadastrado
        if (!new ClientRepository().VerifyCpfExistence(cpf, _oldCpf))
        {
            MessageHelper.ShowRegisteredCpfMessage();
            return; // Se o CPF já estiver cadastrado, interrompe a execução
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
        
        UpdateClientData();
        EnableSearchControls(true);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        // Verifica se o usuário realmente deseja excluir o cliente
        if (!MessageHelper.ConfirmDeletion())
        {
            DeleteClient();
        }
    }
    
    private void SearchByName()
    {
        try
        {
            var name = txtSearchName.Text;
            var repository = new ClientRepository();
            var result = repository.SearchByName(name); // Realiza a busca no banco de dados pelo nome aproximado 
            GridDataClient.DataSource = result; // Preenche o DataGridView com os dados retornados
            FormatGridDataClients();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex); // Registra a exceção no arquivo de log
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
            var repository = new ClientRepository();
            var result = repository.SearchByCpf(cpf); // Realiza a busca no banco de dados pelo CPF 
            GridDataClient.DataSource = result;
            FormatGridDataClients();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex); // Registra a exceção no arquivo de log
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
            var repository = new ClientRepository();
            
            GridDataClient.DataSource = repository.GetAllClients(); // Preenche o DataGridView com os dados do banco de dados
            FormatGridDataClients();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex); // Registra a exceção no arquivo de log
            MessageHelper.ShowErrorMessage(ex, "acessar");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }

    private void SaveFormData()
    {
        try
        {
            var repository = new ClientRepository();
            var status = btnBlocked.Checked; // Verifica se o funcionário está bloqueado
            
            // Substitui a vírgula por ponto para salvar o valor corretamente
            var openAmount = txtValue.Text.Replace(",", ".");
            
            repository.SaveClients(txtCode.Text, txtName.Text, txtCpf.Text, openAmount, status, txtPhone.Text, txtEmail.Text, txtAddress.Text);
            
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
    
    private void UpdateClientData()
    {
        try
        {
            var repository = new ClientRepository();
            var status = btnBlocked.Checked; // Verifica se o funcionário está bloqueado 
            var openAmount = txtValue.Text.Replace(",", ".");
            
            repository.UpdateClients(_id, txtName.Text, txtCpf.Text, openAmount, status, txtPhone.Text, txtEmail.Text, txtAddress.Text);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowUpdateSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex); // Registra a exceção no arquivo de log
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
            var repository = new ClientRepository();
            repository.DeleteClients(_id);

            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex); // Registra a exceção no arquivo de log
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private void FormatGridDataClients()
    {
        GridDataClient.Columns[0].HeaderText = @"ID";
        GridDataClient.Columns[1].HeaderText = @"COD.";
        GridDataClient.Columns[2].HeaderText = @"NOME";
        GridDataClient.Columns[3].HeaderText = @"CPF";
        GridDataClient.Columns[4].HeaderText = @"VALOR ABERTO";
        GridDataClient.Columns[5].HeaderText = @"STATUS";
        GridDataClient.Columns[6].HeaderText = @"TELEFONE";
        GridDataClient.Columns[7].HeaderText = @"EMAIL";
        GridDataClient.Columns[8].HeaderText = @"ENDEREÇO";
        GridDataClient.Columns[9].HeaderText = @"DATA";

        GridDataClient.Columns[0].Width = 50;
        GridDataClient.Columns[0].Visible = false;
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
        GridDataClient.Enabled = !enable;
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
        GridDataClient.Enabled = true;
    }
    
    private bool ValidateFormData()
    {
        var validationResult = ClientValidator.ValidateClient(txtName.Text, txtCpf.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text);
        
        if (string.IsNullOrEmpty(validationResult)) return true; // Se a validação passar, retorna verdadeiro
        
        MessageHelper.ShowValidationMessage(validationResult);
        
        return false; // Se a validação falhar, retorna falso 
    }
}