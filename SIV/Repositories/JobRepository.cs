using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;

namespace SIV.Repositories;

/// <summary>
/// A classe é responsável pela manipulação de dados relacionados a cargos (jobs) no banco de dados.
/// Ela utiliza o MySQL como sistema de gerenciamento de banco de dados.
/// </summary>
public class JobRepository
{
    /// <summary>
    /// Recupera todos os cargos do banco de dados e os retorna em um 'DataTable'.
    /// </summary>
    public static DataTable GetAllJobs()
    {
        var dt = new DataTable();
        
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT * FROM job ORDER BY name", connection))
        {
            using (var da = new MySqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
        }

        return dt;
    }
    
    /// <summary>
    /// Insere um novo cargo no banco de dados.
    /// </summary>
    /// <param name="name">Nome do cargo a ser inserido.</param>
    public static void SaveJob(string name)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("INSERT INTO job (name, date) VALUES (@name, curDate())", connection))
        {
            cmd.Parameters.AddWithValue("@name", name);
            
            cmd.ExecuteNonQuery();
        }
    }
    
    /// <summary>
    /// Atualiza o nome de um cargo existente no banco de dados.
    /// </summary>
    /// <param name="id">ID do cargo a ser atualizado.</param>
    /// <param name="name">Novo nome para o cargo.</param>
    public static void UpdateJob(string id, string name)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("UPDATE job SET name = @name WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);

            cmd.ExecuteNonQuery();
        }
    }
    
    /// <summary>
    /// Exclui um cargo do banco de dados.
    /// </summary>
    /// <param name="id">ID do cargo a ser excluído.</param>
    public static void DeleteJob(string id)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("DELETE FROM job WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
    
    /// <summary>
    /// Verifica se um cargo especificado pelo nome já existe no banco de dados.
    /// </summary>
    /// <param name="name">Nome do cargo a ser verificado.</param>
    /// <returns>Retorna 'true' se o cargo já existe no banco de dados, caso contrário, retorna 'false'.</returns>
    public static bool JobExists(string name)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM job WHERE LOWER(name) = LOWER(@name)", connection))
        {
            cmd.Parameters.AddWithValue("@name", name);
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            
            return result > 0; // Se result for maior que 0, significa que o cargo já existe, ignorando maiúsculas e minúsculas
        }
    }
}