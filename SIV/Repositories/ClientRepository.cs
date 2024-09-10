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
            using var cmd = new MySqlCommand("SELECT * FROM Clients ORDER BY Name", connection);
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
    public static bool VerifyCpfExistence(string cpf)
    {
        try
        { 
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Clients WHERE CPF = @Cpf", connection);
            
            cmd.Parameters.AddWithValue("@Cpf", cpf);

            var result = Convert.ToInt32(cmd.ExecuteScalar()); // ExecuteScalar retorna a primeira coluna da primeira linha do resultado da consulta
            return result == 0; // Se result for 0, significa que o CPF não existe
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
                "INSERT INTO Clients (Name, Cpf, Status, Phone, Email, Address, ReferencePoint, Observation, Sex, CreationDate) " + 
                "VALUES (@Name, @Cpf, @Status, @Phone, @Email, @Address, @ReferencePoint, @Observation, @Sex, curDate())", connection);
            
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
                "UPDATE Clients SET  Name = @Name, CPF = @Cpf, Status = @Status, Phone = @Phone, Email = @Email, Address = @Address, " +
                "ReferencePoint = @ReferencePoint, Observation = @Observation , Sex = @Sex WHERE Id = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", client.Id);
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
            using var cmd = new MySqlCommand("DELETE FROM Clients WHERE Id = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", id);
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
            using var cmd = new MySqlCommand("SELECT * FROM Clients WHERE Name LIKE @Name ORDER BY Name", connection);
            
            cmd.Parameters.AddWithValue("@Name", "%" + name + "%"); // Adiciona o caractere % para buscar qualquer nome que contenha o valor informado
            
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
            using var cmd = new MySqlCommand("SELECT * FROM Clients WHERE CPF LIKE @Cpf ORDER BY Name", connection);
            
            cmd.Parameters.AddWithValue("@Cpf", "%" + cpf + "%"); // Adiciona o caractere % para buscar qualquer CPF que contenha o valor informado
            
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
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM Clients WHERE LOWER(Email) = LOWER(@Email)", connection);
            
            cmd.Parameters.AddWithValue("@Email", email);
            
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
        cmd.Parameters.AddWithValue("@Name", client.Name);
        cmd.Parameters.AddWithValue("@Cpf", client.Cpf);
        cmd.Parameters.AddWithValue("@Status", client.Status);
        cmd.Parameters.AddWithValue("@Phone", client.Phone);
        cmd.Parameters.AddWithValue("@Email", client.Email);
        cmd.Parameters.AddWithValue("@Address", client.Address);
        cmd.Parameters.AddWithValue("@ReferencePoint", client.ReferencePoint);
        cmd.Parameters.AddWithValue("@Observation", client.Observation);
        cmd.Parameters.AddWithValue("@Sex", client.Sex);
    }
}