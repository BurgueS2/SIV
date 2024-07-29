using System;
using System.Drawing;
using System.Windows.Forms;
using SIV.Core;
using SIV.Views.Clients;
using SIV.Views.Employees;
using SIV.Views.Jobs;

namespace SIV.Views;

public partial class FrmMain : MetroFramework.Forms.MetroForm
{
    private Button _currentButton;
    private Random _random;
    private int _tempIndex;
    
    public FrmMain()
    {
        InitializeComponent();
    }
    
    private void Exiting_Click(object sender, EventArgs e)
    {
        if (MessageHelper.ConfirmExit())
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

    private Color RandomColor()
    {
        var index = _random.Next(ColorThemes._colorList.Count);

        while (_tempIndex == index){}
        {
            index = _random.Next(ColorThemes._colorList.Count);
        }
        
        _tempIndex = index;
        var color = ColorThemes._colorList[index];
        
        return ColorTranslator.FromHtml(color); // Converte uma cor em formato hexadecimal para um objeto Color
    }
}