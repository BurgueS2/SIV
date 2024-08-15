using System.Data;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class ClientController
{
    public static DataTable GetAllClients()
    {
        return ClientRepository.GetAllClients();
    }

    public static void SaveClient(Client client)
    {
        ClientRepository.SaveClient(client.Name, client.Cpf, client.Status, client.Phone, client.Email, client.Address, client.ReferencePoint, client.Observation, client.Sex);
    }

    public static void UpdateClient(Client client)
    {
        ClientRepository.UpdateClient(client.Id, client.Name, client.Cpf, client.Status, client.Phone, client.Email, client.Address, client.ReferencePoint, client.Observation, client.Sex);
    }

    public static void DeleteClient(string id)
    {
        ClientRepository.DeleteClient(id);
    }

    public static bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        return ClientRepository.VerifyCpfExistence(cpf, oldCpf);
    }

    public static bool VerifyEmailExistence(string email)
    {
        return ClientRepository.VerifyEmailExisting(email);
    }
    
    public static DataTable SearchByName(string name)
    {
        return ClientRepository.SearchByName(name);
    }

    public static DataTable SearchByCpf(string cpf)
    {
        return ClientRepository.SearchByCpf(cpf);
    }
}