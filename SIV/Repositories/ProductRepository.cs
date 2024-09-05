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
            using var cmd = new MySqlCommand("SELECT * FROM products ORDER BY name", connection);
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
                "INSERT INTO products (code, name, description, cost_price, resale_price, stock_group_id, supplier_id)" + 
                "VALUES (@code, @name, @description, @costPrice, @resalePrice, @stockGroup, @supplier)", connection);
            
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
                "UPDATE products SET code = @code, name = @name, description = @description, cost_price = @costPrice," + 
                "resale_price = @resalePrice, stock_group_id = @stockGroup, supplier_id = @supplier WHERE id = @id", connection);
            
            AddProductParameters(cmd, product);
            cmd.Parameters.AddWithValue("@id", product.Id);
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
            using var cmd = new MySqlCommand("DELETE FROM products WHERE id = @id", connection);

            cmd.Parameters.AddWithValue("@id", id);
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
            using var cmd = new MySqlCommand("SELECT name, resale_price FROM products WHERE name = @name", connection);
            
            cmd.Parameters.AddWithValue("@name", name);

            using var reader = cmd.ExecuteReader();
            
            if (reader.Read()) // Se houver um registro retornado
            {
                return new Product
                {
                    Name = reader["name"].ToString(),
                    ResalePrice = Convert.ToDecimal(reader["resale_price"])
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
            using var cmd = new MySqlCommand("SELECT * FROM products WHERE name LIKE @name ORDER BY name", connection);
            
            cmd.Parameters.AddWithValue("@name", "%" + name + "%"); // Adiciona o caractere curinga para buscar por nome parcial
            
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
        cmd.Parameters.AddWithValue("@code", product.Code);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@description", product.Description);
        cmd.Parameters.AddWithValue("@costPrice", product.CostPrice);
        cmd.Parameters.AddWithValue("@resalePrice", product.ResalePrice);
        cmd.Parameters.AddWithValue("@stockGroup", product.StockGroup);
        cmd.Parameters.AddWithValue("@supplier", product.Supplier);
    }
}