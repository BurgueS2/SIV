namespace SIV.Models;

public class Product
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CostPrice { get; set; }
    public decimal ResalePrice { get; set; }
    public string StockGroup { get; set; }
    public string Supplier { get; set; }
}