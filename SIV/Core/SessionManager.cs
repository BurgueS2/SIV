using SIV.Models;

namespace SIV.Core;

/// <summary>
/// Classe responsável por gerenciar a sessão do usuário logado.
/// </summary>
public abstract class SessionManager
{
    // Propriedade para armazenar o usuário logado
    public static User CurrentUser { get; private set; }

    // Método para limpar a sessão
    public static void ClearSession()
    {
        CurrentUser = null;
    }

    // Método para definir o usuário logado
    public static void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }
}