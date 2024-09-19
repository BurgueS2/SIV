using System;
using System.Windows.Forms;
using SIV.Controllers;
using SIV.Core;
using SIV.Helpers;

namespace SIV.Views.Login;

public partial class FrmLogin : Form
{
    public FrmLogin() => InitializeComponent();
    
    private void btnEnter_Click(object sender, EventArgs e) => VerifyUser();
    
    private void btnCancel_Click(object sender, EventArgs e) => ClearFields();
    
    private void VerifyUser()
    {
        try
        {
            var user = txtUser.Text.Trim().ToUpper();
            var password = txtPassword.Text.Trim();

            if (AreFieldsValid(user, password)) return;
            
            UserController.Login(user, password);

            if (SessionManager.CurrentUser != null)
            {
                OpenMainForm();
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
        if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password)) return false;
        MessageHelper.LoginValidationMessage("Preencha todos os campos!");
        return true;
    }
    
    private void OpenMainForm()
    {
        Hide();
        var frm = new FrmMain();
        frm.UpdateUserLabel(SessionManager.CurrentUser.Name); // Atualiza o label com o nome do usuário logado
        frm.Show();
    }
    
    private void ClearFields()
    {
        txtUser.Clear();
        txtPassword.Clear();
    }
}