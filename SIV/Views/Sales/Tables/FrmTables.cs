using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Repositories;
using SIV.teste;

namespace SIV.Views.Sales.Tables;

public partial class FrmTables : Form
{
    private List<Table> _tables;

    public FrmTables()
    {
        InitializeComponent();
        InitializeTables();
        TableRepository.InitializeDatabase();
    }

    private void InitializeTables()
    {
        _tables = [];

        for (int i = 1; i <= 200; i++)
        {
            var table = TableRepository.LoadTables(i);
            _tables.Add(table);

            var btn = new Guna2Button
            {
                Text = $"Mesa {i}",
                Name = $"btnTable{i}",
                Width = 180,
                Height = 100,
                Tag = i,
                BorderRadius = 15,
                FillColor = Color.FromName(table.Color),
                ForeColor = Color.Black,
                BorderColor = Color.FromArgb(217, 221, 226),
                BorderThickness = 1,
                Font = new Font("Century Gothic", 14, FontStyle.Bold),
                Margin = new Padding(5)
            };

            btn.Animated = true;
            btn.Click += BtnTable_Click;

            flowLayoutPanelTables.Controls.Add(btn);
        }
    }

    private void BtnTable_Click(object sender, EventArgs e)
    {
        var btn = sender as Guna2Button;
        var tableId = (int)btn.Tag;
        var table = _tables.Find(t => t.Id == tableId);

        using (var frmShowTableOptions = new FrmShowTableOptions(table.State, tableId))
        {
            if (frmShowTableOptions.ShowDialog() == DialogResult.OK)
            {
                table.State = frmShowTableOptions.TableState;
                
                if (table.State == "Aberta")
                {
                    table.OpenDate = DateTime.Now.Date;
                    table.OpenTime = DateTime.Now.TimeOfDay;
                    table.StayHours = TimeSpan.Zero;
                }

                switch (table.State)
                {
                    case "Aberta":
                        btn.FillColor = Color.LightGreen;
                        table.Color = "LightGreen";
                        break;
                    case "Fechada":
                        btn.FillColor = Color.IndianRed;
                        table.Color = "IndianRed";
                        break;
                    case "Normal":
                        btn.FillColor = SystemColors.Control;
                        table.Color = "Control";
                        break;
                }

                TableRepository.SaveTable(table);
            }
        }

















        /*
        var btn = sender as Guna2Button;
        var tableId = (int)btn.Tag;
        var table = _tables.Find(t => t.Id == tableId);

        if (isTableOpen)
        {
            FrmShowTableOptions frmShowTableOptions = new FrmShowTableOptions();
            frmShowTableOptions.ShowDialog();
            CloseTable();
        }
        else
        {
            OpenTable();
        }
        if (table.IsOpen)
        {
            if (table.IsPaid)
            {
                MessageBox.Show($"Mesa {tableId} já foi paga.");
            }
            else
            {
                // Lançar produtos ou fechar mesa
                var result = MessageBox.Show($"Deseja fechar a mesa {tableId}?", "Fechar Mesa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    table.IsOpen = false;
                    MessageBox.Show($"Mesa {tableId} fechada.");
                }
                else
                {
                    // Lançar produtos
                    string product = Prompt.ShowDialog("Digite o produto:", "Lançar Produto");
                    table.Products.Add(product);
                    MessageBox.Show($"Produto {product} lançado na mesa {tableId}.");
                }
            }
        }
        else
        {
            // Abrir mesa
            table.IsOpen = true;
            MessageBox.Show($"Mesa {tableId} aberta.");
        }*/
        }
    }