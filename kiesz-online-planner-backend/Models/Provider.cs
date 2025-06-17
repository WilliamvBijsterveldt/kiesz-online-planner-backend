namespace kiesz_online_planner_backend.Models;

public class Provider
{
    public int ProvNum { get; set; }
    public string? FName { get; set; }
    public string? Abbr { get; set; }
    public string? LName { get; set; }
    public string? MI { get; set; }
    public string? Suffix { get; set; }
    public int FeeSched { get; set; }
    public int Speciality { get; set; }
    public string? SSN { get; set; }
    public string? StateLicense { get; set; }
    public string? IsSecondary { get; set; }
    public string? provColor { get; set; }
    public string? IsHidden { get; set; }
    public string? UsingTIN { get; set; }
    public string? SigOnFile { get; set; }
    public string? NationalProvID { get; set; }
    public DateTime DateTStamp { get; set; }
    public string? IsNotPerson { get; set; }
    public string? ProvStatus { get; set; }
    public string? IsHiddenReport { get; set; }
    public DateTime Birthdate { get; set; }
    public string? SchedNote { get; set; }
    public string? PreferredName { get; set; }
    public DateTime serverDateTime { get; set; }
}