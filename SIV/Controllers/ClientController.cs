using System.Data;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class ClientController
{
    private readonly ClientRepository _repository;

    public ClientController()
    {
        _repository = new ClientRepository();
    }

    public DataTable GetAllClients()
    {
        return _repository.GetAllClients();
    }

    public void SaveClient(Client client)
    {
        _repository.SaveClient(client.Code, client.Name, client.Cpf, client.OpenAmount, client.Status, client.Phone, client.Email, client.Address);
    }

    public void UpdateClient(Client client)
    {
        _repository.UpdateClient(client.Id, client.Name, client.Cpf, client.OpenAmount, client.Status, client.Phone, client.Email, client.Address);
    }

    public void DeleteClient(string id)
    {
        _repository.DeleteClient(id);
    }

    public bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        return _repository.VerifyCpfExistence(cpf, oldCpf);
    }

    public bool VerifyEmailExistence(string email)
    {
        return _repository.VerifyEmailExisting(email);
    }
}