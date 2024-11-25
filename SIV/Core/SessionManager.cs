using SIV.Models;

namespace SIV.Core;

/// <summary>
/// A classe <c>SessionManager</c> é responsável por gerenciar a sessão do usuário atual na aplicação.
/// Ela fornece métodos para definir e limpar a sessão do usuário atual.
/// </summary>
public abstract class SessionManager
{
    /// <summary>
    /// Armazena o usuário atual da sessão.
    /// </summary>
    public static User CurrentUser { get; private set; }
    
    /// <summary>
    /// Limpa a sessão do usuário atual.
    /// </summary>
    public static void ClearSession()
    {
        CurrentUser = null;
    }
    
    /// <summary>
    /// Define o usuário atual da sessão.
    /// </summary>
    /// <param name="user">O usuário a ser definido como o usuário atual.</param>
    public static void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }
}