using System.Net.Http.Headers;
using System.Text;
using kiesz_online_planner_backend.DTO;
using kiesz_online_planner_backend.Interfaces;
using kiesz_online_planner_backend.Models;
using Newtonsoft.Json;

namespace kiesz_online_planner_backend.Services;

public class AppointmentService: IAppointmentService
{
    private readonly HttpClient _httpClient;
    private readonly IMapperService _mapper;
    private readonly IPatientService _patientService;

    public AppointmentService(IPatientService patientService, HttpClient httpClient, IMapperService mapper)
    {
        _mapper = mapper;
        _patientService = patientService;
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("ODFHIR", "je6ASQjGvtBfpykD/4fUpRASbKGdeBXre");
    }

    public async Task<IEnumerable<AppointmentDTO>> GetAppointments(int patNum, DateTime currentDateTime)
    {
        /*var patients = await _patientService.GetPatients(value);

        foreach (var patient in patients)
        {
            patNum = patient.PatNum;
        }*/
        
        var response = await _httpClient.GetAsync(
            $"https://api.opendental.com/api/v1/appointments?PatNum={patNum}&dateStart={currentDateTime:yyyy-MM-dd}");

        if (!response.IsSuccessStatusCode)
            return [];

        var responseBody = await response.Content.ReadAsStringAsync();
        var appointments = JsonConvert.DeserializeObject<IEnumerable<Appointment>>(responseBody);

        // Map to DTOs using Mapperly
        var appointmentDtos = appointments.Select(_mapper.ToDto);

        return appointmentDtos;
    }

    public async Task CreateAppointment(int patNum, int opNum, DateTime aptDateTime)
    {
        var appointmentPayload = new
        {
            PatNum = patNum,
            Op = opNum,
            AptDateTime = aptDateTime.ToString("yyyy-MM-dd HH:mm:ss")
        };
        
        Console.WriteLine($"Sending payload: {JsonConvert.SerializeObject(appointmentPayload)}");
        
        var response = await _httpClient.PostAsJsonAsync("https://api.opendental.com/api/v1/appointments", appointmentPayload);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to create appointment. Status: {response.StatusCode}, Details: {error}");
        }
    }
    
    public async Task<IEnumerable<TimeSlot>> GetTimeSlot(int provNum, DateTime currentDateTime)
    {
        var response =
            await _httpClient.GetAsync(
                $"https://api.opendental.com/api/v1/appointments/Slots?ProvNum={provNum}&dateStart={currentDateTime:yyyy-MM-dd}");
        
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            
            var timeSlots = JsonConvert.DeserializeObject<IEnumerable<TimeSlot>>(responseBody);

            return timeSlots;
        }
        
        return Array.Empty<TimeSlot>();
    }

    public Task<Appointment> UpdateAppointment(int aptNum)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<Provider>> GetProvider()
    {
        var response =
            await _httpClient.GetAsync(
                $"https://api.opendental.com/api/v1/providers");
        
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            
            var providers = JsonConvert.DeserializeObject<IEnumerable<Provider>>(responseBody);

            return providers;
        }
        
        return [];
    }
}