using System;
using System.Windows.Forms;
using SIV.Repositories;

namespace SIV.Views.Sales;

public partial class FrmTableSales : MetroFramework.Forms.MetroForm
{
    private readonly int _tableId;
    
    public FrmTableSales(int tableId, DateTime? openDate, TimeSpan? openTime, TimeSpan? stayHours)
    {
        InitializeComponent();
        _tableId = tableId;
        txtSale.Text = @$"{_tableId}";
        
        // Atualiza os valores dos controles
        dateStatusBar.Text = $"{openDate?.ToShortDateString() ?? "N/A"}";
        timeStatusBar.Text = $"{openTime?.ToString(@"hh\:mm\:ss") ?? "N/A"}";
        stayHoursBar.Text = $"{stayHours?.ToString(@"hh\:mm\:ss") ?? "N/A"}";
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        var table = TableRepository.LoadTables(_tableId);
        table.OpenDate = null;
        table.OpenTime = null;
        table.StayHours = null;
        TableRepository.SaveTable(table);
        TableRepository.DeleteTable(_tableId);
        DialogResult = DialogResult.OK;
        Close();
    }
}