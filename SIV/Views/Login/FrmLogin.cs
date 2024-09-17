using System;
using System.Windows.Forms;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;

namespace SIV.Views.Login;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
    }
    
    private void btnEnter_Click(object sender, EventArgs e)
    {
        VerifyUser();
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    
    private void VerifyUser()
    {
        try
        {
            var user = txtUser.Text.Trim().ToUpper();
            var password = txtPassword.Text.Trim();

            if (!AreFieldsValid(user, password))
            {
                MessageHelper.LoginValidationMessage("Preencha todos os campos!");
            }
            
            UserController.Login(user, password);

            if (SessionManager.CurrentUser != null)
            {
                OpenMainForm();
            }
            else
            {
                HandleInvalidLogin();
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.ShowErrorMessage(ex, "realizar o login");
        }
    }
    
    private static bool AreFieldsValid(string user, string password)
    {
        return !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password);
    }
    
    private void OpenMainForm()
    {
        Hide();
        var main = new FrmMain();
        main.Show();
    }
    
    private void HandleInvalidLogin()
    {
        MessageHelper.LoginValidationMessage("Usuário ou senha inválidos!");
        ClearFields();
        txtUser.Focus();
    }
    
    private void ClearFields()
    {
        txtUser.Clear();
        txtPassword.Clear();
    }
}