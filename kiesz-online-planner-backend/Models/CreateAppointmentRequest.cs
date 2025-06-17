namespace kiesz_online_planner_backend.Models;

public class CreateAppointmentRequest
{
    public int PatNum { get; set; }
    public int Op { get; set; }
    public DateTime AptDateTime { get; set; }
}