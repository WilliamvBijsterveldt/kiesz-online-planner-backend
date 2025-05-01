using Humanizer;
using kiesz_online_planner_backend.Interfaces;
using kiesz_online_planner_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kiesz_online_planner_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            var currentDateTime = DateTime.UtcNow;
            var value = "two";
            
            var appointments = (await _appointmentService.GetAppointments(value, currentDateTime)).ToArray();
            
            return appointments;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            return Ok();
        }
    }
}
