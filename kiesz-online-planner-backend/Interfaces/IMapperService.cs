using kiesz_online_planner_backend.DTO;
using kiesz_online_planner_backend.Models;

namespace kiesz_online_planner_backend.Interfaces;

public interface IMapperService
{
    public AppointmentDTO ToDto(Appointment appointment);
    public ProviderDTO ToDto(Provider provider);
    public TimeSlotDTO ToDto(TimeSlot timeSlot);
}