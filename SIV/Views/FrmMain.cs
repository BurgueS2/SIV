using System;
using System.Windows.Forms;
using SIV.Views.Clients;
using SIV.Views.Employees;
using SIV.Views.Jobs;

namespace SIV.Views;

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
        var frmEmployees = new FrmEmployees();
        frmEmployees.ShowDialog();
    }

    private void MenuRegistrationJob_Click(object sender, EventArgs e)
    {
        var frmJobs = new FrmJobs();
        frmJobs.ShowDialog();
    }

    private void MenuRegistrationClient_Click(object sender, EventArgs e)
    {
        var frmClients = new FrmClients();
        frmClients.ShowDialog();
    }
}