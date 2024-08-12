using System.Collections.Generic;

namespace SIV.Models;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Job { get; set; }
    public string Access { get; set; }
    public List<string> Permissions { get; set; }
    public string Active { get; set; }
    
    public bool HasPermission(string permission)
    {
        return Permissions.Contains(permission);
    }
}