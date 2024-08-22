using System;
using System.Windows.Forms;
using SIV.Repositories;
using SIV.Views.Sales.Tables;

namespace SIV.Views.Sales;

public partial class FrmSalas : Form
{
    public FrmSalas()
    {
        InitializeComponent();
        txtSale.TextChanged += TxtSale_TextChanged;
    }

    private void TxtSale_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(txtSale.Text, out int tableId))
        {
            var table = TableRepository.LoadTable(tableId);
            
            if (table != null)
            {
                // Exibir informações da mesa
                FrmShowTableOptions frmShowTableOptions = new FrmShowTableOptions(table.State, table.Id);
                frmShowTableOptions.ShowDialog();
            }
            else
            {
                // Mesa não encontrada
                MessageBox.Show("Mesa não encontrada.");
            }
        }
        else
        {
            // Texto não é um número válido
            MessageBox.Show("Por favor, insira um número válido.");
        }
    }
}