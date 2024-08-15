using System;
using System.Data;
using System.Web.SessionState;
using MySqlX.XDevAPI;
using SIV.Core;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class UserController
{
    public static DataTable GetAllUsers()
    {
        return UserRepository.GetAllUsers();
    }

    public static void SaveUser(User user)
    {
        UserRepository.SaveUser(user.Name, user.Password, user.Job, user.Access, user.Active, user.Permissions);
    }

    public static void UpdateUser(User user)
    {
        UserRepository.UpdateUser(user.Id, user.Name, user.Password, user.Job, user.Access, user.Active, user.Permissions);
    }

    public static void DeleteUser(string id)
    {
        UserRepository.DeleteUser(id);
    }

    public static void Logoff()
    {
        SessionManager.ClearSession();
    }

    public static void Login(string username, string password)
    {
        var user = UserRepository.UserPermission(username, password);
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