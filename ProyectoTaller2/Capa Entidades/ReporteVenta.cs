using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Entidades
{
    public class ReporteVenta
    {
        public string FechaRegistro {  get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string monto_total { get; set; }
        public string NombreUsuario { get; set; }
        public string dni_cliente { get; set; }
        public string nombre_cliente { get; set; }


    }
}
