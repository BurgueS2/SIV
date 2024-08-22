using System;
using System.Collections.Generic;

namespace SIV.teste;

public class Table(int id)
{
    public int Id { get; set; } = id;
    public string State { get; set; } = "Normal";
    public string Color { get; set; } = "Control";
    public DateTime? SaveDate { get; set; }
    public TimeSpan? SaveTime { get; set; }
}