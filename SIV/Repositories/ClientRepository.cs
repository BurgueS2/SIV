using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>ClientRepository</c> é responsável por realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados para a entidade Client.
/// </summary>
public static class ClientRepository
{
    /// <summary>
    /// Obtém todos os clientes do banco de dados.
    /// </summary>
    /// <returns>Um <c>DataTable</c> contendo todos os clientes.</returns>
    public static DataTable GetAllClients()
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM clients ORDER BY name", connection);
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os dados dos clientes");
            return null;
        }
    }
    
    /// <summary>
    /// Verifica se um CPF já está cadastrado no banco de dados, exceto durante uma atualização.
    /// </summary>
    /// <param name="cpf">O CPF do cliente a ser verificado.</param>
    /// <param name="oldCpf">O CPF antigo do cliente, usado em operações de atualização.</param>
    /// <returns>Retorna <c>True</c> se o CPF não existir ou for o mesmo do CPF antigo, caso contrário, <c>False</c>.</returns>
    public static bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE cpf = @cpf AND cpf != @oldCpf", connection);
            
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@oldCpf", oldCpf);
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            
            return result > 0;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "verificar a existência do CPF");
            return false;
        }
    }
    
    /// <summary>
    /// Salva um novo cliente no banco de dados.
    /// </summary>
    /// <param name="client">O objeto <c>Client</c> contendo os dados do cliente a ser salvo.</param>
    public static void SaveClient(Client client)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO clients (name, cpf, status, phone, email, address, reference_point, observation, sex, date) " + 
                "VALUES (@name, @cpf, @status, @phone, @email, @address, @reference_point, @observation, sex, curDate())", connection);
            
            AddClientParameters(cmd, client);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o cliente");
        }
    }
    
    /// <summary>
    /// Atualiza os dados de um cliente existente no banco de dados.
    /// </summary>
    /// <param name="client">O objeto <c>Client</c> contendo os dados atualizados do cliente.</param>
    public static void UpdateClient(Client client)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "UPDATE clients SET  name = @name, cpf = @cpf, status = @status, phone = @phone, email = @email, address = @address, " +
                "reference_point = @reference_point, observation = @observation , sex = @sex WHERE id = @id", connection);
            
            cmd.Parameters.AddWithValue("@id", client.Id);
            AddClientParameters(cmd, client);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o cliente");
        }
    }
    
    /// <summary>
    /// Exclui um cliente do banco de dados.
    /// </summary>
    /// <param name="id">O ID do cliente a ser excluído.</param>
    public static void DeleteClient(string id)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM clients WHERE id = @id", connection);
            
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o cliente");
        }
    }
    
    /// <summary>
    /// Busca clientes pelo nome.
    /// </summary>
    /// <param name="name">Nome do cliente a ser buscado.</param>
    /// <returns>Um <c>DataTable</c> contendo os clientes que correspondem ao critério de busca.</returns>
    public static DataTable SearchByName(string name)
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM clients WHERE name LIKE @name ORDER BY name", connection);
            
            cmd.Parameters.AddWithValue("@name", "%" + name + "%"); // Adiciona o caractere % para buscar qualquer nome que contenha o valor informado
            
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "buscar os clientes");
            return null;
        }
    }
    
    /// <summary>
    /// Busca clientes pelo CPF.
    /// </summary>
    /// <param name="cpf">CPF do cliente a ser buscado.</param>
    /// <returns>Um <c>DataTable</c> contendo os clientes que correspondem ao critério de busca.</returns>
    public static DataTable SearchByCpf(string cpf)
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM clients WHERE cpf LIKE @cpf ORDER BY name", connection);
            
            cmd.Parameters.AddWithValue("@cpf", "%" + cpf + "%"); // Adiciona o caractere % para buscar qualquer CPF que contenha o valor informado
            
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "buscar os clientes");
            return null;
        }
    }
    
    /// <summary>
    /// Verifica se um email já está cadastrado no banco de dados.
    /// </summary>
    /// <param name="email">O email do cliente a ser verificado.</param>
    /// <returns> Retorna <c>True</c> se o email já existir, caso contrário, <c>False</c>.</returns>
    public static bool VerifyEmailExisting(string email)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE LOWER(email) = LOWER(@email)", connection);
            
            cmd.Parameters.AddWithValue("@email", email);
            
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            return result > 0; // Se result for maior que 0, significa que o email já existe
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "verificar a existência do email");
            return false;
        }
    }
    
    /// <summary>
    /// Adiciona os parâmetros de um objeto <c>Client</c> a um comando MySql.
    /// </summary>
    /// <param name="cmd">O comando MySql ao qual os parâmetros serão adicionados.</param>
    /// <param name="client">O objeto <c>Client</c> contendo os dados dos parâmetros.</param>
    private static void AddClientParameters(MySqlCommand cmd, Client client)
    {
        cmd.Parameters.AddWithValue("@name", client.Name);
        cmd.Parameters.AddWithValue("@cpf", client.Cpf);
        cmd.Parameters.AddWithValue("@status", client.Status);
        cmd.Parameters.AddWithValue("@phone", client.Phone);
        cmd.Parameters.AddWithValue("@email", client.Email);
        cmd.Parameters.AddWithValue("@address", client.Address);
        cmd.Parameters.AddWithValue("@reference_point", client.ReferencePoint);
        cmd.Parameters.AddWithValue("@observation", client.Observation);
        cmd.Parameters.AddWithValue("@sex", client.Sex);
    }
}