using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;

namespace SIV.Repositories;

/// <summary>
/// A classe <c>ProductRepository</c> é responsável por realizar operações de CRUD (Create, Read, Update, Delete) no banco de dados para a entidade Product.
/// </summary>
public static class ProductRepository
{
    /// <summary>
    /// Obtém todos os produtos do banco de dados.
    /// </summary>
    /// <returns>Um <c>DataTable</c> contendo todos os produtos.</returns>
    public static DataTable GetAllProducts()
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM Products ORDER BY Name", connection);
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta
            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter os produtos");
            return null;
        }
    }

    /// <summary>
    /// Salva um novo produto no banco de dados.
    /// </summary>
    /// <param name="product">O objeto <c>Product</c> contendo os dados do produto a ser salvo.</param>
    public static void SaveProduct(Product product)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO Products (Code, Name, Description, CostPrice, ResalePrice, StockGroup, Supplier)" + 
                "VALUES (@Code, @Name, @Description, @CostPrice, @ResalePrice, @StockGroup, @Supplier)", connection);
            
            AddProductParameters(cmd, product);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "salvar o produto");
        }
    }
    
    /// <summary>
    /// Atualiza os dados de um produto existente no banco de dados.
    /// </summary>
    /// <param name="product">O objeto <c>Product</c> contendo os dados atualizados do produto.</param>
    public static void UpdateProduct(Product product)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand(
                "UPDATE Products SET Code = @Code, Name = @Name, Description = @Description, CostPrice = @CostPrice," + 
                "ResalePrice = @ResalePrice, StockGroup = @StockGroup, Supplier = @Supplier WHERE Id = @Id", connection);
            
            AddProductParameters(cmd, product);
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.ExecuteNonQuery(); // Executa a query de atualização
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "atualizar o produto");
        }
    }
    
    /// <summary>
    /// Exclui um produto do banco de dados com base no ID fornecido.
    /// </summary>
    /// <param name="id">ID do produto a ser excluído.</param>
    public static void DeleteProduct(string id)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("DELETE FROM Products WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery(); // Executa a query de exclusão
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "excluir o produto");
        }
    }
    
    /// <summary>
    /// Obtém um produto do banco de dados com base no nome fornecido.
    /// </summary>
    /// <param name="name">O nome do produto a ser buscado.</param>
    /// <returns>Um objeto <c>Product</c> contendo os dados do produto, ou null se o produto não existir.</returns>
    public static Product GetProductByName(string name)
    {
        try
        {
            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT name, ResalePrice FROM Products WHERE Name = @Name", connection);
            
            cmd.Parameters.AddWithValue("@Name", name);

            using var reader = cmd.ExecuteReader();
            
            if (reader.Read()) // Se houver um registro retornado
            {
                return new Product
                {
                    Name = reader["Name"].ToString(),
                    ResalePrice = Convert.ToDecimal(reader["ResalePrice"])
                };
            }

            return null;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "obter o produto");
            return null;
        }
    }
    
    /// <summary>
    /// Pesquisa produtos no banco de dados com base em uma busca aproximada pelo nome.
    /// </summary>
    /// <param name="name">O nome do produto a ser buscado.</param>
    /// <returns>Um <c>DataTable</c> contendo os produtos encontrados.</returns>
    public static DataTable SearchProductsByName(string name)
    {
        try
        {
            var dt = new DataTable();

            using var connection = ConnectionManager.GetConnection();
            using var cmd = new MySqlCommand("SELECT * FROM Products WHERE Name LIKE @Name ORDER BY Name", connection);
            
            cmd.Parameters.AddWithValue("@Name", "%" + name + "%"); // Adiciona o caractere curinga para buscar por nome parcial
            
            using var adapter = new MySqlDataAdapter(cmd);
            
            adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta

            return dt;
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "pesquisar produtos");
            return null;
        }
    }

    /// <summary>
    /// Adiciona os parâmetros de um objeto Product a um comando MySql.
    /// </summary>
    /// <param name="cmd">O comando MySql ao qual os parâmetros serão adicionados.</param>
    /// <param name="product">O objeto <c>Product</c> contendo os dados dos parâmetros.</param>
    private static void AddProductParameters(MySqlCommand cmd, Product product)
    {
        cmd.Parameters.AddWithValue("@Code", product.Code);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Description", product.Description);
        cmd.Parameters.AddWithValue("@CostPrice", product.CostPrice);
        cmd.Parameters.AddWithValue("@ResalePrice", product.ResalePrice);
        cmd.Parameters.AddWithValue("@StockGroup", product.StockGroup);
        cmd.Parameters.AddWithValue("@Supplier", product.Supplier);
    }
}