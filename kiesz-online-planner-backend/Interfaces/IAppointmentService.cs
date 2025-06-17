using kiesz_online_planner_backend.DTO;
using kiesz_online_planner_backend.Models;

namespace kiesz_online_planner_backend.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDTO>> GetAppointments(int patNum, DateTime currentDateTime);
    Task CreateAppointment(int patNum, int opNum, DateTime aptDateTime);
    Task<IEnumerable<TimeSlot>> GetTimeSlot(int provNum, DateTime currentDateTime);
    Task<Appointment> UpdateAppointment(int aptNum);
    
    Task<IEnumerable<Provider>> GetProvider();
}