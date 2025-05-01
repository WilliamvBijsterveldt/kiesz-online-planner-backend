namespace kiesz_online_planner_backend.Models;

public class Patient
{
    public int PatNum { get; set; }
    public string LName { get; set; }
    public string FName { get; set; }
    public string MiddleI { get; set; }
    public string Preferred { get; set; }
    public string PatStatus { get; set; }
    public string Gender { get; set; }
    public string Position { get; set; }
    public string Birthdate { get; set; }
    public string SSN { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string HmPhone { get; set; }
    public string WkPhone { get; set; }
    public string WirelessPhone { get; set; }
    public int Guarantor { get; set; }
    public string Email { get; set; }
    public double EstBalance { get; set; }
    public int PriProv { get; set; }
    public string priProvAbbr { get; set; }
    public int SecProv { get; set; }
    public string secProvAbbr { get; set; }
    public string BillingType { get; set; }
    public string ImageFolder { get; set; }
    public string ChartNumber { get; set; }
    public string MedicaidID { get; set; }
    public double BalTotal { get; set; }
    public string DateFirstVisit { get; set; }
    public int ClinicNum { get; set; }
    public string clinicAbbr { get; set; }
    public string PreferConfirmMethod { get; set; }
    public string PreferContactMethod { get; set; }
    public string PreferRecallMethod { get; set; }
    public string Language { get; set; }
    public string siteDesc { get; set; }
    public string DateTStamp { get; set; }
    public int SuperFamily { get; set; }
    public string TxtMsgOk { get; set; }
}