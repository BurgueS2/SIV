using System;
using System.Collections.Generic;
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
            using (var cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS tables (id INT PRIMARY KEY, state TEXT, items TEXT)", connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void SaveTable(Table table)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("INSERT INTO tables (id, state, items, color, open_date, open_time, stay_hours) VALUES (@id, @state, @items, @color, @open_date, @open_time, @stay_hours) ON DUPLICATE KEY UPDATE state=@state, items=@items, color=@color, open_date=@open_date, open_time=@open_time, stay_hours=@stay_hours", connection))
            {
                cmd.Parameters.AddWithValue("@id", table.Id);
                cmd.Parameters.AddWithValue("@state", table.State);
                cmd.Parameters.AddWithValue("@items", string.Join(",", table.Items));
                cmd.Parameters.AddWithValue("@color", table.Color);
                cmd.Parameters.AddWithValue("@open_date", table.OpenDate.HasValue ? (object)table.OpenDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@open_time", table.OpenTime.HasValue ? (object)table.OpenTime.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@stay_hours", table.StayHours.HasValue ? (object)table.StayHours.Value : DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static Table LoadTables(int id)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("SELECT state, items, color, open_date, open_time, stay_hours FROM tables WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var table = new Table(id)
                        {
                            State = reader["state"].ToString(),
                            Items = new List<string>(reader["items"].ToString().Split(',')),
                            Color = reader["color"].ToString(),
                            OpenDate = reader["open_date"] != DBNull.Value ? (DateTime?)reader["open_date"] : null,
                            OpenTime = reader["open_time"] != DBNull.Value ? (TimeSpan?)reader["open_time"] : null,
                            StayHours = reader["stay_hours"] != DBNull.Value ? (TimeSpan?)reader["stay_hours"] : null
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
}