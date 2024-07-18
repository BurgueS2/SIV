using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;

namespace SIV.Registers.Jobs;

/// <summary>
/// A classe é responsável pela manipulação de dados relacionados a cargos (jobs) no banco de dados.
/// Ela utiliza o MySQL como sistema de gerenciamento de banco de dados.
/// </summary>
public class JobRepository
{
    /// <summary>
    /// Recupera todos os cargos do banco de dados e os retorna em um `DataTable`.
    /// </summary>
    /// <returns>`DataTable` contendo todos os cargos.</returns>
    public DataTable GetAllJobs()
    {
        var dt = new DataTable();
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT * FROM job ORDER BY name", connection))
        using (var da = new MySqlDataAdapter(cmd))
        {
            da.Fill(dt);
        }

        return dt;
    }
    
    /// <summary>
    /// Insere um novo cargo no banco de dados.
    /// </summary>
    /// <param name="name">Nome do cargo a ser inserido.</param>
    public void SaveJob(string name)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("INSERT INTO job (name) VALUES (@name)", connection))
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
    public void UpdateJob(string id, string name)
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
    public void DeleteJob(string id)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("DELETE FROM job WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.ExecuteNonQuery();
        }
    }
}