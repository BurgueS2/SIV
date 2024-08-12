using System.Text.RegularExpressions;

namespace SIV.Validators;

public class UserValidator
{
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