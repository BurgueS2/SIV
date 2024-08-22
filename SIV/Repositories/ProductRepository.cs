using System;
using System.Data;
using MySql.Data.MySqlClient;
using SIV.Core;
using SIV.Models;

namespace SIV.Repositories;

public class ProductRepository
{
    public static DataTable GetAllEProducts()
    {
        var dt = new DataTable();

        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("SELECT * FROM products ORDER BY name", connection);
        using var adapter = new MySqlDataAdapter(cmd);
        
        adapter.Fill(dt); // Preenche o DataTable com os dados retornados da consulta

        return dt;
    }

    public static void SaveProduct(string code, string name, string description, decimal costPrice, decimal resalePrice, string stockGroup, string supplier)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("INSERT INTO products (code, name, description, cost_price, resale_price, stock_group_id, supplier_id) VALUES (@code, @name, @description, @costPrice, @resalePrice, @stockGroup, @supplier)", connection);

        cmd.Parameters.AddWithValue("@code", code);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@costPrice", costPrice);
        cmd.Parameters.AddWithValue("@resalePrice", resalePrice);
        cmd.Parameters.AddWithValue("@stockGroup", stockGroup);
        cmd.Parameters.AddWithValue("@supplier", supplier);
        cmd.ExecuteNonQuery(); // Executa a query de inserção
    }
    
    public static void UpdateProduct(int id, string name, string description, decimal costPrice, decimal resalePrice, string stockGroup, string supplier)
    {
        using var connection = ConnectionManager.GetConnection();
        using var cmd = new MySqlCommand("UPDATE products SET name = @name, description = @description, cost_price = @costPrice, reseller_price = @resalePrice, stock_group_id = @stockGroup, supplier_id = @supplier WHERE id = @id", connection);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@costPrice", costPrice);
        cmd.Parameters.AddWithValue("@resalePrice", resalePrice);
        cmd.Parameters.AddWithValue("@stockGroup", stockGroup);
        cmd.Parameters.AddWithValue("@supplier", supplier);
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
}