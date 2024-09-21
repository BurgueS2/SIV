using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;
using SIV.Validators;

namespace SIV.Views.Payments;

public partial class FrmPayments : Form
{
    private string _selectPaymentId;
    
    public FrmPayments() => InitializeComponent();
    
    private void FrmPayments_Load(object sender, EventArgs e) => InitializeForm();
    
    private void btnNew_Click(object sender, EventArgs e) => PrepareForNewEntry();
    
    private void btnCancel_Click(object sender, EventArgs e) => ResetForm();
    
    private void btnSave_Click(object sender, EventArgs e) => SaveFormData();
    
    private void btnEdit_Click(object sender, EventArgs e) => UpdateFormData();
    
    private void btnDelete_Click(object sender, EventArgs e) => DeleteFormData();
    
    private void btnSearch_Click(object sender, EventArgs e) => SearchByName();

    private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) SearchByName();
    }
    
    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return;
        
        ClearFields();
        ConfigureUiControls(true);
        PopulateFormFields();
        btnSave.Enabled = false; // Desabilita o botão de salvar, pois o usuário não está criando um novo registro
    }
    
    private async void InitializeForm()
    {
        ConfigureUiControls(false);
        await LoadPaymentAsync();
    }
    
    private void SaveFormData()
    {
        try
        {
            if (!ValidateFormData()) return;
            
            var paymentMethod = CreatePaymentMethodFromFormData();
            PaymentRepository.SavePayment(paymentMethod);
            
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

            var paymentMethod = CreatePaymentMethodFromFormData();
            PaymentRepository.UpdatePayment(paymentMethod);
            
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
            
            PaymentRepository.DeletePayment(_selectPaymentId);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowDeleteSuccessMessage();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "excluir");
        }
    }
    
    private Payment CreatePaymentMethodFromFormData()
    {
        return new Payment
        {
            Id = _selectPaymentId,
            Flag = txtFlag.Text.ToUpper(),
            DaysToCredit = string.IsNullOrWhiteSpace(txtDaysToCredit.Text) ? "0" : txtDaysToCredit.Text,
            OperatorCnpj = string.IsNullOrWhiteSpace(txtOperatorCnpj.Text) ? "N/A" : AddCnpjMask(txtOperatorCnpj.Text),
            Tax = string.IsNullOrWhiteSpace(txtTax.Text) ? "0" : txtTax.Text,
            Status = btnDebit.Checked ? "INATIVO" : "ATIVO",
            Type = btnCredit.Checked ? "CREDITO" : btnDebit.Checked ? "DEBITO" : "VOUCHER" // Verifica qual RadioButton está selecionado
        };
    }
    
    private static string AddCnpjMask(string cnpj)
    {
        if (cnpj.Length == 14)
        {
            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        return cnpj;
    }
    
    private async Task LoadPaymentAsync()
    {
        try
        {
            gridData.DataSource = await Task.Run(PaymentRepository.GetAllPayment);
            FormatGridData();
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
    
    private void SearchByName()
    {
        try
        {
            gridData.DataSource = PaymentRepository.SearchByPaymentName(txtSearch.Text.ToUpper());
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "pesquisar o método de pagamento");
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns[1].HeaderText = @"BANDEIRA";
        gridData.Columns[2].HeaderText = @"DIAS P/ CRÉDITAR";
        gridData.Columns[3].HeaderText = @"CNPJ";
        gridData.Columns[4].HeaderText = @"TAXA";
        gridData.Columns[5].HeaderText = @"STATUS";
        gridData.Columns[6].HeaderText = @"FORMATO";
        gridData.Columns[0].Visible = false;
    }
    
    private void ConfigureUiControls(bool enable)
    {
        txtFlag.Enabled = enable;
        txtTax.Enabled = enable;
        txtOperatorCnpj.Enabled = enable;
        txtDaysToCredit.Enabled = enable;
        btnCredit.Enabled = enable;
        btnDebit.Enabled = enable;
        btnVoucher.Enabled = enable;
        btnNew.Enabled = !enable;
        btnSave.Enabled = enable;
        btnCancel.Enabled = enable;
        btnEdit.Enabled = enable;
        btnDelete.Enabled = enable;
        btnDisabled.Enabled = enable;
        gridData.Enabled = !enable;
    }
    
    private void ClearFields()
    {
        txtFlag.Text = "";
        txtTax.Text = "";
        txtOperatorCnpj.Text = "";
        txtDaysToCredit.Text = "";
        btnDisabled.Checked = false;
        btnCredit.Checked = false;
        btnDebit.Checked = false;
        btnVoucher.Checked = false;
    }

    private void ResetForm()
    {
        ClearFields();
        ConfigureUiControls(false);
    }
    
    private async void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        await LoadPaymentAsync();
        ConfigureUiControls(false);
    }

    private void PrepareForNewEntry()
    {
        ConfigureUiControls(true);
        txtFlag.Focus();
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
    }

    private void PopulateFormFields()
    {
        // Obtém os valores das células da linha selecionada e preenche os campos do formulário
        _selectPaymentId = gridData.CurrentRow?.Cells[0].Value.ToString(); // Armazena o ID do cliente
        txtFlag.Text = gridData.CurrentRow?.Cells[1].Value.ToString();
        txtDaysToCredit.Text = gridData.CurrentRow?.Cells[2].Value.ToString();
        txtOperatorCnpj.Text = gridData.CurrentRow?.Cells[3].Value.ToString();
        txtTax.Text = gridData.CurrentRow?.Cells[4].Value.ToString();

        // Verifica se o status é bloqueado
        var statusValue = gridData.CurrentRow?.Cells[5].Value.ToString().ToUpper();
        btnDisabled.Checked = statusValue == "ATIVO";
        btnDisabled.Checked = statusValue == "INATIVO.";

        // Preenche os campos restantes
        txtFlag.Text = gridData.CurrentRow?.Cells[6].Value.ToString();
    }
    
    private bool ValidateFormData()
    {
        var validationResult = PaymentValidator.ValidatePayment(txtFlag.Text, txtOperatorCnpj.Text);

        if (string.IsNullOrEmpty(validationResult)) return true;
        
        MessageHelper.ShowValidationMessage(validationResult);
        return false;
    }
}