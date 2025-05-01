using kiesz_online_planner_backend.Models;

namespace kiesz_online_planner_backend.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<Patient>> GetPatients(string value);
}