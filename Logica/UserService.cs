using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class UserService
    {
        private readonly PruebaFinalContext _context;

        public UserService(PruebaFinalContext context) => _context = context;

        public Usuario Validate(string userName, string password)
        {
            return _context.Usuarios.FirstOrDefault(t => t.User == userName && t.Password == password);
        }

        public UsuarioLogResponse Register(Usuario usuario)
        {
            try
            {
                if(_context.Usuarios.Find(usuario.Identificacion) == null)
                {
                    if(_context.Usuarios.FirstOrDefault(u => u.User == usuario.User) == null)
                    {
                        _context.Usuarios.Add(usuario);
                        _context.SaveChanges();
                         return new UsuarioLogResponse(usuario);
                    }
                    return new UsuarioLogResponse("El nombre de usuario ya se encuentra registrado");
                }
                return new UsuarioLogResponse("El usuario ya se encuentra registrado con esta identificacion");
            }
            catch (Exception e) { return new UsuarioLogResponse($"Se presento lo siguiente al Registrar: { e.Message}"); }
        }

        public UsuarioLogResponse AsignarHabitacion(string identificacion, int idHabitacion)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Habitacion == null && u.Identificacion.Equals(identificacion));

                if(usuario != null)
                {
                    var habitacion = _context.Habitaciones.FirstOrDefault(h => h.IdHabitacion.Equals(idHabitacion) && h.CuposDisponibles > 0);
                    usuario.Habitacion = habitacion;
                    if(habitacion != null)
                    {
                        habitacion.CuposDisponibles = habitacion.CuposDisponibles - 1;
                        var usuarioviejo = _context.Usuarios.Find(identificacion);
                        usuarioviejo = usuario;
                        _context.Usuarios.Update(usuarioviejo);
                        _context.Habitaciones.Update(habitacion);
                        _context.SaveChanges();
                        return new UsuarioLogResponse(usuario);
                    }
                    return new UsuarioLogResponse("No se encontro una habitacion para asignar");
                }
                return new UsuarioLogResponse($"El usuario {identificacion} ya tiene asinada una habitacion");
            }
            catch (Exception e) { return new UsuarioLogResponse($"Se presento lo siguiente al Asignar : { e.Message}"); }
        }

        public UsuarioConsultaResponse Consult()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList();
                if (usuarios != null)
                {
                    return new UsuarioConsultaResponse(usuarios);
                }
                return new UsuarioConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new UsuarioConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

        public UsuarioConsultaResponse ConsultHabitacionesOcupadas()
        {
            try
            {
                var usuarios = _context.Usuarios.Where(h => h.Habitacion != null).Include(h => h.Habitacion).ToList();
                if (usuarios != null)
                {
                    return new UsuarioConsultaResponse(usuarios);
                }
                return new UsuarioConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new UsuarioConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

    }

    public class UsuarioLogResponse
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public Usuario Usuario { get; set; }

        public UsuarioLogResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public UsuarioLogResponse(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }
    }

    public class UsuarioConsultaResponse
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public UsuarioConsultaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public UsuarioConsultaResponse(List<Usuario> usuarios)
        {
            Error = false;
            Usuarios = usuarios;
        }
    }
}
