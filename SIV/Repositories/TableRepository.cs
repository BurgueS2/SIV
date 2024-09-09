using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.teste;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>TableRepository</c> é responsável por intermediar a comunicação entre a aplicação e a tabela 'tables' do banco de dados.
/// </summary>
public static class TableRepository
{
    /// <summary>
    /// Inicializa o banco de dados criando a tabela 'tables' se ela não existir.
    /// </summary>
    public static void InitializeDatabase()
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS RestaurantTables (EntryId INT PRIMARY KEY, TableState TEXT)", connection);
            
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "inicializar o banco de dados");
        }
    }
    
    // Método a ser chamado quando o programa for fechado ou ser possivelmente excluído por não ser utilizado
    public static void SaveTable(Table table)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO tables (EntryId, TableState, TableColor, SaveDate, SaveTime)" + 
                "VALUES (@Id, @State, @Color, @SaveDate, @SaveTime)" + 
                "ON DUPLICATE KEY UPDATE state=@state, color=@color, save_date=@save_date, save_time=@save_time", connection);
            
            cmd.Parameters.AddWithValue("@Id", table.Id);
            cmd.Parameters.AddWithValue("@State", table.State);
            cmd.Parameters.AddWithValue("@Color", table.Color);
            cmd.Parameters.AddWithValue("@SaveDate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@SaveTime", DateTime.Now.TimeOfDay);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar a mesa");
        }
    }

    /// <summary>
    /// Carrega uma mesa do banco de dados com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID da mesa a ser carregada.</param>
    /// <returns>O objeto Table contendo os dados da mesa.</returns>
    public static Table LoadTable(int id)
    {
        try
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                using (var cmd = new MySqlCommand("SELECT TableState, TableColor, ProductName, ProductPrice, SaveDate, SaveTime FROM RestaurantTables WHERE EntryId = @Id", connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return new Table(id);

                        var table = new Table(id)
                        {
                            State = reader["State"].ToString(),
                            Color = reader["Color"].ToString(),
                            SaveDate = reader["SaveDate"] != DBNull.Value ? (DateTime?)reader["SaveDate"] : null,
                            SaveTime = reader["SaveTime"] != DBNull.Value ? (TimeSpan?)reader["SaveTime"] : null
                        };
                        
                        return table;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar a mesa");
            return new Table(id);
        }
        finally
        {
            ConnectionManager.CloseConnection();
        }
    }
    
    /// <summary>
    /// Exclui uma mesa do banco de dados com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID da mesa a ser excluída.</param>
    public static void DeleteTable(int id)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM RestaurantTables WHERE EntryId = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir a mesa");
        }
    }
    
    /// <summary>
    /// Adiciona um produto a uma mesa no banco de dados.
    /// </summary>
    /// <param name="tableId">O ID da mesa.</param>
    /// <param name="productName">O nome do produto.</param>
    /// <param name="productPrice">O preço do produto.</param>
    /// <param name="amount">A quantidade do produto.</param>
    public static void AddProductToTable(int tableId, string productName, decimal productPrice, decimal amount)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO RestaurantTables (EntryId, ProductName, ProductPrice, Amount)" + 
                "VALUES (@TableId, @ProductName, @ProductPrice, @Amount)", connection);
            
            cmd.Parameters.AddWithValue("@TableId", tableId);
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@ProductPrice", productPrice);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "adicionar produto à mesa");
        }
    }
    
    /// <summary>
    /// Obtém os produtos de uma mesa específica do banco de dados.
    /// </summary>
    /// <param name="tableId">O ID da mesa.</param>
    /// <returns>Um DataTable contendo os produtos da mesa.</returns>
    public static DataTable GetTableProducts(int tableId)
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT ProductName, ProductPrice, Amount FROM RestaurantTables WHERE EntryId = @TableId", connection);

            cmd.Parameters.AddWithValue("@TableId", tableId);
            
            using var adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar produtos da mesa");
            return new DataTable();
        }
    }
    
    /// <summary>
    /// Atualiza o estado e a cor de uma mesa no banco de dados.
    /// </summary>
    /// <param name="tableId">O ID da mesa.</param>
    /// <param name="state">O novo estado da mesa.</param>
    /// <param name="color">A nova cor da mesa.</param>
    public static void UpdateTableState(int tableId, string state, string color)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("UPDATE RestaurantTables SET TableState = @State, TableColor = @Color WHERE EntryId = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", tableId);
            cmd.Parameters.AddWithValue("@State", state);
            cmd.Parameters.AddWithValue("@Color", color);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o estado da mesa");
        }
    }
}