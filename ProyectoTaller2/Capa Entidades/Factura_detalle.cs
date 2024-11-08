using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Entidades
{
    public class Factura_detalle
    {
        public int id_venta_detalle {  get; set; }
        public Producto oProducto { get; set; }
        public decimal precioVenta { get; set; }
        public int cantidad { get; set; }
        public decimal subTotal {  get; set; }
        public DateTime fecha_registro { get; set; }


         

    }
}
