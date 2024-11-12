using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;

namespace SIV.Views.Tables;

public partial class FrmTablePayment : MetroFramework.Forms.MetroForm
{
    private readonly int _tableId;
    private decimal _totalValue;
    private decimal _remainingCost;
    
    public FrmTablePayment(int tableId)
    {
        InitializeComponent();
        _tableId = tableId;
        LoadPaymentMethods();
        LoadTableProducts();
        UpdateRemainingCost();
    }
    
    private void gridDataPayment_DoubleClick(object sender, EventArgs e)
    {
        var selectedPaymentMethod = gridDataPayment.SelectedRows[0];
        var paymentType = selectedPaymentMethod.Cells["PaymentType"].Value.ToString();
        txtCost.Text = _remainingCost.ToString("F2");
    }

    private void txtCost_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Payment();
            UpdateRemainingCost();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }
    
    private void LoadPaymentMethods()
    {
        try
        {
            gridDataPayment.DataSource = PaymentRepository.GetAllPayment();
            FormatGridDataPayment();
        }
        catch (Exception ex)
        {
            MessageBox.Show(@$"Erro ao carregar métodos de pagamento: {ex.Message}");
        }
    }
    
    private void LoadTableProducts()
    {
        try
        {
            gridData.DataSource = TableRepository.GetTableProducts(_tableId);
            FormatGridData();
            TotalValueLabel();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar produtos da mesa");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }

    private void FormatGridData()
    {
        gridData.Columns[0].HeaderText = @"Nome do Produto";
        gridData.Columns[1].HeaderText = @"Preço do Produto";
        gridData.Columns[2].HeaderText = @"Quantidade";

        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Cells["ProductName"].Value?.ToString()))
            {
                row.Visible = false;
            }
        }
    }
    
    private void FormatGridDataPayment()
    {
        gridDataPayment.Columns[1].HeaderText = @"BANDEIRA";
        gridDataPayment.Columns[6].HeaderText = @"FORMATO";
        gridDataPayment.Columns[0].Visible = false;
        gridDataPayment.Columns[2].Visible = false;
        gridDataPayment.Columns[3].Visible = false;
        gridDataPayment.Columns[4].Visible = false;
        gridDataPayment.Columns[5].Visible = false;
    }
    
    private void TotalValueLabel()
    {
        _totalValue = 0;

        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (row.Cells["ProductPrice"].Value != null)
            {
                _totalValue += Convert.ToDecimal(row.Cells["ProductPrice"]. Value) * Convert.ToDecimal(row.Cells["Amount"].Value);
            }
        }
        
        labelValue.Text = _totalValue.ToString("C");
    }
    
    private void UpdateRemainingCost()
    {
        try
        {
            // Obter os valores pagos da tabela partial_payments
            var paidAmounts = PaymentRepository.GetPaidAmountsForTable(_tableId);
            var totalPaid = paidAmounts.Sum();

            // Calcular o valor restante
            _remainingCost = _totalValue - totalPaid;

            // Atualizar o labelCost com o valor restante
            labelCost.Text = _remainingCost.ToString("C");
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "calcular o valor restante");
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }

    private void Payment()
    {
        var valuePaid = Convert.ToDecimal(txtCost.Text);

        if (valuePaid > _remainingCost)
        {
            MessageBox.Show(@"O valor pago é maior que o valor restante.");
            return;
        }

        if (valuePaid == _remainingCost)
        {
            TableRepository.UpdateTableState(_tableId, "Disponível", "Khaki");
            PaymentRepository.DeleteParcialPayment(_tableId);
            TableRepository.DeleteTable(_tableId);
            MessageBox.Show(@"Pagamento efetuado com sucesso.");
            // Atualiza o formulário pai
            var parentForm = Application.OpenForms.OfType<FrmTables>().FirstOrDefault();
            parentForm?.ReloadTables();
            Close();
        }

        if (valuePaid < _remainingCost)
        {
            PaymentRepository.SaveParcialPayment(_tableId, valuePaid);
            MessageBox.Show(@"Pagamento efetuado com sucesso.");
        }
    }
}