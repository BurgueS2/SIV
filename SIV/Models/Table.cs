using System;
using System.Collections.Generic;

namespace SIV.teste;

public class Table
{
    public int Id { get; set; }
    public string State { get; set; } = "Normal";
    public List<string> Items { get; set; } = new List<string>();
    public string Color { get; set; } = "Control";
    public DateTime? OpenDate { get; set; }
    public TimeSpan? OpenTime { get; set; }
    public TimeSpan? StayHours { get; set; }

    public Table(int id)
    {
        Id = id;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*public int Id { get; set; }
    public bool IsOpen { get; set; }
    public List<string> Products { get; set; }
    public bool IsPaid { get; set; }
    public string Status { get; set; }

    public Table(int id)
    {
        Id = id;
        IsOpen = false;
        Products = new List<string>();
        IsPaid = false;
    }*/
}