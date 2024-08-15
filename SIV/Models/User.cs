using System.Collections.Generic;

namespace SIV.Models;

/// <summary>
/// Representa um usuário do sistema.
/// </summary>
public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Job { get; set; }
    public string Access { get; set; }
    public List<string> Permissions { get; set; }
    public string Active { get; set; }
    
    /// <summary>
    /// Verifica se o usuário possui a permissão informada.
    /// </summary>
    /// <param name="permission">Permissões são utilizadas para controlar o acesso do usuário a determinadas funcionalidades do sistema.</param>
    /// <returns>Retorna verdadeiro se o usuário possuir a permissão, caso contrário, retorna falso.</returns>
    public bool HasPermission(string permission)
    {
        return Permissions.Contains(permission);
    }
}