using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.teste;

namespace SIV.Repositories;

public class TableRepository
{
    public static void InitializeDatabase()
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS tables (id INT PRIMARY KEY, state TEXT)", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public static void SaveTable(Table table)
{
    using (var connection = ConnectionManager.GetConnection())
    {
        using (var cmd = new MySqlCommand("INSERT INTO tables (id, state, color, save_date, save_time) VALUES (@id, @state, @color, @save_date, @save_time) ON DUPLICATE KEY UPDATE state=@state, color=@color, save_date=@save_date, save_time=@save_time", connection))
        {
            cmd.Parameters.AddWithValue("@id", table.Id);
            cmd.Parameters.AddWithValue("@state", table.State);
            cmd.Parameters.AddWithValue("@color", table.Color);
            cmd.Parameters.AddWithValue("@save_date", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@save_time", DateTime.Now.TimeOfDay);

            cmd.ExecuteNonQuery();
        }
    }
}

public static Table LoadTable(int id)
{
    using (var connection = ConnectionManager.GetConnection())
    {
        using (var cmd = new MySqlCommand("SELECT state, color, product_name, product_price,save_date, save_time FROM tables WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
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

    return new Table(id);
}

    
    public static void DeleteTable(int id)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("DELETE FROM tables WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
    
    public static void AddProductToTable(int tableId, string productName, decimal productPrice, decimal amount)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("INSERT INTO tables (id, product_name, product_price, amount) VALUES (@tableId, @productName, @productPrice, @amount)", connection);
        cmd.Parameters.AddWithValue("@tableId", tableId);
        cmd.Parameters.AddWithValue("@productName", productName);
        cmd.Parameters.AddWithValue("@productPrice", productPrice);
        cmd.Parameters.AddWithValue("@amount", amount);
        cmd.ExecuteNonQuery();
    }
    
    public static DataTable GetTableProducts(int tableId)
    {
        var dt = new DataTable();

        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("SELECT product_name, product_price, amount FROM tables WHERE id = @tableId", connection);
        cmd.Parameters.AddWithValue("@tableId", tableId);
        using var adapter = new MySqlDataAdapter(cmd);
    
        adapter.Fill(dt);

        return dt;
    }
    
    public static void UpdateTableState(int tableId, string state, string color)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("UPDATE tables SET state = @state, color = @color WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", tableId);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@color", color);

                cmd.ExecuteNonQuery();
            }
        }
    }
}