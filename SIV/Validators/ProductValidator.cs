using System;

namespace SIV.Validators;

public static class ProductValidator
{
    /// <summary>
    /// Valida os campos de um produto, incluindo código, nome, descrição, preço de custo, preço de revenda, grupo de estoque e fornecedor.
    /// </summary>
    /// <param name="code">Código do produto. Deve conter apenas números inteiros ou ser nulo.</param>
    /// <param name="name">Nome do produto. Deve conter pelo menos 3 caracteres.</param>
    /// <param name="costPrice">Preço de custo do produto. Pode ser nulo ou um valor decimal positivo.</param>
    /// <param name="resalePrice">Preço de revenda do produto. Deve ser um valor decimal positivo.</param>
    /// <returns>Retorna uma string vazia se todos os campos forem válidos. Caso contrário, retorna uma mensagem de erro específica para o primeiro campo inválido encontrado.</returns>
    public static string ValidateProduct(string code, string name, string costPrice, string resalePrice)
    {
        if (!string.IsNullOrWhiteSpace(code) && !int.TryParse(code, out _))
        {
            return "Código inválido. Use apenas números inteiros ou deixe em branco.";
        }

        if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
        {
            return "Nome inválido. Deve conter pelo menos 3 caracteres.";
        }

        if (!decimal.TryParse(costPrice, out _) && !string.IsNullOrWhiteSpace(costPrice))
        {
            return "Preço de custo inválido. Deve ser um valor positivo.";
        }

        if (decimal.Parse(resalePrice) <= 0)
        {
            return "Preço de revenda inválido. Deve ser um valor positivo.";
        }

        return string.Empty;
    }
}