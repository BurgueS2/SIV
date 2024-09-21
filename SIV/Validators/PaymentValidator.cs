using System.Text.RegularExpressions;

namespace SIV.Validators;

public static class PaymentValidator
{
    public static string ValidatePayment(string flag, string cnpj)
    {
        if (string.IsNullOrWhiteSpace(flag) || !Regex.IsMatch(flag, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]{2,}$"))
        {
            return "Nome inválido. Use apenas letras e espaços.";
        }
        
        if (!string.IsNullOrWhiteSpace(cnpj) && !Regex.IsMatch(cnpj, @"^\d{2}\.?\d{3}\.?\d{3}/?\d{4}-?\d{2}$"))
        {
            return "Formato de CNPJ inválido.";
        }

        return string.Empty;
    }
}