namespace kiesz_online_planner_backend.DTO;

public class AppointmentDTO
{
    public int AptNum { get; set; }              // Unique ID for the appointment
    public int PatNum { get; set; }              // Patient ID
    public DateTime AptDateTime { get; set; }    // Start time of the appointment
    public TimeSpan Duration { get; set; }       // Calculated from Pattern
    public string ProcDescript { get; set; }     // Description (e.g., "Cleaning, Exam")
    public string ConfirmedDescription { get; set; } // "Unconfirmed", "Confirmed", etc.
    public string Provider { get; set; }         // E.g., "DOC1"
    public int Op { get; set; }                  // Operatory (room)
    public string IsNewPatient { get; set; }       // For styling or flags
    public string Priority { get; set; }         // E.g., "Normal", "ASAP"
}