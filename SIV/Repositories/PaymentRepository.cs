using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>PaymentRepository</c> é responsável por intermediar a comunicação entre a aplicação e a tabela 'payments' do banco de dados.
/// </summary>
public static class PaymentRepository
{
    /// <summary>
    /// Obtém todos os métodos de pagamento disponíveis.
    /// </summary>
    /// <returns>Uma lista de métodos de pagamento.</returns>
    public static DataTable GetAllPayment()
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM payments ORDER BY type", connection);
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os métodos de pagamento");
            return null;
        }
    }
    
    /// <summary>
    /// Salva um novo método de pagamento no banco de dados.
    /// </summary>
    /// <param name="payment">O objeto Payment contendo os dados a serem salvos.</param>
    public static void SavePayment(Payment payment)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO payments (flag, days_to_credit, operator_cnpj, tax, status, type)" + 
                "VALUES (@flag, @daysToCredit, @operatorCnpj, @tax, @status, @type)", connection);
            
            AddPaymentParameters(cmd, payment);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o método de pagamento");
        }
    }
    
    /// <summary>
    /// Atualiza um método de pagamento existente no banco de dados.
    /// </summary>
    /// <param name="payment">O objeto Payment contendo os dados atualizados.</param>
    public static void UpdatePayment(Payment payment)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "UPDATE payments SET flag = @flag, days_to_credit = @daysToCredit, operator_cnpj = @operatorCnpj, tax = @tax," +
                "status = @status, type = @type WHERE id = @id", connection);

            AddPaymentParameters(cmd, payment);
            cmd.Parameters.AddWithValue("@id", payment.Id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o método de pagamento");
        }
    }
    
    /// <summary>
    /// Exclui um método de pagamento do banco de dados.
    /// </summary>
    /// <param name="payment">O objeto <c>Payment</c> contendo o ID do pagamento a ser excluído.</param>
    public static void DeletePayment(Payment payment)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM payments WHERE id = @id", connection);

            cmd.Parameters.AddWithValue("@id", payment.Id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o método de pagamento");
        }
    }

    /// <summary>
    /// Salva um pagamento parcial para uma mesa.
    /// </summary>
    /// <param name="tableId">O ID da mesa.</param>
    /// <param name="value">O valor pago.</param>
    public static void SaveParcialPayment(int tableId, decimal value)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO partial_payments (table_id, amount)" + 
                "VALUES (@tableId, @amountPaid)", connection);
            
            cmd.Parameters.AddWithValue("@tableId", tableId);
            cmd.Parameters.AddWithValue("@amountPaid", value);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o pagamento parcial");
        }
    }
    
    /// <summary>
    /// Exclui um pagamento parcial de uma mesa.
    /// </summary>
    /// <param name="tableId">O ID da mesa.</param>
    public static void DeleteParcialPayment(int tableId)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM partial_payments WHERE table_id = @tableId", connection);
            
            cmd.Parameters.AddWithValue("@tableId", tableId);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o pagamento parcial");
        }
    }
    
    /// <summary>
    /// Obtém os valores pagos para uma mesa específica.
    /// </summary>
    /// <param name="tableId">O ID da mesa.</param>
    /// <returns>Uma lista de valores pagos.</returns>
    public static List<decimal> GetPaidAmountsForTable(int tableId)
    {
        var paidAmounts = new List<decimal>();

        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var command = new MySqlCommand(
                "SELECT amount FROM partial_payments WHERE table_id = @tableId", connection);
            
            command.Parameters.AddWithValue("@tableId", tableId);
            using var reader = command.ExecuteReader();
            
            while (reader.Read()) // leitura dos valores pagos
            {
                paidAmounts.Add(reader.GetDecimal("amount")); // adiciona o valor pago à lista
            }
            
            return paidAmounts;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os valores pagos");
            return null;
        }
    }

    /// <summary>
    /// Adiciona os parâmetros de um objeto Payment a um comando MySql.
    /// </summary>
    /// <param name="cmd">O comando MySql ao qual os parâmetros serão adicionados.</param>
    /// <param name="payment">O objeto Payment contendo os dados dos parâmetros.</param>
    private static void AddPaymentParameters(MySqlCommand cmd, Payment payment)
    {
        cmd.Parameters.AddWithValue("@flag", payment.Flag);
        cmd.Parameters.AddWithValue("@daysToCredit", payment.DaysToCredit);
        cmd.Parameters.AddWithValue("@operatorCnpj", payment.OperatorCnpj);
        cmd.Parameters.AddWithValue("@tax", payment.Tax);
        cmd.Parameters.AddWithValue("@status", payment.Status);
        cmd.Parameters.AddWithValue("@type", payment.Type);
    }
}
