using System.Text.RegularExpressions;

namespace SIV.Validators;

/// <summary>
/// A classe é responsável pela validação dos dados dos clientes antes de serem processados ou salvos no banco de dados.
/// Utiliza expressões regulares para validar o formato dos campos de entrada, garantindo que os dados estejam corretos e seguindo os padrões definidos.
/// </summary>
public class ClientValidator
{
    /// <summary>
    /// Valida os campos de um cliente, incluindo nome, CPF, telefone, email e endereço.
    /// </summary>
    /// <param name="name">Nome do cliente. Deve conter apenas letras e espaços, com um mínimo de 2 caracteres.</param>
    /// <param name="cpf">CPF do cliente. Deve seguir o formato de CPF brasileiro (XXX.XXX.XXX-XX).</param>
    /// <param name="phone">Telefone do cliente. Aceita formatos com ou sem parênteses para o DDD, espaços ou hífens, e pode incluir o 9 inicial para celulares.</param>
    /// <param name="email">Email do cliente. Deve ser um email válido conforme definido pela expressão regular.</param>
    /// <param name="address">Endereço do cliente. Não pode ser vazio.</param>
    /// <returns>Retorna uma string vazia se todos os campos forem válidos. Caso contrário, retorna uma mensagem de erro específica para o primeiro campo inválido encontrado.</returns>
    public static string ValidateClient(string name, string cpf, string phone, string email, string address)
    {
        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
        {
            return "Nome inválido. Use apenas letras e espaços.";
        }
        
        if (!Regex.IsMatch(cpf, @"^\d{3}\,?\d{3}\,?\d{3}-?\d{2}$"))
        {
            return "Formato de CPF inválido.";
        }

        if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$"))
        {
            return "Formato de telefone inválido.";
        }

        if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
        {
            return "Formato de e-mail inválido.";
        }
        
        if (string.IsNullOrWhiteSpace(address))
        {
            return "Preencha o campo endereço.";
        }

        return string.Empty; // Se não houver erros, retorna uma string vazia
    }
}