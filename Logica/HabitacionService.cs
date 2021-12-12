using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class HabitacionService
    {
        private readonly PruebaFinalContext _context;

        public HabitacionService(PruebaFinalContext context)
        {
            _context = context;
        }

        public HabitacionLogResponse Save(Habitacion habitacion)
        {
            try
            {
                if (_context.Habitaciones.Find(habitacion.IdHabitacion) == null)
                {
                    _context.Habitaciones.Add(habitacion);
                    _context.SaveChanges();
                    return new HabitacionLogResponse(habitacion);
                }

                return new HabitacionLogResponse($"Error al Guardar: Habitacion Existente");
            }
            catch (Exception e) { return new HabitacionLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public HabitacionConsultaResponse Consult()
        {
            try
            {
                var habitaciones = _context.Habitaciones.ToList();
                if (habitaciones != null)
                {
                    return new HabitacionConsultaResponse(habitaciones);
                }
                return new HabitacionConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new HabitacionConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

        public HabitacionConsultaResponse ConsultHabitacionesDisponibles()
        {
            try
            {
                var habitaciones = _context.Habitaciones.Where(h => h.CuposDisponibles > 0).ToList();
                if (habitaciones != null)
                {
                    return new HabitacionConsultaResponse(habitaciones);
                }
                return new HabitacionConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new HabitacionConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class HabitacionLogResponse
    {
        public Habitacion Habitacion { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public HabitacionLogResponse(Habitacion habitacion)
        {
            Habitacion = habitacion;
            Error = false;
        }

        public HabitacionLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class HabitacionConsultaResponse
    {
        public List<Habitacion> Habitaciones { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public HabitacionConsultaResponse(List<Habitacion> habitaciones)
        {
            Habitaciones = habitaciones;
            Error = false;
        }
        public HabitacionConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
