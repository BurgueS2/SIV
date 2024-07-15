using System.Data;
using MySql.Data.MySqlClient;

namespace SIV.Registers.Jobs;

public class JobRepository
{
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
    
    public void SaveJob(string name)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("INSERT INTO job (name) VALUES (@name)", connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public void UpdateJob(string id, string name)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("UPDATE job SET name = @name WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public void DeleteJob(string id)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("DELETE FROM job WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
}