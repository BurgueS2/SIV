using System.Data;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class ProductController
{
    public static DataTable GetAllProducts()
    {
        return ProductRepository.GetAllEProducts();
    }
    
    public static void SaveProduct(Product product)
    {
        ProductRepository.SaveProduct(product.Code, product.Name, product.Description, product.CostPrice, product.ResalePrice, product.StockGroup, product.Supplier);
    }
    
    public static void UpdateProduct(Product product)
    {
        ProductRepository.UpdateProduct(product.Id, product.Name, product.Description, product.CostPrice, product.ResalePrice, product.StockGroup, product.Supplier);
    }
    
    public static void DeleteProduct(int id)
    {
        ProductRepository.DeleteProduct(id);
    }
}