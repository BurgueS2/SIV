namespace SIV.Models;

public class Payment
{
    public string Id { get; set; }
    public string Flag { get; set; }
    public string DaysToCredit { get; set; }
    public string OperatorCnpj { get; set; }
    public string Tax { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
}