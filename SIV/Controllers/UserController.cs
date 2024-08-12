using System;
using System.Data;
using System.Web.SessionState;
using MySqlX.XDevAPI;
using SIV.Models;
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

    public void SaveUser(User user)
    {
        _repository.SaveUser(user.Name, user.Password, user.Job, user.Access, user.Active, user.Permissions);
    }

    public void UpdateUser(User user)
    {
        _repository.UpdateUser(user.Id, user.Name, user.Password, user.Job, user.Access, user.Active, user.Permissions);
    }

    public void DeleteUser(string id)
    {
        _repository.DeleteUser(id);
    }

    public bool UserExists(string name, string password)
    {
        return _repository.VerifyUserExistence(name, password);
    }

    public User PermissionValidation(string name, string permission)
    {
        return _repository.UserPermition(name, permission);
    }

    public void Logoff()
    {
        SessionManager.ClearSession();
    }

    public void Login(string username, string password)
    {
        var user = _repository.UserPermition(username, password);
        if (user != null)
        {
            SessionManager.SetCurrentUser(user);
        }
        else
        {
            throw new Exception("Usuário ou senha inválidos.");
        }
    }
}