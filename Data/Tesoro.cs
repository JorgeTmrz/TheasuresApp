using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea_Seis_y_Siete.Data
{
    public class Tesoro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public string URLReferencia { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public double Valor { get; set; }
        public double Peso { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; } = new DateTime();
    }
}
