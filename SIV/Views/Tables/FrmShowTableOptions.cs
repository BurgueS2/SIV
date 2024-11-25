using System;
using System.Windows.Forms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Views.Tables;

public partial class FrmShowTableOptions : MetroFramework.Forms.MetroForm
{
    public string TableState { get; private set; } // Estado da mesa. Pode ser "Fechada", "Ocupada" ou "Disponível"
    private readonly int _tableId;
    private Table _table; // Instância da mesa
    
    public FrmShowTableOptions(string initialState, int tableId)
    {
        InitializeComponent();
        TableState = initialState; // Define o estado inicial da mesa.
        _tableId = tableId; // Define o ID da mesa.
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        try
        {
            _table = TableRepository.LoadTable(_tableId); // Carrega a mesa do banco de dados.
            UpdateButtonVisibility(); // Atualiza a visibilidade dos botões com base no estado da mesa.
            UpdateStatusLabel(); // Atualiza o texto do status da mesa.
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "inicializar a tela de opções da mesa");
        }
    }
    
    private void btnOpenTable_Click(object sender, EventArgs e)
    {
        if (_table.State == "Fechada")
        {
            HandleClosedTable(); // Lida com a lógica de uma mesa fechada.
        }
        else
        {
            HandleOpenTable(); // Lida com a lógica de uma mesa aberta.
        }
    }
    
    private void btnCloseTable_Click(object sender, EventArgs e)
    {
        ToggleTableState(); // Alterna o estado da mesa entre aberta e fechada.
        DialogResult = DialogResult.OK;
        Close();
    }
    
    private void btnCancel_Click(object sender, EventArgs e) => Close();
    
    private void UpdateStatusLabel()
    {
        labelStatus.Text = @$"A mesa {_tableId} está {_table.State}";
    }
    
    private void UpdateButtonVisibility()
    {
        if (TableState != "Fechada") return;
        
        // Se a mesa estiver fechada, o botão de "Pagar" deve ser exibido.
        btnOpenTable.Text = @"Pagar";
        btnCloseTable.Text = @"Reabrir";
    }
    
    private void HandleClosedTable()
    {
        try
        {
            if (CashRegisterRepository.IsCashRegisterAlreadyOpen(int.Parse(SessionManager.CurrentUser.Id))) // Verifica se o caixa está aberto
            {
                using var frmTableSales = new FrmTablePayment(_tableId);
                if (frmTableSales.ShowDialog() != DialogResult.OK) return; // Se o pagamento não for confirmado, retorne a execução
                
                TableState = "Disponível";
                DialogResult = DialogResult.OK;
                frmTableSales.ShowDialog();
                Close();
            }
            else
            {
                MessageHelper.BoxIsNotOpenMessage();
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "abrir mesa");
        }
    }
    
    private void HandleOpenTable()
    {
        TableState = "Ocupada";
        DialogResult = DialogResult.OK;
        Close();

        using var frmTableSales = new FrmTableSales(_tableId);
        frmTableSales.ShowDialog();
    }

    /// <summary>
    /// Alterna o estado da mesa entre aberta e fechada.
    /// </summary>
    private void ToggleTableState()
    {
        if (_table.State == "Fechada")
        {
            TableState = "Ocupada";
            btnCloseTable.Text = @"Reabrir";
        }
        else
        {
            TableState = "Fechada";
            btnCloseTable.Text = @"Fechar";
        }
    }
}