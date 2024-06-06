using DoctorAppointmentApp.Exceptions;
using DoctorAppointmentApp.Interfaces;
using DoctorAppointmentApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController: ControllerBase 
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        { 
            _doctorService = doctorService;
        }
        [Route("AddDoctor")]
        [HttpPost]
        public async Task<ActionResult<Doctor>> Add(Doctor doctor)
        {
            try
            {
                var doc=await _doctorService.AddDoctor(doctor);
                return doctor;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try
            {
                var doctors=await _doctorService.GetAllDoctor();
                return Ok(doctors.ToList());

            }catch(NoDoctorsFoundException ndfe)
            {
                return NotFound(ndfe.Message);
            }
        }
        [Route("UpdateDoctorExperience")]
        [HttpPut]
        public async Task<ActionResult<Doctor>> Put(int id, float experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(doctor);  
            }
            catch(NoSuchDoctorException nsde)
            {
                return NotFound(nsde.Message);
            }
        }

        [Route("GetAllDoctorBySpecialization")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get(string Specialization)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorsBySpecialization(Specialization);
                return Ok(doctor.ToList());
            }
            catch(NoSuchDoctorException nsde)
            {
                return NotFound(nsde.Message);
            }
        }
    }
}
