using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>CashRegisterRepository</c> é responsável por realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados para a entidade CashRegister.
/// </summary>
public static class CashRegisterRepository
{
    /// <summary>
    /// Obtém todos os usuários do banco de dados.
    /// </summary>
    /// <returns>Retorna um DataTable contendo todos os usuários.</returns>
    public static DataTable GetAllUser()
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM CashRegister ORDER BY UserName", connection);
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt); // Preenche o DataTable com os dados do banco de dados
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os dados dos clientes");
            return null;
        }
    }
    
    /// <summary>
    /// Abre um caixa para um usuário específico.
    /// </summary>
    /// <param name="userId">O ID do usuário que está abrindo o caixa.</param>
    /// <param name="userName">O nome do usuário que está abrindo o caixa.</param>
    /// <param name="openingAmount">O valor de abertura do caixa.</param>
    public static void OpenCashRegister(int userId, string userName, decimal openingAmount)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO CashRegister (UserId, UserName, OpeningAmount, OpeningDate, OpeningTime) " +
                "VALUES (@UserId, @UserName, @OpeningAmount, CURDATE(), CURTIME())", connection);

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@OpeningAmount", openingAmount);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "abrir o caixa");
        }
    }
    
    /// <summary>
    /// Verifica se um caixa já está aberto para um usuário específico.
    /// </summary>
    /// <param name="userId">O ID do usuário a ser verificado.</param>
    /// <returns>Retorna 'true' se o caixa já estiver aberto, caso contrário, 'false'.</returns>
    public static bool IsCashRegisterAlreadyOpen(int userId)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM CashRegister WHERE UserId = @UserId", connection);

            cmd.Parameters.AddWithValue("@UserId", userId);
            var count = Convert.ToInt32(cmd.ExecuteScalar()); // Converte o resultado da consulta para um inteiro
            return count > 0; // Se o resultado for maior que 0, o caixa já está aberto
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "verificar se o caixa já está aberto");
            return false;
        }
    }
}