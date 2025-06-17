using Humanizer;
using kiesz_online_planner_backend.DTO;
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
        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            var currentDateTime = DateTime.UtcNow;
            var patNum = 22;
            
            var appointments = (await _appointmentService.GetAppointments(patNum, currentDateTime)).ToArray();
            
            return appointments;
        }

        [HttpGet("Timeslots")]
        public async Task<IEnumerable<TimeSlot>> GetTimeSlots(int provNum, DateTime currentDateTime)
        {
            var dateTimeNow = DateTime.UtcNow;

            var timeSlots = (await _appointmentService.GetTimeSlot(1, dateTimeNow)).ToArray();
            
            return timeSlots;
        }

        [HttpGet("Providers")]
        public async Task<IEnumerable<Provider>> GetProviders()
        {
            var providers = (await _appointmentService.GetProvider()).ToArray();
            
            return providers;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _appointmentService.CreateAppointment(request.PatNum, request.Op, request.AptDateTime);
            
                return Ok(new { message = "Appointment created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while creating the appointment", details = ex.Message });
            }
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAppointment([FromBody] Appointment appointment)
        {
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAppointment([FromBody] Appointment appointment)
        {
            return Ok();       
        }
    }
}
