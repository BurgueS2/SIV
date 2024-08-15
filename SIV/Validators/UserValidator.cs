using System.Text.RegularExpressions;

namespace SIV.Validators;

/// <summary>
/// Essa classe é responsável pela validação dos dados dos usuários antes de serem processados ou salvos no banco de dados.
/// Ela verifica se os campos de entrada atendem aos critérios especificados, como formato do nome, correspondência de senhas e presença de cargo.
/// </summary>
public abstract class UserValidator
{
    /// <summary>
    /// Valida os campos de um usuário, incluindo nome, senha, repetição da senha e cargo.
    /// </summary>
    /// <param name="name">Nome do usuário. Deve conter apenas letras e espaços, com um mínimo de 2 caracteres.</param>
    /// <param name="password">Senha do usuário. Deve ter no mínimo 4 caracteres.</param>
    /// <param name="repeatPassword">Repetição da senha do usuário. Deve coincidir com a senha.</param>
    /// <param name="job">Cargo do usuário. Não pode ser vazio.</param>
    /// <returns>Retorna uma string vazia se todos os campos forem válidos. Caso contrário, retorna uma mensagem de erro específica para o primeiro campo inválido encontrado.</returns>    
    public static string ValidateUser(string name, string password, string repeatPassword, string job)
    {
        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
        {
            return "Nome inválido. Use apenas letras e espaços.";
        }
        
        if (password != repeatPassword)
        {
            return "As senhas não coincidem.";
        }
        
        if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
        {
            return "A senha deve ter no mínimo 4 caracteres.";
        }
        
        if (string.IsNullOrWhiteSpace(job))
        {
            return "Adicione um cargo ao funcionário.";
        }
        
        return string.Empty;
    }
}