namespace kiesz_online_planner_backend.Models;

public class Appointment
{
    public DateTime serverDateTime { get; set; }
    public int AptNum { get; set; }
    public int PatNum { get; set; }
    public string AptStatus { get; set; }
    public string Pattern { get; set; }
    public int Confirmed { get; set; }
    public string confirmed { get; set; }
    public int Op { get; set; }
    public string Note { get; set; }
    public int ProvNum { get; set; }
    public string provAbbr { get; set; }
    public int ProvHyg { get; set; }
    public DateTime AptDateTime { get; set; }
    public int NextAptNum { get; set; }
    public int UnschedStatus { get; set; }
    public string unschedStatus { get; set; }
    public string IsNewPatient { get; set; }
    public string ProcDescript { get; set; }
    public int ClinicNum { get; set; }
    public string IsHygiene { get; set; }
    public DateTime DateTStamp { get; set; }
    public DateTime DateTimeArrived { get; set; }
    public DateTime DateTimeSeated { get; set; }
    public DateTime DateTimeDismissed { get; set; }
    public DateTime DateTimeAskedToArrive { get; set; }
    public string colorOverride { get; set; }
    public int AppointmentTypeNum { get; set; }
    public string Priority { get; set; }
}