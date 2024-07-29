using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Controllers;
using SIV.Core;
using SIV.Models;
using SIV.Repositories;
using SIV.Validators;

namespace SIV.Views.Employees;

/// <summary>
/// Classe responsável pela gestão de funcionários, permitindo operações como listar, adicionar, editar e excluir funcionários.
/// </summary>
public partial class FrmEmployees : MetroFramework.Forms.MetroForm
{
    private readonly EmployeeController _controller; // Instância da classe EmployeeController
    private string _image; // Variável para armazenar o caminho da imagem
    private string _imageChangedFlag; // Variável para verificar se a imagem foi alterada
    private string _id; // Armazena o ID do funcionário
    private string _oldCpf; // CPF antigo do funcionário, usado para verificações durante a atualização.
    
    /// <summary>
    /// Construtor da classe, inicializa os componentes do formulário.
    /// </summary>
    public FrmEmployees()
    {
        InitializeComponent();
        _controller = new EmployeeController();
        //LoadEmployees();
    }
    
    private void LoadEmployees()
    {
        try
        {
            GridData.DataSource = _controller.GetAllEmployees();
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar funcionários");
        }
    }
    
    private void FrmEmployees_Load(object sender, EventArgs e)
    {
        NoPhoto();
        LoadEmployees();
        ConfigureUiControls(false);
        ListJob();
        _imageChangedFlag = "not"; // Variável para verificar se a imagem foi alterada
    }
    
    private void GridData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex <= -1) return; // Se o índice da linha for menor ou igual a -1, interrompe a execução
        
        ConfigureUiControls(true);
        btnSave.Enabled = false;

        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _id = GridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do funcionário
        txtName.Text = GridData.CurrentRow?.Cells[1].Value.ToString();
        txtCpf.Text = GridData.CurrentRow?.Cells[2].Value.ToString();
        txtPhone.Text = GridData.CurrentRow?.Cells[3].Value.ToString();
        cbJob.Text = GridData.CurrentRow?.Cells[4].Value.ToString();
        txtAddress.Text = GridData.CurrentRow?.Cells[5].Value.ToString();
        _oldCpf = GridData.CurrentRow?.Cells[2].Value.ToString(); // Salva o CPF antigo para verificar se foi alterado

        // Carrega a foto do funcionário, se disponível
        if (GridData.CurrentRow?.Cells[7].Value != DBNull.Value)
        {
            var photoBytes = (byte[])GridData.CurrentRow?.Cells[7].Value;
            photo.Image = ImageHelper.ConvertByteArrayToImage(photoBytes);
        }
        else
        {
            NoPhoto();
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
        if (!_controller.VerifyCpfExistence(cpf, _oldCpf))
        {
            MessageHelper.ShowRegisteredCpfMessage();
            return; 
        }
        
        SaveFormData();
    }
    
    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (!ValidateFormData()) return;
        
        var cpf = txtCpf.Text;
        
        // Verifica se o CPF já está cadastrado
        if (!_controller.VerifyCpfExistence(cpf, _oldCpf))
        {
            MessageHelper.ShowRegisteredCpfMessage();
            return;
        }

        UpdateEmployeeData();
    }
    
    private void btnDelete_Click(object sender, EventArgs e)
    {
        // Exibe uma mensagem de confirmação antes de excluir o funcionário
        if (!MessageHelper.ConfirmDeletion()) return;

        DeleteEmployee();
    }
    
    private void btnPhoto_Click(object sender, EventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = @"picture files(*.jpg;*.png;*.jpeg) | *.jpg;*.png;*.jpeg" // Filtro de arquivos de imagem
        };

        if (dialog.ShowDialog() != DialogResult.OK) return;
        
        try
        {
            _image = dialog.FileName;
            photo.Image = ImageHelper.LoadImageFromFile(_image); // Carrega a imagem selecionada no PictureBox
            _imageChangedFlag = "yes"; // Define a flag para indicar que a imagem foi alterada
        }
        catch (OutOfMemoryException)
        {
            MessageHelper.ShowInsufficientMemory();
            NoPhoto();
        }
    }
    
    private void ListJob()
    {
        try
        {
            var jobRepository = new JobRepository();
            var jobs = jobRepository.GetAllJobs(); // Obtém a lista de cargos do banco de dados
            cbJob.DataSource = jobs;
            cbJob.DisplayMember = "name";
        }
        catch (Exception ex)
        {
            Logger.LogException(ex); // Registra a exceção no arquivo de log
            MessageHelper.ShowErrorMessage(ex, "listar os cargos");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
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
    
    private void ClearFields()
    {
        txtName.Text = "";
        txtCpf.Text = "";
        txtPhone.Text = "";
        cbJob.Text = "";
        txtAddress.Text = "";
        _image = "";
        _imageChangedFlag = "0";
        _id = "";
        _oldCpf = "";
    }
    
    private byte[] Picture()
    {
        if (string.IsNullOrEmpty(_image) || _image.Equals("Resources/sem_foto.png")) return null; // Se a imagem for nula ou a padrão, retorna nulo

        try
        {
            var image = ImageHelper.LoadImageFromFile(_image);
            return ImageHelper.ConvertImageToByteArray(image);
        }
        catch (OutOfMemoryException)
        {
            MessageHelper.ShowInsufficientMemory();
            return null; // Retorna nulo para evitar mais processamento
        }
    }
    
    private void NoPhoto()
    {
        photo.Image = Properties.Resources.sem_foto; // Imagem padrão
        _image = "Resources/sem_foto.png"; // Caminho da imagem padrão
    }
    
    private bool ValidateFormData()
    {
        var validationResult = EmployeeValidator.ValidateEmployee(txtName.Text, txtCpf.Text, txtPhone.Text, cbJob.Text, txtAddress.Text);

        if (string.IsNullOrEmpty(validationResult)) return true; // Se a validação passar, retorna verdadeiro
        
        MessageHelper.ShowValidationMessage(validationResult);
        return false; // Se a validação falhar, retorna falso 
    }
    
    private void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        LoadEmployees(); // Atualiza a lista de funcionários
        ConfigureUiControls(false);
        GridData.Enabled = true;
    }
    
    private void SaveFormData()
    {
        try
        {
            var employee = new Employee
            {
                Id = _id,
                Name = txtName.Text,
                Cpf = txtCpf.Text,
                Phone = txtPhone.Text,
                Job = cbJob.Text,
                Address = txtAddress.Text,
                Photo = _imageChangedFlag == "1" ? ImageHelper.ConvertImageToByteArray(ImageHelper.LoadImageFromFile(_image)) : null
            };
        
            _controller.SaveEmployee(employee);
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
    
    private void UpdateEmployeeData()
    {
        try
        {
            var employee = new Employee
            {
                Id = _id,
                Name = txtName.Text,
                Cpf = txtCpf.Text,
                Phone = txtPhone.Text,
                Job = cbJob.Text,
                Address = txtAddress.Text,
                Photo = _imageChangedFlag == "1" ? ImageHelper.ConvertImageToByteArray(ImageHelper.LoadImageFromFile(_image)) : null
            };

            _controller.UpdateEmployee(employee);
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
    
    private void DeleteEmployee()
    {
        try
        {
            _controller.DeleteEmployee(_id);
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
}