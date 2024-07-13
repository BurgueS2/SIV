using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIV;

public partial class FrmMain : MetroFramework.Forms.MetroForm
{
    public FrmMain()
    {
        InitializeComponent();
    }
    
    private void Exiting_Click(object sender, EventArgs e)
    {
        var questioning = MessageBox.Show(this,@"Deseja sair do sistema?", @"Sair do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (questioning == DialogResult.Yes)
        {
            Application.Exit();
        }
    }

    private void MenuRegistrationEmployee_Click(object sender, EventArgs e)
    {
        var frmEmployees = new Registers.Employees.FrmEmployees();
        frmEmployees.ShowDialog();
    }
}