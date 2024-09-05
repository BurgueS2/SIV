using System;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>UserRepository</c> é responsável por realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados para a entidade User.
/// </summary>
public static class UserRepository
{
    /// <summary>
    /// Obtém todos os usuários do banco de dados.
    /// </summary>
    /// <returns>Um <c>DataTable</c> contendo todos os usuários.</returns>
    public static DataTable GetAllUsers()
    {
        try
        {
            var dt = new DataTable();
            
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM users ORDER BY name", connection);
            using var da = new MySqlDataAdapter(cmd);
            
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os usuários");
            return null;
        }
    }
    
    /// <summary>
    /// Salva um novo usuário no banco de dados.
    /// </summary>
    /// <param name="user">O objeto <c>User</c> contendo os dados do usuário a ser salvo.</param>
    public static void SaveUser(User user)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO users (name, password, job, access, active, permissions)" + 
                "VALUES (@name, @password, @job, @access, @active, @permissions)", connection);
            
            AddUserParameters(cmd, user);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o usuário");
        }
    }
    
    /// <summary>
    /// Atualiza os dados de um usuário existente no banco de dados.
    /// </summary>
    /// <param name="user">O objeto <c>User</c> contendo os dados atualizados do usuário.</param>
    public static void UpdateUser(User user)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "UPDATE users SET name = @name, password = @password, job = @job, access = @access," + 
                "active = @active, permissions = @permissions WHERE id = @id", connection);
            
            AddUserParameters(cmd, user);
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o usuário");
        }
    }
    
    /// <summary>
    /// Exclui um usuário do banco de dados com base no ID fornecido.
    /// </summary>
    /// <param name="user">O objeto <c>User</c> contendo o ID do usuário a ser excluído. </param>
    public static void DeleteUser(User user)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM users WHERE id = @id", connection);
            
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o usuário");
        }
    }
    
    /// <summary>
    /// Obtém as permissões de um usuário com base no nome e senha.
    /// </summary>
    /// <param name="name">Nome do usuário.</param>
    /// <param name="password">Senha do usuário.</param>
    /// <returns>Um objeto <c>User</c> contendo as permissões do usuário, ou null se o usuário não existir.</returns>
    public static User UserPermission(string name, string password)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "SELECT id, name, password, job, access, active, permissions" +
                "FROM users WHERE name = @name AND password = @password", connection);
            
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = cmd.ExecuteReader();
            
            if (reader.Read()) // Se o usuário existir, retorna um objeto User
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

            return null; // Retorna null se o usuário não existir
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter as permissões do usuário");
            return null;
        }
    }
    
    /// <summary>
    /// Verifica se um usuário existe no banco de dados com base no nome e senha.
    /// </summary>
    /// <param name="user">Nome do usuário.</param>
    /// <param name="password">Senha do usuário.</param>
    /// <returns>Retorna <c>True</c> se o usuário existir, caso contrário, <c>False</c>.</returns>
    public static bool VerifyUserExistence(string user ,string password)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE user = @user AND password = @password", connection);
            
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);
            
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            return result > 0; // Se result for maior que 0, significa que o usuário existe
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "verificar a existência do usuário");
            return false;
        }
    }
    
    /// <summary>
    /// Obtém um usuário do banco de dados com base em uma busca aproximada pelo nome.
    /// </summary>
    /// <param name="userName">O nome do usuário a ser buscado.</param>
    /// <returns>Um objeto <c>User</c> contendo os dados do usuário, ou null se o usuário não existir.</returns>
    public static User GetUserByNameApproximate(string userName)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM users WHERE name LIKE @name", connection);
            
            cmd.Parameters.AddWithValue("@name", "%" + userName + "%"); // Procura por nomes que contenham a string fornecida
            
            using var reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")).ToString(),
                    Name = reader.GetString(reader.GetOrdinal("name"))
                };
            }

            return null;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter o usuário");
            return null;
        }
    }

    /// <summary>
    /// Adiciona os parâmetros de um objeto User a um comando MySql.
    /// </summary>
    /// <param name="cmd">O comando MySql ao qual os parâmetros serão adicionados.</param>
    /// <param name="user">O objeto <c>User</c> contendo os dados dos parâmetros.</param>
    private static void AddUserParameters(MySqlCommand cmd, User user)
    {
        cmd.Parameters.AddWithValue("@name", user.Name);
        cmd.Parameters.AddWithValue("@password", user.Password);
        cmd.Parameters.AddWithValue("@job", user.Job);
        cmd.Parameters.AddWithValue("@access", user.Access);
        cmd.Parameters.AddWithValue("@active", user.Active);
        cmd.Parameters.AddWithValue("@permissions", string.Join(",", user.Permissions));
    }
}