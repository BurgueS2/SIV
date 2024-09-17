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
            using var cmd = new MySqlCommand("SELECT * FROM Users ORDER BY name", connection);
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
                "INSERT INTO Users (Name, Password, JobTitle, AccessLevel, IsActive, UserPermissions)" + 
                "VALUES (@Name, @Password, @Job, @AccessLevel, @Active, @Permissions)", connection);
            
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
                "UPDATE users SET Name = @Name, Password = @Password, JobTitle = @Job, AccessLevel = @AccessLevel," + 
                "IsActive = @Active, UserPermissions = @Permissions WHERE Id = @Id", connection);
            
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
    /// <param name="id">ID do usuário a ser excluído. </param>
    public static void DeleteUser(string id)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM users WHERE Id = @Id", connection);
            
            cmd.Parameters.AddWithValue("@id", id);
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
                "SELECT Id, Name, Password, JobTitle, AccessLevel, IsActive, UserPermissions FROM Users WHERE Name = @Name AND Password = @Password", connection);
            
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Password", password);

            using var reader = cmd.ExecuteReader();
            
            if (reader.Read()) // Se o usuário existir, retorna um objeto User
            {
                return new User
                {
                    Id = reader.GetInt32("Id").ToString(),
                    Name = reader.GetString("Name"),
                    Password = reader.GetString("Password"),
                    Job = reader.GetString("JobTitle"),
                    Access = reader.GetString("AccessLevel"),
                    Active = reader.GetString("IsActive"),
                    Permissions = reader.GetString("UserPermissions").Split(',').ToList()
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
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE User = @User AND Password = @Password", connection);
            
            cmd.Parameters.AddWithValue("@User", user);
            cmd.Parameters.AddWithValue("@Password", password);
            
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
            using var cmd = new MySqlCommand("SELECT * FROM Users WHERE Name LIKE @Name", connection);
            
            cmd.Parameters.AddWithValue("@Name", "%" + userName + "%"); // Procura por nomes que contenham a string fornecida
            
            using var reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")).ToString(),
                    Name = reader.GetString(reader.GetOrdinal("Name"))
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
        cmd.Parameters.AddWithValue("@Name", user.Name);
        cmd.Parameters.AddWithValue("@Password", user.Password);
        cmd.Parameters.AddWithValue("@Job", user.Job);
        cmd.Parameters.AddWithValue("@AccessLevel", user.Access);
        cmd.Parameters.AddWithValue("@Active", user.Active);
        cmd.Parameters.AddWithValue("@Permissions", string.Join(",", user.Permissions));
    }
}