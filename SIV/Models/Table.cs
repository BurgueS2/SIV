using System;

namespace SIV.Models;

public class Table(int id)
{
    public int Id { get; set; } = id;
    public string State { get; set; } = "Disponível";
    public string Color { get; set; } = "Control";
    public DateTime? SaveDate { get; set; }
    public TimeSpan? SaveTime { get; set; }
}