using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;

namespace SIV.Repositories;

/// <summary>
/// Classe responsável pela manipulação de dados dos funcionários no banco de dados.
/// Oferece métodos para realizar operações CRUD (Create, Read, Update, Delete) sobre a tabela funcionários.
/// </summary>
public class EmployeeRepository
{
    /// <summary>
    /// Retorna todos os funcionários cadastrados no banco de dados.
    /// </summary>
    /// <returns>Um DataTable contendo todos funcionários.</returns>
    public DataTable GetAllEmployees()
    {
        var dt = new DataTable(); // DataTable é uma classe que representa uma tabela na memória
        using (var connection = ConnectionManager.GetConnection())
        {
            using (var cmd = new MySqlCommand("SELECT * FROM employees ORDER BY name", connection))
            {
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta
                }
            }
        }

        return dt;
    }
    
    /// <summary>
    /// Verifica se um CPF já está cadastrado no banco de dados, exceto durante uma atualização.
    /// </summary>
    /// <param name="cpf">O CPF do funcionário a ser verificado.</param>
    /// <param name="oldCpf">O CPF antigo do funcionário, usado em operações de atualização.</param>
    /// <returns>True se o CPF não existir ou for o mesmo do CPF antigo, caso contrário, false.</returns>
    public bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        if (cpf == oldCpf)
        {
            return true; // Se o CPF for igual ao CPF antigo, não é necessário verificar se o CPF já existe
        }

        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM employees WHERE cpf = @cpf", connection))
        {
            cmd.Parameters.AddWithValue("@cpf", cpf);
            var result = (long)cmd.ExecuteScalar(); // ExecuteScalar retorna a primeira coluna da primeira linha do resultado da consulta
            
            return result == 0; // Se result for 0, significa que o CPF não existe
        }
    }

    /// <summary>
    /// Salva um novo funcionário no banco de dados.
    /// </summary>
    /// <param name="name">Nome do funcionário.</param>
    /// <param name="cpf">CPF do funcionário.</param>
    /// <param name="phone">Telefone do funcionário.</param>
    /// <param name="job">Cargo do funcionário.</param>
    /// <param name="address">Endereço do funcionário.</param>
    /// <param name="photo">Foto do funcionário em formato de array de bytes.</param>
    public void SaveEmployee(string name, string cpf, string phone, string job, string address, byte[] photo)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("INSERT INTO employees (name, cpf, phone, job, address, date, photo) VALUES (@name, @cpf, @phone, @job, @address, curDate(), @photo)", connection))
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
    
    /// <summary>
    /// Atualiza os dados de um funcionário existente no banco de dados.
    /// </summary>
    /// <param name="id">ID do funcionário a ser atualizado.</param>
    /// <param name="name">Novo nome do funcionário</param>
    /// <param name="cpf">Novo CPF do funcionário.</param>
    /// <param name="phone">Novo telefone do funcionário.</param>
    /// <param name="job">Novo cargo do funcionário.</param>
    /// <param name="address">Novo endereço do funcionário.</param>
    /// <param name="photo">Nova foto do funcionário em formato de array de bytes.</param>
    /// <param name="imageChanged">Indica se a imagem foi alterada (true) ou não (false).</param>
    public void UpdateEmployee(string id, string name, string cpf, string phone, string job, string address, byte[] photo, bool imageChanged)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("UPDATE employees SET name = @name, cpf = @cpf, phone = @phone, job = @job, address = @address" +
        $"{(imageChanged ? ", photo = @photo" : "")} WHERE id = @id", connection))
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

    /// <summary>
    /// Exclui um funcionário do banco de dados.
    /// </summary>
    /// <param name="id">ID do funcionário a ser excluído.</param>
    public void DeleteEmployee(string id)
    {
        using (var connection = ConnectionManager.GetConnection()) // Uso do bloco using para garantir que a conexão será fechada após o uso
        using (var cmd = new MySqlCommand("DELETE FROM employees WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
    
    /// <summary>
    /// Busca clientes pelo nome.
    /// </summary>
    /// <param name="name">Nome do cliente a ser buscado.</param>
    /// <returns>Um <c>DataTable</c> contendo os clientes que correspondem ao critério de busca.</returns>
    public DataTable SearchByName(string name)
    {
        var dt = new DataTable();
        
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT * FROM employees WHERE name LIKE @name ORDER BY name", connection))
        {
            cmd.Parameters.AddWithValue("@name", "%" + name + "%"); // Adiciona o caractere % para buscar qualquer nome que contenha o valor informado
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }

        return dt;
    }
}