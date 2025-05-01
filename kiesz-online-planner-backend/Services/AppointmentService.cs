using System.Net.Http.Headers;
using kiesz_online_planner_backend.Interfaces;
using kiesz_online_planner_backend.Models;
using Newtonsoft.Json;

namespace kiesz_online_planner_backend.Services;

public class AppointmentService: IAppointmentService
{
    private readonly HttpClient _httpClient;
    private readonly IPatientService _patientService;

    public AppointmentService(IPatientService patientService, HttpClient httpClient)
    {
        _patientService = patientService;
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("ODFHIR", "je6ASQjGvtBfpykD/4fUpRASbKGdeBXre");
    }

    public async Task<IEnumerable<Appointment>> GetAppointments(string value, DateTime currentDateTime)
    {
        var patNum = 0;
        
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("ODFHIR", "je6ASQjGvtBfpykD/4fUpRASbKGdeBXre");

        var patients = await _patientService.GetPatients(value);

        foreach (var patient in patients)
        {
            patNum = patient.PatNum;
        }
        
        var response =
            await _httpClient.GetAsync(
                $"https://api.opendental.com/api/v1/appointments?PatNum={patNum}&dateStart={currentDateTime:yyyy-MM-dd}");
        
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            // Console.WriteLine(responseBody);
            
            var appointments = JsonConvert.DeserializeObject<IEnumerable<Appointment>>(responseBody);

            return appointments;
        }
        
        return Array.Empty<Appointment>();
    }
}