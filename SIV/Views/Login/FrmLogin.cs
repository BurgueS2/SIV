using System;
using System.Windows.Forms;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;

namespace SIV.Views.Login;

public partial class FrmLogin : Form
{
    private readonly UserController _controller;
    
    public FrmLogin()
    {
        InitializeComponent();
        _controller = new UserController();
    }
    
    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    
    private void btnEnter_Click(object sender, EventArgs e)
    {
        VerifyUser();
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        txtUser.Clear();
        txtPassword.Clear();
    }
    
    private void VerifyUser()
    {
        try
        {
            var user = "teste";//txtUser.Text.Trim();
            var password = "teste";//txtPassword.Text.Trim();
            
            if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(password))
            {
                MessageHelper.ShowValidationMessage("Campos Inválidos!");
                return;
            }

            if (string.IsNullOrEmpty(user))
            {
                MessageHelper.ShowValidationMessage("Informe o Usuário!");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageHelper.ShowValidationMessage("Informe a Senha!");
                return;
            }
            
            UserController.Login(user, password);
            
            var loggedInUser = SessionManager.CurrentUser;
            if (loggedInUser.HasPermission("AccessSystem"))
            {
                Hide();
                //var frm = new FrmMain(loggedInUser);
                //frm.Show();
            }
            else
            {
                MessageHelper.ShowValidationMessage("Usuário não tem permissão para acessar o sistema!");
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageBox.Show($@"Ocorreu um erro ao verificar o usuário! {ex.Message}");
        }
    }
}