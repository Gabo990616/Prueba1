using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentacion.Hubs;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private HabitacionService _service;
        private UserService service;

        private readonly IHubContext<SignalHub> _hubContext;
        public HabitacionController(PruebaFinalContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new HabitacionService(context);
            service = new UserService(context);
        }

        [HttpPost]
        public async Task<ActionResult<Habitacion>> Guardar(HabitacionInputModel habitacionInput)
        {
            var request = _service.Save(mapServicio(habitacionInput));
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Habitacion", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", habitacionInput);
            return Ok(request.Habitacion);
        }

        private Habitacion mapServicio(HabitacionInputModel habitacionInput)
        {
            var habitacion = new Habitacion()
            {
                Lugar = habitacionInput.Lugar,
                CantidadPermitida = habitacionInput.CantidadPermitida,
                CuposDisponibles = habitacionInput.CuposDisponibles,
            };

            return habitacion;
        }

        [HttpPost("asignar")]
        public async Task<ActionResult<Habitacion>> AsignarHabitacion(AsignarInputModel asignar)
        {
            var request = service.AsignarHabitacion(asignar.identificacion,asignar.idHabitacion);
            if (request.Error)
            {
                ModelState.AddModelError("Asignar Habitacion", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", request.Usuario);
            return Ok(request.Usuario);
        }

        [HttpGet]
        public ActionResult<List<Habitacion>> Consult()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Error);
            return Ok(request.Habitaciones);
        }

        [HttpGet("asignadas")]
        public ActionResult<List<Usuario>> ConsultHabitacionesOcupadas()
        {
            var request = service.ConsultHabitacionesOcupadas();
            if (request.Error) return BadRequest(request.Error);
            return Ok(request.Usuarios);
        }

        [HttpGet("disponibles")]
        public ActionResult<List<Usuario>> ConsultHabitacionesDisponibles()
        {
            var request = _service.ConsultHabitacionesDisponibles();
            if (request.Error) return BadRequest(request.Error);
            return Ok(request.Habitaciones);
        }
    }
}
