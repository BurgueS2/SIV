using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Models;

namespace SIV.Repositories;

public static class ProductRepository
{
    public static DataTable GetAllProducts()
    {
        var dt = new DataTable();

        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("SELECT * FROM products ORDER BY name", connection);
        using var adapter = new MySqlDataAdapter(cmd);
        
        adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta

        return dt;
    }

    public static void SaveProduct(Product product)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand(
            "INSERT INTO products (code, name, description, cost_price, resale_price, stock_group_id, supplier_id)" + 
            "VALUES (@code, @name, @description, @costPrice, @resalePrice, @stockGroup, @supplier)", connection);
        AddProductParameters(cmd, product);
        
        cmd.ExecuteNonQuery(); // Executa a query de inserção
    }
    
    public static void UpdateProduct(Product product)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand(
            "UPDATE products SET code = @code, name = @name, description = @description, cost_price = @costPrice," + 
            "resale_price = @resalePrice, stock_group_id = @stockGroup, supplier_id = @supplier WHERE id = @id", connection);
        AddProductParameters(cmd, product);
        
        cmd.Parameters.AddWithValue("@id", product.Id);
        cmd.ExecuteNonQuery(); // Executa a query de atualização
    }
    
    public static void DeleteProduct(int id)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("DELETE FROM products WHERE id = @id", connection);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery(); // Executa a query de exclusão
    }
    
    public static Product GetProductByName(string name)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("SELECT name, resale_price FROM products WHERE name = @name", connection);
        cmd.Parameters.AddWithValue("@name", name);

        using var reader = cmd.ExecuteReader();
        
        if (reader.Read())
        {
            return new Product
            {
                Name = reader["name"].ToString(),
                ResalePrice = Convert.ToDecimal(reader["resale_price"])
            };
        }

        return null;
    }
    
    public static DataTable SearchProductsByName(string name)
    {
        var dt = new DataTable();

        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("SELECT * FROM products WHERE name LIKE @name ORDER BY name", connection);
        cmd.Parameters.AddWithValue("@name", "%" + name + "%"); // Adiciona o caractere curinga para buscar por nome parcial
        
        using var adapter = new MySqlDataAdapter(cmd);
        adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta

        return dt;
    }

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