using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>JobRepository</c> é responsável por realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados para a entidade Job.
/// </summary>
public static class JobRepository
{
    /// <summary>
    /// Recupera todos os cargos do banco de dados e os retorna em um <c>DataTable</c>.
    /// </summary>
    /// <returns>Um <c>DataTable</c> contendo todos os cargos.</returns>
    public static DataTable GetAllJobs()
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM Jobs ORDER BY Name", connection);
            using var da = new MySqlDataAdapter(cmd);
            
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os cargos");
            return null;
        }
    }
    
    /// <summary>
    /// Insere um novo cargo no banco de dados.
    /// </summary>
    /// <param name="job">O objeto <c>Job</c> contendo os dados do cargo a ser inserido.</param>
    public static void SaveJob(Job job)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("INSERT INTO Jobs (Name, Date) VALUES (@Name, curDate())", connection);
            
            cmd.Parameters.AddWithValue("@Name", job.Name);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o cargo");
        }
    }
    
    /// <summary>
    /// Atualiza os dados de um cargo existente no banco de dados.
    /// </summary>
    public static void UpdateJob(Job job)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("UPDATE Jobs SET Name = @Name WHERE Id = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", job.Id);
            cmd.Parameters.AddWithValue("@Name", job.Name);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o cargo");
        }
    }
    
    /// <summary>
    /// Exclui um cargo do banco de dados.
    /// </summary>
    /// <param name="id">ID do cargo a ser excluído.</param>
    public static void DeleteJob(string id)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM Jobs WHERE Id = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o cargo");
        }
    }
    
    /// <summary>
    /// Verifica se um cargo especificado pelo nome já existe no banco de dados.
    /// </summary>
    /// <param name="name">O nome do cargo a ser verificado.</param>
    /// <returns>Retorna <c>true</c> se o cargo já existe no banco de dados, caso contrário, retorna <c>false</c>.</returns>
    public static bool JobExists(string name)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Jobs WHERE LOWER(Name) = LOWER(@Name)", connection);
            
            cmd.Parameters.AddWithValue("@Name", name);
            
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            
            return result > 0; // Se result for maior que 0, significa que o cargo já existe, ignorando maiúsculas e minúsculas
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "verificar a existência do cargo");
            return false;
        }
    }
}