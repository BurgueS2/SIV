using System.Data;
using SIV.Models;
using SIV.Repositories;

namespace SIV.Controllers;

public class JobController
{
    public static DataTable GetAllJobs()
    {
        return JobRepository.GetAllJobs();
    }

    public static void SaveJob(Job job)
    {
        JobRepository.SaveJob(job.Name);
    }

    public static void UpdateJob(Job job)
    {
        JobRepository.UpdateJob(job.Id, job.Name);
    }

    public static void DeleteJob(string id)
    {
        JobRepository.DeleteJob(id);
    }

    public static bool JobExists(string name)
    {
        return JobRepository.JobExists(name);
    }
}