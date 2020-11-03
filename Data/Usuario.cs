using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea_Seis_y_Siete.Data
{
    public class Usuario
    {
        [Key]
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string ColorFav { get; set; }
    }
}
