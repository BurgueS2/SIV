using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Models;

namespace SIV.Repositories;

public class UserRepository
{
    public DataTable GetAllUsers()
    {
        var dt = new DataTable();
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT * FROM users ORDER BY name", connection))
        using (var da = new MySqlDataAdapter(cmd))
        {
            da.Fill(dt);
        }

        return dt;
    }
    
    public void SaveUser(string name, string password, string job, string access, string active, List<string> permissions)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("INSERT INTO users (name, password, job, access, active, permissions) VALUES (@name, @password, @job, @access, @active, @permissions)", connection))
        {
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@job", job);
            cmd.Parameters.AddWithValue("@access", access);
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@permissions", string.Join(",", permissions));

            cmd.ExecuteNonQuery();
        }
    }
    
    public void UpdateUser(string id, string name, string password, string job, string access, string active, List<string> permissions)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("UPDATE users SET name = @name, password = @password, job = @job, access = @access, active = @active, permissions = @permissions WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@job", job);
            cmd.Parameters.AddWithValue("@access", access);
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@permissions", string.Join(",", permissions));

            cmd.ExecuteNonQuery();
        }
    }
    
    public void DeleteUser(string id)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("DELETE FROM users WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
    
    public User UserPermition(string name, string password)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT id, name, password, job, access, active, permissions FROM users WHERE name = @name AND password = @password", connection))
        {
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new User
                    {
                        Id = reader.GetInt32("id").ToString(),
                        Name = reader.GetString("name"),
                        Password = reader.GetString("password"),
                        Job = reader.GetString("job"),
                        Access = reader.GetString("access"),
                        Active = reader.GetString("active"),
                        Permissions = reader.GetString("permissions").Split(',').ToList()
                    };
                }
            }
        }

        return null; // Retorna null se o usuário não existir
    }
    
    public bool VerifyUserExistence(string user ,string password)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE user = @user AND password = @password", connection))
        {
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);
            
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            return result > 0; // Se result for maior que 0, significa que o usuário existe
        }
    }
}