using System.Data;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class EmployeeController
{
    public static DataTable GetAllEmployees()
    {
        return EmployeeRepository.GetAllEmployees();
    }

    public static void SaveEmployee(Employee employee)
    {
        EmployeeRepository.SaveEmployee(employee.Name, employee.Cpf, employee.Phone, employee.Job, employee.Address, employee.Photo);
    }
    
    public static void UpdateEmployee(Employee employee)
    {
        EmployeeRepository.UpdateEmployee(employee.Id, employee.Name, employee.Cpf, employee.Phone, employee.Job, employee.Address, employee.Photo, employee.Photo != null);
    }

    public static void DeleteEmployee(string id)
    {
        EmployeeRepository.DeleteEmployee(id);
    }

    public static bool VerifyCpfExistence(string cpf, string oldCpf)
    {
        return EmployeeRepository.VerifyCpfExistence(cpf, oldCpf);
    }
    
    public static DataTable SearchByName(string name)
    {
        return EmployeeRepository.SearchByName(name);
    }
}
