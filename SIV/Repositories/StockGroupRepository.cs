using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>StockGroupRepository</c> é responsável por realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados para a entidade StockGroup.
/// </summary>
public static class StockGroupRepository
{
    /// <summary>
    /// Obtém todos os grupos de estoque do banco de dados.
    /// </summary>
    /// <returns>Um <c>DataTable</c> contendo todos os grupos de estoque.</returns>
    public static DataTable GetAllStockGroup()
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM StockGroups ORDER BY Name", connection);
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
    /// Salva um novo grupo de estoque no banco de dados.
    /// </summary>
    /// <param name="stock">O objeto <c>Stock</c> contendo os dados do grupo de estoque a ser salvo.</param>
    public static void SaveStockGroup(Stock stock)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("INSERT INTO StockGroups (Name, Date) VALUES (@Name, curDate())", connection);

            cmd.Parameters.AddWithValue("@Name", stock.Name);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o grupo de estoque");
        }
    }
    
    /// <summary>
    /// Atualiza os dados de um grupo de estoque existente no banco de dados.
    /// </summary>
    /// <param name="stock">O objeto <c>Stock</c> contendo os dados atualizados do grupo de estoque.</param>
    public static void UpdateStockGroup(Stock stock)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("UPDATE StockGroups SET Name = @Name WHERE Id = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", stock.Id);
            cmd.Parameters.AddWithValue("@Name", stock.Name);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o grupo de estoque");
        }
    }
    
    /// <summary>
    /// Exclui um grupo de estoque do banco de dados.
    /// </summary>
    /// <param name="id">O ID do grupo de estoque a ser excluído.</param>
    public static void DeleteStockGroup(string id)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM StockGroups WHERE Id = @Id", connection);
            
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o grupo de estoque");
        }
    }
    
    /// <summary>
    /// Busca um grupo de estoque pelo nome.
    /// </summary>
    /// <param name="name">Nome do grupo a ser buscado.</param>
    /// <returns>Um <c>DataTable</c> contendo os grupos que correspondem ao critério de busca.</returns>
    public static DataTable SearchByName(string name)
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM StockGroups WHERE Name LIKE @Name ORDER BY Name", connection);
            
            cmd.Parameters.AddWithValue("@Name", "%" + name + "%"); // Adiciona o caractere % para buscar qualquer nome que contenha o valor informado
            
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "pesquisar os grupos de estoque");
            return null;
        }
    }
}