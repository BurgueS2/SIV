using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Registers.Jobs;

namespace SIV.Registers.Employees;

public partial class FrmEmployees : MetroFramework.Forms.MetroForm
{ 
    string _image; // Variável para armazenar o caminho da imagem
    string _imageChangedFlag; // Variável para verificar se a imagem foi alterada
    string _id; // Variável para armazenar o ID do funcionário
    string _oldCpf; // Variável para armazenar o CPF antigo
    
    public FrmEmployees()
    {
        InitializeComponent();
    }
    
    private void FrmEmployees_Load(object sender, EventArgs e)
    {
        NoPhoto(); // Chama o método 'NoPhoto' que exibe a imagem padrão 
        EmployeeList(); // Chama o método 'EmployeeList' que exibe a lista de funcionários
        ConfigureUiControls(false); // Chama o método 'ConfigureUiControls' para desabilitar os campos do formulário
        ListJob();
        _imageChangedFlag = "not"; // Variável para verificar se a imagem foi alterada
    }
    
    private void GridData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex <= -1) return; // Se o índice da linha for menor ou igual a -1, interrompe a execução
        
        ConfigureUiControls(true); // Habilita os campos do formulário
        btnSave.Enabled = false;

        // Preenche os campos do formulário com os dados da linha selecionada
        _id = GridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do funcionário
        txtName.Text = GridData.CurrentRow?.Cells[1].Value.ToString();
        txtCpf.Text = GridData.CurrentRow?.Cells[2].Value.ToString();
        _oldCpf = GridData.CurrentRow?.Cells[2].Value.ToString(); // Salva o CPF antigo para verificar se foi alterado
        txtPhone.Text = GridData.CurrentRow?.Cells[3].Value.ToString();
        cbJob.Text = GridData.CurrentRow?.Cells[4].Value.ToString();
        txtAddress.Text = GridData.CurrentRow?.Cells[5].Value.ToString();

        if (GridData.CurrentRow?.Cells[7].Value != DBNull.Value)
        {
            var img = (byte[])GridData.Rows[e.RowIndex].Cells[7].Value; // Cria um array de bytes e joga o valor da célula 7 do DataGridView
            var ms = new MemoryStream(img);
            
            photo.Image = Image.FromStream(ms); // Exibe a imagem no PictureBox
        }
        else // Se a célula 7 for nula, exibe a imagem padrão
        {
            photo.Image = Properties.Resources.sem_foto;
        }
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(true);
        txtName.Focus();
        
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        GridData.Enabled = false;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(false);
        ClearFields();
        GridData.Enabled = true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução

        var cpf = txtCpf.Text;

        // Verifica se o CPF já está cadastrado
        if (!new EmployeeRepository().VerifyCpfExistence(cpf, _oldCpf))
        {
            MessageBox.Show(this, @"CPF já cadastrado", @"ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        SaveFormData(); // Chama o método 'SaveFormData' para salvar os dados do formulário
        UpdateUiAfterSaveOrUpdate();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (!ValidateFormData()) return;
        
        var cpf = txtCpf.Text;
        
        // Verifica se o CPF já está cadastrado
        if (!new EmployeeRepository().VerifyCpfExistence(cpf, _oldCpf))
        {
            MessageBox.Show(this, @"CPF já cadastrado", @"ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        UpdateEmployeeData();
        UpdateUiAfterSaveOrUpdate();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var questioning = MessageBox.Show(this, @"Deseja excluir o registro?", @"EXCLUIR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (questioning == DialogResult.Yes)
        {
            try
            {
                var repository = new EmployeeRepository();
                repository.DeleteEmployee(_id);
                MessageBox.Show(this, @"Registro excluído com sucesso!", @"REGISTRO EXCLUÍDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Erro ao excluir no banco de dados:");
            }
            finally
            {
                ConnectionManager.CloseConnection();
                UpdateUiAfterSaveOrUpdate(); // Atualiza a interface do usuário após excluir
            }
        }
    }

    private void btnPhoto_Click(object sender, EventArgs e)
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = @"picture files(*.jpg;*.png;*.jpeg) | *.jpg;*.png;*.jpeg"; // Filtro de arquivos de imagem

        if (dialog.ShowDialog() != DialogResult.OK) return; // Se o usuário não selecionar uma imagem, interrompe a execução
        _image = dialog.FileName;
        photo.ImageLocation = _image; // Exibe a imagem no PictureBox
        _imageChangedFlag = "yes"; // Variável para verificar se a imagem foi alterada
    }
    
    // Método para exibir a lista de funcionários no DataGridView.
    private void EmployeeList()
    {
        try
        {
            var repository = new EmployeeRepository(); // Instancia a classe EmployeeRepository
            GridData.DataSource = repository.GetAllEmployees(); // Preenche o DataGridView com os dados do banco de dados
            FormatGridData();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(this,$@"Erro ao acessar o banco de dados: {ex.Message}", @"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var jobRepository = new JobRepository();
            var jobs = jobRepository.GetAllJobs();
            cbJob.DataSource = jobs;
            cbJob.DisplayMember = "name";
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $@"Erro ao listar cargos: {ex.Message}", @"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    // Método para tratar exceções.
    private void HandleException(Exception ex, string customMessage)
    {
        var message = string.IsNullOrWhiteSpace(customMessage) ? "Um erro inesperado ocorreu." : customMessage;
        message += $"\nDetalhe do Erro: {ex.Message}"; // Concatena a mensagem de erro com a mensagem personalizada
        
        MessageBox.Show(this, message, @"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    // Método para formatar os dados do DataGridView.
    private void FormatGridData()
    {
        GridData.Columns[0].HeaderText = @"ID";
        GridData.Columns[1].HeaderText = @"NOME";
        GridData.Columns[2].HeaderText = @"CPF";
        GridData.Columns[3].HeaderText = @"TELEFONE";
        GridData.Columns[4].HeaderText = @"CARGO";
        GridData.Columns[5].HeaderText = @"ENDEREÇO";
        GridData.Columns[6].HeaderText = @"DATA";
        GridData.Columns[7].HeaderText = @"FOTO";

        GridData.Columns[0].Visible = false;
        GridData.Columns[7].Visible = false;
    }
    
    // Método para configurar os controles da interface do usuário.
    private void ConfigureUiControls(bool enable)
    {
        btnNew.Enabled = !enable;
        btnSave.Enabled = enable;
        btnEdit.Enabled = enable;
        btnDelete.Enabled = enable;
        btnCancel.Enabled = enable;
        btnPhoto.Enabled = enable;
        txtName.Enabled = enable;
        txtCpf.Enabled = enable;
        txtPhone.Enabled = enable;
        cbJob.Enabled = enable;
        txtAddress.Enabled = enable;
        GridData.Enabled = !enable;
    }
    
    // Método para limpar os campos do formulário.
    private void ClearFields()
    {
        txtName.Text = "";
        txtCpf.Text = "";
        txtPhone.Text = "";
        cbJob.Text = "";
        txtAddress.Text = "";
        NoPhoto(); // Reutiliza o método existente para definir a foto padrão
    }
    
    // Método para converter a imagem em bytes.
    private byte[] Picture()
    {
        if (_image == "") // A string '_image', nunca será vazia, pois sempre terá o caminho da imagem
        {
            return null; // Retorna nulo se a imagem não for selecionada
        }

        try
        {
            using (var fs = new FileStream(_image, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs)) 
            {
                var imageBytes = br.ReadBytes((int)fs.Length); // Lê os bytes da imagem
                return imageBytes;
            }
        }
        catch (IOException ex)
        {
            MessageBox.Show(this, $@"Erro ao ler o arquivo da imagem: {ex.Message}", @"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null; // Retorna nulo se ocorrer um erro ao ler a imagem
        }
    }
    
    // Método para exibir a imagem padrão.
    private void NoPhoto()
    {
        photo.Image = Properties.Resources.sem_foto; // Imagem padrão
        _image = "Resources/sem_foto.png"; // Caminho da imagem padrão
    }
    
    // Método para validar os dados do formulário.
    private bool ValidateFormData()
    {
        var validationResult = EmployeeValidator.ValidateEmployee(txtName.Text, txtCpf.Text, txtPhone.Text, cbJob.Text, txtAddress.Text);

        if (string.IsNullOrEmpty(validationResult)) return true; // Se a validação passar, retorna verdadeiro
        MessageBox.Show(this, validationResult, @"ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false; // Se a validação falhar, retorna falso 
    }
    
    // Método para salvar os dados do funcionário.
    private void SaveFormData()
    {
        try
        {
            var repository = new EmployeeRepository();
            var photoBytes = Picture(); // Assume que este método retorna a foto em formato byte[]
            repository.SaveEmployee(txtName.Text, txtCpf.Text, txtPhone.Text, cbJob.Text, txtAddress.Text, photoBytes);
            MessageBox.Show(this, @"Registro salvo com sucesso!", @"CADASTRO SALVO", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            HandleException(ex, "Erro ao salvar no banco de dados:");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    // Método para atualizar os dados do funcionário.
    private void UpdateEmployeeData()
    {
        try
        {
            var repository = new EmployeeRepository();
            var photoBytes = Picture();
            var imageChanged = _imageChangedFlag == "yes";
            repository.UpdateEmployee(_id, txtName.Text, txtCpf.Text, txtPhone.Text, cbJob.Text, txtAddress.Text, photoBytes, imageChanged);
            MessageBox.Show(this, @"Registro atualizado com sucesso!", @"CADASTRO ATUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            HandleException(ex, "Erro ao atualizar no banco de dados:");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    // Método para atualizar a interface do usuário após salvar ou atualizar.
    private void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        EmployeeList(); // Atualiza a lista de funcionários
        ConfigureUiControls(false);
        GridData.Enabled = true;
    }
    
    
}