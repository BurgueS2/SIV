using System.Data;
using SIV.Repositories;

namespace SIV.Controllers;

public class UserController
{
    private readonly UserRepository _repository;

    public UserController()
    {
        _repository = new UserRepository();
    }
    
    public DataTable GetAllUsers()
    {
        return _repository.GetAllUsers();
    }

    public void SaveUser(string name, string password)
    {
        _repository.SaveUser(name, password);
    }
    
    public void UpdateUser(string id, string name, string password)
    {
        _repository.UpdateUser(id, name, password);
    }

    public void DeleteUser(string id)
    {
        _repository.DeleteUser(id);
    }

    public bool UserExists(string name, string password)
    {
        return _repository.UserExists(name);
    }
}