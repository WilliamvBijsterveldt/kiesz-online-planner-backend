using System.Net.Http.Headers;
using kiesz_online_planner_backend.Interfaces;
using kiesz_online_planner_backend.Models;
using Newtonsoft.Json;

namespace kiesz_online_planner_backend.Services;

public class PatientService: IPatientService
{
    private readonly HttpClient _httpClient;

    public PatientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("ODFHIR", "je6ASQjGvtBfpykD/4fUpRASbKGdeBXre");
    }
    public async Task<IEnumerable<Patient>> GetPatients(string value)
    {
        value = "262555815";
        
        var response =
            await _httpClient.GetAsync(
                $"https://api.opendental.com/api/v1/patients?SSN={value}");

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            
            var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(responseBody);

            return patients;
        }
        
        return [];
    }
}