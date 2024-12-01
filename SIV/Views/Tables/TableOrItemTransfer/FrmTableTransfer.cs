﻿using System;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;

namespace SIV.Views.Tables.TableOrItemTransfer;

public partial class FrmTableTransfer : MetroFramework.Forms.MetroForm
{
    private int _tableId;
    
    public FrmTableTransfer(int tableId)
    {
        InitializeComponent();
        _tableId = tableId; // Recebe o ID da mesa que será transferida.
        txtCurrentTable.Text = tableId.ToString(); // Exibe o ID da mesa na tela.
        LoadTableProducts();
        txtTargetTableId.Focus();
    }
    
    private void btnExit_Click(object sender, EventArgs e) => Close();
    
    private void btnBackspace_Click(object sender, EventArgs e) => RemoveLastCharacter(txtTargetTableId);
    
    private void btnOk_Click(object sender, EventArgs e) => TransferProductsToTable();
    
    private void NumberButton_Click(object sender, EventArgs e)
    {
        if (sender is Guna2Button btn)
        {
            AppendText(txtTargetTableId, btn.Text); // Coloca o número do botão no campo de texto, ao clicar no botão.
        }
    }
    
    private void txtCurrentTable_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            HandleCurrentTableEnter(); // Verifica se o valor inserido é um número. Após isso, exibe o estado da mesa.
        }
    }
    
    private void LoadTableProducts()
    {
        try
        {
            gridData.DataSource = TableRepository.GetTableProducts(_tableId);
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar produtos da mesa");
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns["EntryId"]!.Visible = false;
        gridData.Columns["ProductName"]!.HeaderText = @"Produto";
        gridData.Columns["ProductPrice"]!.Visible = false;
        gridData.Columns["Amount"]!.HeaderText = @"Quant.";
        
        // Oculta as linhas que não possuem produtos.
        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Cells["ProductName"].Value?.ToString()))
            {
                row.Visible = false;
            }
        }
    }
    
    private void TransferProducts(int targetTableId)
    {
        TableRepository.TransferProductsToTable(_tableId, targetTableId);
        LoadTableProducts();
    }
    
    private static void UpdateParentForm()
    {
        // Atualiza a lista de mesas na tela principal.
        var parentForm = Application.OpenForms.OfType<FrmTables>().FirstOrDefault();
        parentForm?.ReloadTables();
    }
    
    /// <summary>
    /// Método que auxilia na transferência de produtos entre mesas.
    /// Ao pressionar a tecla Enter, o sistema verifica se o valor inserido é um número. Após isso, exibe o estado da mesa.
    /// </summary>
    private void HandleCurrentTableEnter()
    {
        try
        {
            var input = txtCurrentTable.Text;

            if (!int.TryParse(input, out var tableId)) return; // Verifica se o valor inserido é um número 
            
            var table = TableRepository.LoadTable(tableId); // Carrega os dados da mesa

            if (table.State == "Fechada")
            {
                MessageHelper.TableStatusClosedMessage(tableId);
                return;
            }
            
            MessageHelper.TableStatusMessage(tableId, table.State); // Exibe o estado da mesa
            _tableId = tableId;
            LoadTableProducts();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "Lidar com a entrada da mesa atual");
        }

    }
    
    private static void RemoveLastCharacter(Guna2TextBox textBox)
    {
        if (textBox.Text.Length > 0)
        {
            textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
        }
    }
    
    private static void AppendText(Guna2TextBox textBox, string text)
    {
        textBox.Text += text; // Coloca o número do botão no campo de texto
    }
    
    private void TransferProductsToTable()
    {
        try
        {
            if (int.TryParse(txtTargetTableId.Text, out var targetTableId))
            {
                if (targetTableId == _tableId)
                {
                    MessageHelper.TableTransferErrorMessage();
                    return;
                }
                
                TransferProducts(targetTableId);
                MessageHelper.TableTransferSuccessMessage();
                UpdateParentForm();
            }
            else
            {
                MessageHelper.ShowValidationMessage("O valor informado é inválido.");
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "transferir produtos para mesa");
        }
    }
}