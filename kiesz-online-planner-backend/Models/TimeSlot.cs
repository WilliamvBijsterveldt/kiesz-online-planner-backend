namespace kiesz_online_planner_backend.Models;

public class TimeSlot
{
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
    public int ProvNum { get; set; }
    public int OpNum { get; set; }
}