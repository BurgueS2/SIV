namespace SIV.Models;

/// <summary>
/// Representa um cliente dentro do sistema.
/// </summary>
public class Client
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Status { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string ReferencePoint { get; set; }
    public string Observation { get; set; }
    public string Sex { get; set; }
}