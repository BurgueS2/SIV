using System.Data;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class EmployeeController
{
    private readonly EmployeeRepository _repository;

    public EmployeeController()
    {
        _repository = new EmployeeRepository();
    }
    
    public DataTable GetAllEmployees()
    {
        return _repository.GetAllEmployees();
    }

    public void SaveEmployee(Employee employee)
    {
        _repository.SaveEmployee(employee.Name, employee.Cpf, employee.Phone, employee.Job, employee.Address, employee.Photo);
    }
    
    public void UpdateEmployee(Employee employee)
    {
        _repository.UpdateEmployee(employee.Id, employee.Name, employee.Cpf, employee.Phone, employee.Job, employee.Address, employee.Photo, employee.Photo != null);
    }

    public void DeleteEmployee(string id)
    {
        _repository.DeleteEmployee(id);
    }

    public bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        return _repository.VerifyCpfExistence(cpf, oldCpf);
    }
}
