namespace SIV.Registers.Employees;

public class EmployeeValidator
{
    public static string ValidateEmployee(string name, string cpf, string phone, string job, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Preencha o campo NOME";
        }
        
        if (cpf == "   .   .   -" || cpf.Length < 14)
        {
            return "Preencha o campo CPF corretamente";
        }

        if (string.IsNullOrWhiteSpace(phone) || phone.Length < 11)
        {
            return "Preencha o campo TELEFONE corretamente";
        }

        if (string.IsNullOrWhiteSpace(job))
        {
            return "Adicione um CARGO ao funcionário";
        }
        if (string.IsNullOrWhiteSpace(address))
        {
            return "Preencha o campo ENDEREÇO";
        }

        return string.Empty; // Se não houver erros, retorna uma string vazia
    }
}