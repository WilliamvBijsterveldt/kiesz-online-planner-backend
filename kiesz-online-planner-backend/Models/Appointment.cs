using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace kiesz_online_planner_backend.Models;

public class Appointment
{
    public DateTime ServerDateTime { get; set; }
    public int AptNum { get; set; }
    public int PatNum { get; set; }
    public string AptStatus { get; set; }
    public string Pattern { get; set; }
    [JsonProperty("Confirmed")]
    public int ConfirmedStatus { get; set; }
    [JsonProperty("confirmed")]
    public string ConfirmedDescription { get; set; }
    public int Op { get; set; }
    public string Note { get; set; }
    public int ProvNum { get; set; }
    [JsonProperty("provAbbr")]
    public string ProvAbbreviation { get; set; }
    public int ProvHyg { get; set; }
    public DateTime AptDateTime { get; set; }
    public int NextAptNum { get; set; }
    [JsonProperty("UnschedStatus")]
    public int UnschedStatusStatus { get; set; }
    [JsonProperty("unschedStatus")]
    public string UnschedStatusDescription { get; set; }
    public string IsNewPatient { get; set; }  // keep string because API sends "false"/"true"
    public string ProcDescript { get; set; }
    public int ClinicNum { get; set; }
    public string IsHygiene { get; set; }    // same here
    public DateTime DateTStamp { get; set; }
    public DateTime DateTimeArrived { get; set; }
    public DateTime DateTimeSeated { get; set; }
    public DateTime DateTimeDismissed { get; set; }
    public DateTime DateTimeAskedToArrive { get; set; }
    public string ColorOverride { get; set; }
    public int AppointmentTypeNum { get; set; }
    public DateTime SecDateTEntry { get; set; }
    public string Priority { get; set; }
}