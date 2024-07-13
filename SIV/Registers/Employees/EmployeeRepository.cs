using System.Data;
using MySql.Data.MySqlClient;

namespace SIV.Registers.Employees;

public class EmployeeRepository
{
    // Método que retorna todos os funcionários
    public DataTable GetAllEmployees()
    {
        var dt = new DataTable(); // DataTable é uma classe que representa uma tabela na memória
        using (var connection = ConnectionManager.GetConnection())
        {
            var sql = "SELECT * FROM employees ORDER BY name";
            using (var cmd = new MySqlCommand(sql, connection))
            {
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta
                }
            }
        }

        return dt;
    }
    
    // Método que verifica se o CPF já existe
    public bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        if (cpf == oldCpf)
        {
            return true; // Se o CPF for igual ao CPF antigo, não é necessário verificar se o CPF já existe
        }

        using (var connection = ConnectionManager.GetConnection())
        {
            var sql = "SELECT COUNT(*) FROM employees WHERE cpf = @cpf";
            using (var cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@cpf", cpf);
                var result = (long)cmd.ExecuteScalar(); // ExecuteScalar retorna a primeira coluna da primeira linha do resultado da consulta
                return result == 0; // Se result for 0, significa que o CPF não existe
            }
        }
    }

    // Método que salva um funcionário
    public void SaveEmployee(string name, string cpf, string phone, string job, string address, byte[] photo)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            var sql = 
                "INSERT INTO employees (name, cpf, phone, job, address, date, photo) " +
                "VALUES (@name, @cpf, @phone, @job, @address, curDate(), @photo)";

            using (var cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@job", job);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@photo", photo);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public void UpdateEmployee(string id, string name, string cpf, string phone, string job, string address, byte[] photo, bool imageChanged)
    {
        using (var connection = ConnectionManager.GetConnection())
        {
            var sql = 
                $"UPDATE employees SET name = @name, cpf = @cpf, phone = @phone, job = @job, address = @address" +
                $"{(imageChanged ? ", photo = @photo" : "")} WHERE id = @id";

            using (var cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@job", job);
                cmd.Parameters.AddWithValue("@address", address);

                if (imageChanged) // Se a imagem foi alterada, atualiza a foto
                {
                    cmd.Parameters.AddWithValue("@photo", photo);
                }

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteEmployee(string id)
    {
        using (var connection = ConnectionManager.GetConnection()) // Uso do bloco using para garantir que a conexão será fechada após o uso
        {
            var sql = "DELETE FROM employees WHERE id = @id";

            using (var cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}