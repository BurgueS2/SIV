using System.Text.RegularExpressions;

namespace SIV.Registers.Employees;

public class EmployeeValidator
{
    public static string ValidateEmployee(string name, string cpf, string phone, string job, string address)
    {
        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
        {
            return "Nome inválido. Use apenas letras e espaços.";
        }
        
        if (!Regex.IsMatch(cpf, @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$"))
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

        return string.Empty; // Se não houver erros, retorna uma string vazia
    }
}