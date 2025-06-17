using kiesz_online_planner_backend.DTO;
using kiesz_online_planner_backend.Interfaces;
using kiesz_online_planner_backend.Models;
using Riok.Mapperly.Abstractions;

namespace kiesz_online_planner_backend.Services;

[Mapper]
public partial class MapperService: IMapperService
{
    [MapProperty(nameof(Appointment.ConfirmedDescription), nameof(AppointmentDTO.ConfirmedDescription))]
    [MapProperty(nameof(Appointment.ProvAbbreviation), nameof(AppointmentDTO.Provider))]
    [MapProperty(nameof(Appointment.Pattern), nameof(AppointmentDTO.Duration))]
    public partial AppointmentDTO ToDto(Appointment appointment);
    public partial ProviderDTO ToDto(Provider provider);
    public partial TimeSlotDTO ToDto(TimeSlot timeSlot);

    // Custom mapping method for 'Duration'
    private static TimeSpan MapPatternToDuration(string pattern) =>
        TimeSpan.FromMinutes(pattern.Count(c => c == 'X') * 5);
}