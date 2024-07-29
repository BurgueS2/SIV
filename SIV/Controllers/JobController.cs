using System.Data;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class JobController
{
    private readonly JobRepository _repository;

    public JobController()
    {
        _repository = new JobRepository();
    }

    public DataTable GetAllJobs()
    {
        return _repository.GetAllJobs();
    }

    public void SaveJob(Job job)
    {
        _repository.SaveJob(job.Name);
    }

    public void UpdateJob(Job job)
    {
        _repository.UpdateJob(job.Id, job.Name);
    }

    public void DeleteJob(string id)
    {
        _repository.DeleteJob(id);
    }

    public bool JobExists(string name)
    {
        return _repository.JobExists(name);
    }
}