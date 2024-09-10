using System.Text.RegularExpressions;

namespace SIV.Validators;

/// <summary>
/// A classe é responsável pela validação dos dados dos funcionários antes de serem processados ou salvos no banco de dados.
/// Ela utiliza expressões regulares para validar o formato dos campos de entrada.
/// </summary>
public class EmployeeValidator
{
    /// <summary>
    /// Valida os campos de um funcionário, incluindo nome, CPF, telefone, cargo e endereço.
    /// </summary>
    /// <param name="name">Nome do funcionário. Deve conter apenas letras e espaços, com um mínimo de 2 caracteres.</param>
    /// <param name="cpf">CPF do funcionário. Deve seguir o formato de CPF brasileiro (XXX.XXX.XXX-XX).</param>
    /// <param name="phone">Telefone do funcionário. Aceita formatos com ou sem parênteses para o DDD, espaços ou hífens, e pode incluir o 9 inicial para celulares.</param>
    /// <param name="job">Cargo do funcionário. Não pode ser vazio.</param>
    /// <param name="address">Endereço do funcionário. Não pode ser vazio.</param>
    /// <returns>Retorna uma string vazia se todos os campos forem válidos. Caso contrário, retorna uma mensagem de erro específica para o primeiro campo inválido encontrado.</returns>
    public static string ValidateEmployee(string name, string cpf, string phone, string job, string address)
    {
        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
        {
            return "Nome inválido. Use apenas letras e espaços.";
        }
        
        if (string.IsNullOrWhiteSpace(cpf) || !Regex.IsMatch(cpf, @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$"))
        {
            return "Formato de CPF inválido.";
        }

        if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$"))
        {
            return "Formato de telefone inválido.";
        }

        if (string.IsNullOrWhiteSpace(job))
        {
            return "Adicione um cargo ao funcionário.";
        }
        
        if (string.IsNullOrWhiteSpace(address))
        {
            return "Preencha o campo endereço.";
        }

        return string.Empty;
    }
}