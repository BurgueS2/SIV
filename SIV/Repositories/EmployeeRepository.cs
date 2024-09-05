using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>EmployeeRepository</c> é responsável por realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados para a entidade Employee.
/// </summary>
public static class EmployeeRepository
{
    /// <summary>
    /// Retorna todos os funcionários cadastrados no banco de dados.
    /// </summary>
    /// <returns>Um <c>DataTable</c> contendo todos os funcionários.</returns>
    public static DataTable GetAllEmployees()
    {
        try
        {
            var dt = new DataTable();
            
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM employees ORDER BY name", connection);
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os funcionários");
            return null;
        }
    }
    
    /// <summary>
    /// Verifica se um CPF já está cadastrado no banco de dados, exceto durante uma atualização.
    /// </summary>
    /// <param name="cpf">O CPF do funcionário a ser verificado.</param>
    /// <param name="oldCpf">O CPF antigo do funcionário, usado em operações de atualização.</param>
    /// <returns>Retorna <c>True</c> se o CPF não existir ou for o mesmo do CPF antigo, caso contrário, <c>False</c>.</returns>
    public static bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        try
        {
            if (cpf == oldCpf)
            {
                return true; // Se o CPF for igual ao CPF antigo, não é necessário verificar se o CPF já existe
            }

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM employees WHERE cpf = @cpf", connection);
            
            cmd.Parameters.AddWithValue("@cpf", cpf);
            
            var result = (long)cmd.ExecuteScalar(); // ExecuteScalar retorna a primeira coluna da primeira linha do resultado da consulta
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
    /// Salva um novo funcionário no banco de dados.
    /// </summary>
    /// <param name="employee">O objeto <c>Employee</c> contendo os dados do funcionário a ser salvo.</param>
    public static void SaveEmployee(Employee employee)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO employees (name, cpf, phone, job, address, date, photo)" + 
                "VALUES (@name, @cpf, @phone, @job, @address, curDate(), @photo)", connection);
            
            AddEmployeeParameters(cmd, employee);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o funcionário");
        }
    }
    
    /// <summary>
    /// Atualiza os dados de um funcionário existente no banco de dados.
    /// </summary>
    /// <param name="employee">O objeto <c>Employee</c> contendo os dados atualizados do funcionário.</param>
    /// <param name="imageChanged">Indica se a imagem foi alterada (true) ou não (false).</param>
    public static void UpdateEmployee(Employee employee, bool imageChanged)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "UPDATE employees SET name = @name, cpf = @cpf, phone = @phone, job = @job, address = @address" +
                $"{(imageChanged ? ", photo = @photo" : "")} WHERE id = @id", connection);
            
            cmd.Parameters.AddWithValue("@id", employee.Id);
            AddEmployeeParameters(cmd, employee);

            if (imageChanged) // Se a imagem foi alterada, atualiza a foto
            {
                cmd.Parameters.AddWithValue("@photo", employee.Photo);
            }

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o funcionário");
        }
    }

    /// <summary>
    /// Exclui um funcionário do banco de dados.
    /// </summary>
    /// <param name="employee">O objeto <c>Employee</c> contendo o ID do funcionário a ser excluído.</param>
    public static void DeleteEmployee(Employee employee)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM employees WHERE id = @id", connection);
            
            cmd.Parameters.AddWithValue("@id", employee.Id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o funcionário");
        }
    }
    
    /// <summary>
    /// Busca funcionários pelo nome.
    /// </summary>
    /// <param name="name">Nome do funcionário a ser buscado.</param>
    /// <returns>Um <c>DataTable</c> contendo os funcionários que correspondem ao critério de busca.</returns>
    public static DataTable SearchByName(string name)
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM employees WHERE name LIKE @name ORDER BY name", connection);
            
            cmd.Parameters.AddWithValue("@name", "%" + name + "%"); // Adiciona o caractere % para buscar qualquer nome que contenha o valor informado
            
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "pesquisar funcionários");
            return null;
        }
    }

    /// <summary>
    /// Adiciona os parâmetros de um objeto <c>Employee</c> a um comando MySql.
    /// </summary>
    /// <param name="cmd">O comando MySql ao qual os parâmetros serão adicionados.</param>
    /// <param name="employee">O objeto <c>Employee</c> contendo os dados dos parâmetros.</param>
    private static void AddEmployeeParameters(MySqlCommand cmd, Employee employee)
    {
        cmd.Parameters.AddWithValue("@name", employee.Name);
        cmd.Parameters.AddWithValue("@cpf", employee.Cpf);
        cmd.Parameters.AddWithValue("@phone", employee.Phone);
        cmd.Parameters.AddWithValue("@job", employee.Job);
        cmd.Parameters.AddWithValue("@address", employee.Address);
        cmd.Parameters.AddWithValue("@photo", employee.Photo);
    }
}