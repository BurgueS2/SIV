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
            using var cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS tables (id INT PRIMARY KEY, state TEXT)", connection);
            
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
                "INSERT INTO tables (id, state, color, save_date, save_time)" + 
                "VALUES (@id, @state, @color, @save_date, @save_time)" + 
                "ON DUPLICATE KEY UPDATE state=@state, color=@color, save_date=@save_date, save_time=@save_time", connection);
            
            cmd.Parameters.AddWithValue("@id", table.Id);
            cmd.Parameters.AddWithValue("@state", table.State);
            cmd.Parameters.AddWithValue("@color", table.Color);
            cmd.Parameters.AddWithValue("@save_date", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@save_time", DateTime.Now.TimeOfDay);
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
                using (var cmd = new MySqlCommand("SELECT state, color, product_name, product_price,save_date, save_time FROM tables WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return new Table(id);

                        var table = new Table(id)
                        {
                            State = reader["state"].ToString(),
                            Color = reader["color"].ToString(),
                            SaveDate = reader["save_date"] != DBNull.Value ? (DateTime?)reader["SaveDate"] : null,
                            SaveTime = reader["save_time"] != DBNull.Value ? (TimeSpan?)reader["SaveTime"] : null
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
            using var cmd = new MySqlCommand("DELETE FROM tables WHERE id = @id", connection);
            
            cmd.Parameters.AddWithValue("@id", id);
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
                "INSERT INTO tables (id, product_name, product_price, amount)" + 
                "VALUES (@tableId, @productName, @productPrice, @amount)", connection);
            
            cmd.Parameters.AddWithValue("@tableId", tableId);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@productPrice", productPrice);
            cmd.Parameters.AddWithValue("@amount", amount);
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
            using var cmd = new MySqlCommand("SELECT product_name, product_price, amount FROM tables WHERE id = @tableId", connection);

            cmd.Parameters.AddWithValue("@tableId", tableId);
            
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
            using var cmd = new MySqlCommand("UPDATE tables SET state = @state, color = @color WHERE id = @id", connection);
            
            cmd.Parameters.AddWithValue("@id", tableId);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o estado da mesa");
        }
    }
}