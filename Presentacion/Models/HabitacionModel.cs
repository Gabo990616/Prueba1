using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class HabitacionInputModel
    {
        [Required]
        public string Lugar { get; set; }
        [Required]
        public int CantidadPermitida { get; set; }
        [Required]
        public int CuposDisponibles { get; set; }
    }

    public class HabitacionViewModel: HabitacionInputModel
    {
        public HabitacionViewModel(Habitacion habitacion)
        {
            Lugar = habitacion.Lugar;
            CantidadPermitida = habitacion.CantidadPermitida;
            CuposDisponibles = habitacion.CuposDisponibles;
        }
    }

    public class AsignarInputModel{
        public string identificacion { get; set; }
        public int idHabitacion { get; set; }
    }
}
