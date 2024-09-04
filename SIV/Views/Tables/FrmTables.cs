using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Repositories;
using SIV.teste;

namespace SIV.Views.Tables;

public partial class FrmTables : Form
{
    private List<Table> _tables;

    public FrmTables()
    {
        InitializeComponent();
        InitializeTables();
        TableRepository.InitializeDatabase();
        EnableDoubleBuffering(flowLayoutPanelTables);
    }
    
    private void InitializeTables()
    {
        _tables = LoadTablesFromRepository(); // Carrega as mesas do repositório
        CreateTableButtons();
    }

    // Carrega as mesas do repositório
    private static List<Table> LoadTablesFromRepository()
    {
        var tables = new List<Table>();
        
        for (int i = 1; i <= 200; i++)
        {
            var table = TableRepository.LoadTable(i);
            tables.Add(table);
        }
        
        return tables;
    }
    
    private void CreateTableButtons()
    {
        foreach (var btn in _tables.Select(CreateTableButton))
        {
            flowLayoutPanelTables.Controls.Add(btn); // Adiciona o botão ao painel de mesas
        }
    }
    
    private Guna2Button CreateTableButton(Table table)
    {
        var btn = new Guna2Button
        {
            Text = @$"Mesa {table.Id}",
            Name = $"btnTable{table.Id}",
            Width = 180,
            Height = 100,
            Tag = table.Id,
            BorderRadius = 15,
            FillColor = Color.FromName(table.Color),
            ForeColor = Color.Black,
            BorderColor = Color.FromArgb(217, 221, 226),
            BorderThickness = 1,
            Font = new Font("Century Gothic", 14, FontStyle.Bold),
            Margin = new Padding(5),
            Animated = true
        };
        
        btn.Click += BtnTable_Click;
        
        return btn;
    }
    
    private static void UpdateTableStateAndColor(Table table, Guna2Button btn)
    {
        switch (table.State)
        {
            case "Ocupada":
                btn.FillColor = Color.Khaki;
                table.Color = "Khaki";
                break;
            case "Fechada":
                btn.FillColor = Color.LightCoral;
                table.Color = "LightCoral";
                break;
            case "Normal":
                btn.FillColor = SystemColors.Control;
                table.Color = "Control";
                break;
        }
        
        TableRepository.UpdateTableState(table.Id, table.State, table.Color); // Atualiza o estado da mesa no banco de dados
    }
    
    private void BtnTable_Click(object sender, EventArgs e)
    {
        if (sender is not Guna2Button btn) return;
        
        var tableId = (int)btn.Tag; // Obtém o ID da mesa
        var table = _tables.Find(t => t.Id == tableId); // Obtém a mesa correspondente ao ID

        using (var frmShowTableOptions = new FrmShowTableOptions(table.State, tableId))
        {
            if (frmShowTableOptions.ShowDialog() != DialogResult.OK) return;
            
            table.State = frmShowTableOptions.TableState;
            UpdateTableStateAndColor(table, btn); // Atualiza o estado e a cor do botão da mesa
        }
    }
    
    private static void EnableDoubleBuffering(Control control)
    {
        typeof(Control).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
            null, control, [true]);
    }
}