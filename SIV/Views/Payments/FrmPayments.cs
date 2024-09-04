using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Views.Payments;

public partial class FrmPayments : Form
{
    private string _selectPaymentId;
    
    public FrmPayments()
    {
        InitializeComponent();
    }

    private void gridData_DoubleClick(object sender, EventArgs e)
    {
        if (gridData.SelectedRows.Count <= 0) return; // Verifica se há linhas selecionadas
        
        ClearFields();
        ConfigureUiControls(true);

        // Desabilita controles específicos durante a edição
        btnSave.Enabled = false;
        
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

    private void btnNew_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(true);
        txtFlag.Focus();
        
        // Desabilita controles específicos durante a edição
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
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
        DeleteFormData();
    }
    
    private void SaveFormData()
    {
        try
        {
            // if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução
            
            var paymentMethod = CreatePaymentMethodFromFormData();
            PaymentRepository.SavePayment(paymentMethod);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowSaveSuccessMessage();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro ao salvar no banco de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro inesperado: {ex.Message}");
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
            // if (!ValidateFormData()) return; // Se a validação falhar, interrompe a execução

            var paymentMethod = CreatePaymentMethodFromFormData();
            PaymentRepository.UpdatePayment(paymentMethod);
            
            UpdateUiAfterSaveOrUpdate();
            MessageHelper.ShowUpdateSuccessMessage();
        }
        catch (MySqlException ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro ao salvar no banco de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, $"Erro inesperado: {ex.Message}");
        }
        finally
        {
            ConnectionManager.CloseConnection();
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
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    private Payment CreatePaymentMethodFromFormData()
    {
        return new Payment
        {
            Id = _selectPaymentId,
            Flag = txtFlag.Text.ToUpper(),
            DaysToCredit = txtDaysToCredit.Text,
            OperatorCnpj = AddCnpjMask(txtOperatorCnpj.Text),
            Tax = txtTax.Text,
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
    
    private void LoadClient()
    {
        try
        {
            gridData.DataSource = PaymentRepository.GetAllPayment();
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
    
    private void FormatGridData()
    {
        gridData.Columns[1].HeaderText = @"BANDEIRA";
        gridData.Columns[2].HeaderText = @"DIAS P/ CRÉDITAR";
        gridData.Columns[3].HeaderText = @"CNPJ";
        gridData.Columns[4].HeaderText = @"TAX";
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
        btnEdit.Enabled = !enable;
        btnDelete.Enabled = !enable;
        btnDisabled.Enabled = !enable;
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
    
    private void UpdateUiAfterSaveOrUpdate()
    {
        ClearFields();
        LoadClient();
        ConfigureUiControls(false);
        gridData.Enabled = true;
    }
}