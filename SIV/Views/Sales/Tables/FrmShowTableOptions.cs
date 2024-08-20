using System;
using System.Windows.Forms;
using SIV.Repositories;
using SIV.teste;

namespace SIV.Views.Sales.Tables;

public partial class FrmShowTableOptions : MetroFramework.Forms.MetroForm
{
    public string TableState { get; private set; }
    private int _tableId;
    private Table table;
    
    public FrmShowTableOptions(string initialState, int tableId)
    {
        InitializeComponent();
        TableState = initialState;
        _tableId = tableId;
        UpdateButtonVisibility();
        table = TableRepository.LoadTables(_tableId);
    }
    
    private void UpdateButtonVisibility()
    {
        if (TableState == "Fechada")
        {
            btnOpenTable.Text = "Pagar";
        }
    }
    
    private void btnOpenTable_Click(object sender, EventArgs e)
    {
        if (TableState == "Fechada")
        {
            table = TableRepository.LoadTables(_tableId);
            using (var frmTableSales = new FrmTableSales(_tableId, table.OpenDate, table.OpenTime, table.StayHours))
            {
                if (frmTableSales.ShowDialog() == DialogResult.OK)
                {
                    TableRepository.DeleteTable(_tableId);
                    TableState = "Normal";
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        else
        {
            TableState = "Aberta";
            DialogResult = DialogResult.OK;
            Close();
            FrmTableSales frmTableSales = new FrmTableSales(_tableId, table.OpenDate, table.OpenTime, table.StayHours);
            frmTableSales.ShowDialog();
        }
    }

    private void btnCloseTable_Click(object sender, EventArgs e)
    {
        TableState = "Fechada";
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnPartial_Click(object sender, EventArgs e)
    {
        
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}