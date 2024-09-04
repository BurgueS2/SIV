using System;
using System.Windows.Forms;
using SIV.Repositories;
using SIV.teste;

namespace SIV.Views.Tables;

public partial class FrmShowTableOptions : MetroFramework.Forms.MetroForm
{
    public string TableState { get; private set; }
    private readonly int _tableId;
    private Table _table; // Instância da mesa
    
    public FrmShowTableOptions(string initialState, int tableId)
    {
        InitializeComponent();
        TableState = initialState;
        _tableId = tableId;
        InitializeForm();
    }
    
    private void InitializeForm()
    {
        _table = TableRepository.LoadTable(_tableId);
        UpdateButtonVisibility(); // Atualiza a visibilidade dos botões com base no estado da mesa
        UpdateStatusLabel(); // Atualiza o texto do status da mesa
    }
    
    private void btnOpenTable_Click(object sender, EventArgs e)
    {
        if (_table.State == "Fechada")
        {
            HandleClosedTable(); // Lida com a lógica de uma mesa fechada
        }
        else
        {
            HandleOpenTable(); // Lida com a lógica de uma mesa aberta
        }
    }
    
    private void btnCloseTable_Click(object sender, EventArgs e)
    {
        ToggleTableState(); 
        DialogResult = DialogResult.OK;
        Close();
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
    
    private void UpdateStatusLabel()
    {
        labelStatus.Text = @$"A mesa {_tableId} está {_table.State}";
    }
    
    private void UpdateButtonVisibility()
    {
        if (TableState != "Fechada") return;
        
        btnOpenTable.Text = @"Pagar";
        btnCloseTable.Text = @"Reabrir";
    }
    
    private void HandleClosedTable()
    {
        btnOpenTable.Text = @"Pagar";

        using var frmTableSales = new FrmTablePayment(_tableId);
        if (frmTableSales.ShowDialog() != DialogResult.OK) return; // Se o pagamento não for confirmado, retorne
            
        TableState = "Normal";
        DialogResult = DialogResult.OK;
        Close();
    }
    
    private void HandleOpenTable()
    {
        TableState = "Ocupada";
        DialogResult = DialogResult.OK;
        Close();

        using var frmTableSales = new FrmTableSales(_tableId);
        frmTableSales.ShowDialog();
    }

    // Alterna o estado da mesa entre aberta e fechada
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