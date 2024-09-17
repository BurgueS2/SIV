using SIV.Core;
using SIV.Repositories;

namespace SIV.Controllers;

public class UserController
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
        
        if (user != null)
        {
            SessionManager.SetCurrentUser(user);
        }
    }
}