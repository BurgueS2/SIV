using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;

namespace SIV.Repositories;

/// <summary>
/// A classe é responsável por gerenciar as operações de banco de dados relacionadas aos clientes.
/// Inclui operações como buscar, salvar, atualizar e deletar clientes no banco de dados.
/// </summary>
public class ClientRepository
{
    /// <summary>
    /// Obtém todos os clientes do banco de dados.
    /// </summary>
    /// <returns>Um <c>DataTable</c> contendo todos os clientes.</returns>
    public DataTable GetAllClients()
    {
        var dt = new DataTable();
        
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT * FROM clients ORDER BY name", connection))
        {
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta
            }
        }

        return dt;
    }
    
    /// <summary>
    /// Verifica a existência de um CPF no banco de dados, considerando um CPF antigo para operações de atualização.
    /// </summary>
    /// <param name="cpf">O CPF a ser verificado.</param>
    /// <param name="oldCpf">O CPF antigo do cliente, usado em operações de atualização.</param>
    /// <returns>True se o CPF não existir ou for o mesmo do CPF antigo, caso contrário, false.</returns>
    public bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        if (cpf == oldCpf)
        {
            return true; // Se o CPF for igual ao CPF antigo, não é necessário verificar se o CPF já existe
        }

        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE cpf = @cpf", connection))
        {
            cmd.Parameters.AddWithValue("@cpf", cpf);
            var result = (long)cmd.ExecuteScalar(); // ExecuteScalar retorna a primeira coluna da primeira linha do resultado da consulta
            
            return result == 0; // Se result for 0, significa que o CPF não existe
        }
    }
    
    /// <summary>
    /// Salva um novo cliente no banco de dados.
    /// </summary>
    /// <param name="code">Código do cliente.</param>
    /// <param name="name">Nome do cliente.</param>
    /// <param name="cpf">CPF do cliente.</param>
    /// <param name="openAmount">Quantia em aberto do cliente.</param>
    /// <param name="status">Status do cliente (ativo/inativo).</param>
    /// <param name="phone">Telefone do cliente.</param>
    /// <param name="email">Email do cliente.</param>
    /// <param name="address">Endereço do cliente.</param>
    public void SaveClient(string code, string name, string cpf,string openAmount, bool status, string phone, string email, string address)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("INSERT INTO clients (code, name, cpf, openAmount, status, phone, email, address, date) VALUES (@code, @name, @cpf,@openAmount, @status, @phone, @email, @address, curDate())", connection))
        {
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@openAmount", openAmount);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.ExecuteNonQuery();
        }
    }
    
    /// <summary>
    /// Atualiza os dados de um cliente existente no banco de dados.
    /// </summary>
    /// <param name="id">ID do cliente a ser atualizado.</param>
    /// <param name="name">Novo nome do cliente.</param>
    /// <param name="cpf">Novo CPF do cliente.</param>
    /// <param name="openAmount">Nova quantia em aberto do cliente.</param>
    /// <param name="status">Novo status do cliente (ativo/inativo).</param>
    /// <param name="phone">Novo telefone do cliente.</param>
    /// <param name="email">Novo email do cliente.</param>
    /// <param name="address">Novo endereço do cliente.</param>
    public void UpdateClient(string id , string name, string cpf,string openAmount, bool status, string phone, string email, string address)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand($"UPDATE clients SET  name = @name, cpf = @cpf, openAmount = @openAmount, status = @status, phone = @phone, email = @email, address = @address WHERE id = @id", connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@openAmount", openAmount);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.ExecuteNonQuery();
        }
    }
    
    /// <summary>
    /// Exclui um cliente do banco de dados.
    /// </summary>
    /// <param name="id">ID do cliente a ser excluído.</param>
    public void DeleteClient(string id)
    {
        using (var connection = ConnectionManager.GetConnection()) // Uso do bloco using para garantir que a conexão será fechada após o uso
        using (var cmd = new MySqlCommand("DELETE FROM clients WHERE id = @id", connection))
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
        using (var cmd = new MySqlCommand("SELECT * FROM clients WHERE name LIKE @name ORDER BY name", connection))
        {
            cmd.Parameters.AddWithValue("@name", "%" + name + "%"); // Adiciona o caractere % para buscar qualquer nome que contenha o valor informado
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }

        return dt;
    }
    
    /// <summary>
    /// Busca clientes pelo CPF.
    /// </summary>
    /// <param name="cpf">CPF do cliente a ser buscado.</param>
    /// <returns>Um <c>DataTable</c> contendo os clientes que correspondem ao critério de busca.</returns>
    public DataTable SearchByCpf(string cpf)
    {
        var dt = new DataTable();
        
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT * FROM clients WHERE cpf LIKE @cpf ORDER BY name", connection))
        {
            cmd.Parameters.AddWithValue("@cpf", "%" + cpf + "%"); // Adiciona o caractere % para buscar qualquer CPF que contenha o valor informado
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }

        return dt;
    }

    /// <summary>
    /// Verifica a existência de um email no banco de dados.
    /// </summary>
    /// <param name="email">O email a ser verificado.</param>
    /// <returns>True se o email já existir, caso contrário, false.</returns>
    public bool VerifyEmailExisting(string email)
    {
        using (var connection = ConnectionManager.GetConnection())
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM clients WHERE LOWER(email) = LOWER(@email)", connection))
        {
            cmd.Parameters.AddWithValue("@email", email);
            var result = Convert.ToInt32(cmd.ExecuteScalar());
            
            return result > 0; // Se result for maior que 0, significa que o email já existe
        }
    }
}