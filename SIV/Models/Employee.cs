namespace SIV.Models;

/// <summary>
/// Representa um funcionário dentro do sistema.
/// </summary>
public class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Phone { get; set; }
    public string Job { get; set; }
    public string Address { get; set; }
    public byte[] Photo { get; set; }
}