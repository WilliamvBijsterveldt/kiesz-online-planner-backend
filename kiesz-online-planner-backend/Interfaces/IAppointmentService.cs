using kiesz_online_planner_backend.Models;

namespace kiesz_online_planner_backend.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAppointments(string value, DateTime currentDateTime);
}