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
            using var cmd = new MySqlCommand("SELECT * FROM Payments ORDER BY PaymentType", connection);
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
                "INSERT INTO Payments (Flag, DaysToCredit, OperatorCnpj, Tax, Status, PaymentType)" + 
                "VALUES (@Flag, @DaysToCredit, @OperatorCnpj, @Tax, @Status, @Type)", connection);
            
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
                "UPDATE Payments SET Flag = @Flag, DaysToCredit = @DaysToCredit, OperatorCnpj = @OperatorCnpj, Tax = @Tax," +
                "Status = @Status, PaymentType = @PaymentType WHERE Id = @Id", connection);

            AddPaymentParameters(cmd, payment);
            cmd.Parameters.AddWithValue("@Id", payment.Id);
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
    /// <param name="id">ID do pagamento a ser excluído.</param>
    public static void DeletePayment(string id)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM Payments WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o método de pagamento");
        }
    }
    
    /// <summary>
    /// Pesquisa métodos de pagamento pelo nome da bandeira.
    /// </summary>
    /// <param name="flag">A bandeira do pagamento a ser pesquisada.</param>
    /// <returns>Um DataTable contendo os métodos de pagamento que correspondem à bandeira informada.</returns>
    public static DataTable SearchByPaymentName(string flag)
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM Payments WHERE Flag LIKE @Flag ORDER BY Flag", connection);
            
            cmd.Parameters.AddWithValue("@Flag", "%" + flag + "%"); // Adiciona o caractere % para buscar qualquer nome que contenha o valor informado
            
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "pesquisar funcionários");
            return null;
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
                "INSERT INTO PartialPayments (TableId, Amount)" + 
                "VALUES (@TableId, @Amount)", connection);
            
            cmd.Parameters.AddWithValue("@TableId", tableId);
            cmd.Parameters.AddWithValue("@Amount", value);
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
            using var cmd = new MySqlCommand("DELETE FROM PartialPayments WHERE TableId = @TableId", connection);
            
            cmd.Parameters.AddWithValue("@TableId", tableId);
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
                "SELECT amount FROM PartialPayments WHERE TableId = @TableId", connection);
            
            command.Parameters.AddWithValue("@TableId", tableId);
            using var reader = command.ExecuteReader();
            
            while (reader.Read()) // leitura dos valores pagos
            {
                paidAmounts.Add(reader.GetDecimal("Amount")); // adiciona o valor pago à lista
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
        cmd.Parameters.AddWithValue("@Flag", payment.Flag);
        cmd.Parameters.AddWithValue("@DaysToCredit", payment.DaysToCredit);
        cmd.Parameters.AddWithValue("@OperatorCnpj", payment.OperatorCnpj);
        cmd.Parameters.AddWithValue("@Tax", payment.Tax);
        cmd.Parameters.AddWithValue("@Status", payment.Status);
        cmd.Parameters.AddWithValue("@Type", payment.Type);
    }
}
