using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

public static class PaymentRepository
{
    public static DataTable GetAllPayment()
    {
        var dt = new DataTable();

        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("SELECT * FROM payments ORDER BY type", connection);
        using var adapter = new MySqlDataAdapter(cmd);
        
        adapter.Fill(dt);

        return dt;
    }
    
    public static void SavePayment(Payment payment)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand(
            "INSERT INTO payments (flag, days_to_credit, operator_cnpj, tax, status, type)" + 
            "VALUES (@flag, @daysToCredit, @operatorCnpj, @tax, @status, @type)", connection);
        AddPaymentParameters(cmd, payment);
        
        cmd.ExecuteNonQuery();
    }
    
    
    public static void UpdatePayment(Payment payment)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand(
            "UPDATE payments SET flag = @flag, days_to_credit = @daysToCredit, operator_cnpj = @operatorCnpj, tax = @tax," + 
            "status = @status, type = @type WHERE id = @id", connection);
        AddPaymentParameters(cmd, payment);
        
        cmd.Parameters.AddWithValue("@id", payment.Id);
        cmd.ExecuteNonQuery();
    }
    
    public static void DeletePayment(string id)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("DELETE FROM payments WHERE id = @id", connection);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }















    public static void SaveParcialPayment(int tableId, decimal value)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("INSERT INTO partial_payments (table_id, amount_paid) VALUES (@tableId, @amountPaid)", connection);
        cmd.Parameters.AddWithValue("@tableId", tableId);
        cmd.Parameters.AddWithValue("@amountPaid", value);
        cmd.ExecuteNonQuery();
    }
    
    public static void DeleteParcialPayment(int tableId)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("DELETE FROM partial_payments WHERE table_id = @tableId", connection);
        cmd.Parameters.AddWithValue("@tableId", tableId);
        cmd.ExecuteNonQuery();
        
        //Deletar registro na tabela tables
        var deleteTableQuery = "DELETE FROM tables WHERE entry_id = @tableId";
        using (var deleteCommand = new MySqlCommand(deleteTableQuery, connection))
        {
            deleteCommand.Parameters.AddWithValue("@tableId", tableId);
            deleteCommand.ExecuteNonQuery();
        }
    }
    
    public static List<decimal> GetPaidAmountsForTable(int tableId)
    {
        var paidAmounts = new List<decimal>();

        try
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                var query = "SELECT amount_paid FROM partial_payments WHERE table_id = @tableId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tableId", tableId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paidAmounts.Add(reader.GetDecimal("amount_paid"));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os valores pagos");
        }

        return paidAmounts;
    }









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
