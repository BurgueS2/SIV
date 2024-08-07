using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;

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
    
    public void SaveUser(string name, string password)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("INSERT INTO users (name, password) VALUES (@name, @password)", connection))
        {
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            
            cmd.ExecuteNonQuery();
        }
    }
    
    public void UpdateUser(string id, string name, string password)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("UPDATE users SET name = @name, password = @password WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);

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
    
    public bool UserExists(string name)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE LOWER(name) = LOWER(@name)", connection))
        {
            cmd.Parameters.AddWithValue("@name", name);
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            
            return result > 0; // Se result for maior que 0, significa que o cargo já existe, ignorando maiúsculas e minúsculas
        }
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