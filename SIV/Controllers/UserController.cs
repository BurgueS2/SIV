using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;

namespace SIV.Controllers;

public static class UserController
{ 
    /// <summary>
    /// Realiza o logoff do usuário atual, limpando a sessão.
    /// </summary>
    public static void Logoff()
    {
        SessionManager.ClearSession();
    }
    
    /// <summary>
    /// Realiza o login do usuário com base no nome de usuário e senha fornecidos.
    /// Se o login for bem-sucedido, define o usuário atual na sessão.
    /// </summary>
    /// <param name="username">O nome de usuário fornecido para login.</param>
    /// <param name="password">A senha fornecida para login.</param>
    public static void Login(string username, string password)
    {
        var user = UserRepository.UserPermission(username, password);

        if (user == null)
        {
            MessageHelper.LoginValidationMessage("Usuário ou senha inválidos!");
            return;
        }
        
        if (user.Active == "INATIVO")
        {
            MessageHelper.LoginValidationMessage("Usuário inativo! Contate o administrador.");
            return;
        }
        
        SessionManager.SetCurrentUser(user);
    }
}