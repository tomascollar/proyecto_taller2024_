using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Entidades
{
    public class Factura
    {
        public int id_factura {  get; set; }
        public Usuario oUsuario { get; set; }
        public string tipo_documento {  get; set; }
        public string numero_documento { get; set; }
        public string dni_cliente {  get; set; }
        public string nombre_cliente { get; set; }
        public decimal monto_total { get; set; }

        public List<Factura_detalle> oFactura_Detalle {  get; set; }
        public DateTime fecha_registro {  get; set; }


    }
}
