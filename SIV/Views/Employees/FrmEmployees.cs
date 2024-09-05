using System;
using System.Windows.Forms;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;
using SIV.Validators;

namespace SIV.Views.Employees;

/// <summary>
/// Formulário responsável por gerenciar os funcionários do sistema, permitindo a criação, edição e exclusão de funcionários.
/// </summary>
public partial class FrmEmployees : Form
{
    private string _image; // Variável para armazenar o caminho da imagem
    private bool _changedImage; // Variável para verificar se a imagem foi alterada
    private string _selectedEmployeeId;
    private string _oldCpf;
    
    public FrmEmployees()
    {
        InitializeComponent();
    }
    
    private void FrmEmployees_Load(object sender, EventArgs e)
    {
        NoPhoto();
        LoadEmployees();
        ConfigureUiControls(false);
        LoadJob();
        _changedImage = false; // Define a flag para indicar que a imagem não foi alterada
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return; // Verifica se há linhas selecionadas
        
        ConfigureUiControls(true);
        btnSave.Enabled = false;

        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _selectedEmployeeId = gridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do funcionário
        txtName.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtCpf.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        txtPhone.Text = gridData.CurrentRow?.Cells[3].Value.ToString();
        cbJob.Text = gridData.CurrentRow?.Cells[4].Value.ToString();
        txtAddress.Text = gridData.CurrentRow?.Cells[5].Value.ToString();
        _oldCpf = gridData.CurrentRow?.Cells[2].Value.ToString(); // Salva o CPF antigo para verificar se foi alterado

        // Carrega a foto do funcionário, se disponível
        if (gridData.CurrentRow?.Cells[7].Value != DBNull.Value)
        {
            var photoBytes = (byte[])gridData.CurrentRow?.Cells[7].Value;
            photo.Image = ImageHelper.ConvertByteArrayToImage(photoBytes);
        }
        else // Se não houver foto, exibe a imagem padrão
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
        gridData.Enabled = false;
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        NoPhoto();
        ConfigureUiControls(false);
        ClearFields();
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
    
    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchByName();
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
            _changedImage = true; // Define a flag para indicar que a imagem foi alterada
        }
        catch (OutOfMemoryException)
        {
            MessageHelper.ShowInsufficientMemory();
            NoPhoto();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar imagem");
        }
    }
    
    private void SaveFormData()
    {
        try
        {
            if (!ValidateFormData()) return;

            var cpf = txtCpf.Text;
            
            if (!EmployeeRepository.VerifyCpfExistence(cpf, _oldCpf))
            {
                MessageHelper.ShowRegisteredCpfMessage();
                return; 
            }
            
            var employee = CreateEmployeeFromFormData();
            EmployeeRepository.SaveEmployee(employee);
            
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
            
            var cpf = txtCpf.Text;
            
            if (!EmployeeRepository.VerifyCpfExistence(cpf, _oldCpf))
            {
                MessageHelper.ShowRegisteredCpfMessage();
                return;
            }
            
            var employee = CreateEmployeeFromFormData();
            EmployeeRepository.UpdateEmployee(employee, _changedImage);
            
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
            
            EmployeeRepository.DeleteEmployee(_selectedEmployeeId);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
    }
    
    private Employee CreateEmployeeFromFormData()
    {
        return new Employee
        {
            Id = _selectedEmployeeId,
            Name = txtName.Text.ToUpper(),
            Cpf = AddCpfMask(txtCpf.Text),
            Phone = AddPhoneMask(txtPhone.Text),
            Job = cbJob.Text.ToUpper(),
            Address = txtAddress.Text.ToUpper(),
            Photo = _changedImage ? ImageHelper.ConvertImageToByteArray(photo.Image) : null
        };
    }

    private void SearchByName()
    {
        try
        {
            var name = txtSearch.Text.ToUpper();

            gridData.DataSource = EmployeeRepository.SearchByName(name);
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "pesquisar funcionário");
        }
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
    
    private void LoadEmployees()
    {
        try
        {
            gridData.DataSource = EmployeeRepository.GetAllEmployees();
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar funcionários");
        }
    }
    
    private void LoadJob()
    {
        try
        {
            cbJob.DataSource = JobRepository.GetAllJobs();
            cbJob.DisplayMember = "Name";
            cbJob.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "carregar cargos");
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns[0].HeaderText = @"ID";
        gridData.Columns[1].HeaderText = @"NOME";
        gridData.Columns[2].HeaderText = @"CPF";
        gridData.Columns[3].HeaderText = @"TELEFONE";
        gridData.Columns[4].HeaderText = @"CARGO";
        gridData.Columns[5].HeaderText = @"ENDEREÇO";
        gridData.Columns[6].HeaderText = @"DATA";
        gridData.Columns[7].HeaderText = @"FOTO";
        gridData.Columns[0].Visible = false;
        gridData.Columns[7].Visible = false;
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
        gridData.Enabled = !enable;
    }
    
    private void ClearFields()
    {
        txtName.Text = "";
        txtCpf.Text = "";
        txtPhone.Text = "";
        cbJob.Text = "";
        txtAddress.Text = "";
    }
    
    private void NoPhoto()
    {
        photo.Image = Properties.Resources.sem_foto; // Imagem padrão
        _image = "Resources/sem_foto.png"; // Caminho da imagem padrão
    }
    
    private bool ValidateFormData()
    {
        var validationResult = EmployeeValidator.ValidateEmployee(txtName.Text, txtCpf.Text, txtPhone.Text, cbJob.Text, txtAddress.Text);

        if (string.IsNullOrEmpty(validationResult)) return true;
        
        MessageHelper.ShowValidationMessage(validationResult);
        return false;
    }
    
    private void UpdateUiAfterSaveOrUpdate()
    {
        NoPhoto();
        ClearFields();
        LoadEmployees();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
}