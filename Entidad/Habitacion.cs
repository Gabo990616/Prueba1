using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Habitacion
    {
        [Key]
        public int IdHabitacion { get; set; }
        public string  Lugar { get; set; }
        public int CantidadPermitida { get; set; }
        public int CuposDisponibles { get; set; }
    }
}
