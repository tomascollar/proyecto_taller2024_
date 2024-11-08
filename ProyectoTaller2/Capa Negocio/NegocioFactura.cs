using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoTaller2.Capa_Negocio
{
    public class NegocioFactura
    {
        private DatosFactura obj_datos_factura = new DatosFactura();
        public bool RestarStock(int idproducto, int cantidad)
        {
            return obj_datos_factura.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return obj_datos_factura.SumarStock(idproducto, cantidad);
        }

        public int ObtenerCorrelativo()
        {
            return obj_datos_factura.ObtenerCorrelativo();
        }

        public bool Registrar(Factura obj, DataTable DetalleVenta, out string Mensaje)
        {
            return obj_datos_factura.Registrar(obj, DetalleVenta, out Mensaje);
        }


        public Factura ObtenerVenta(string numero)
        {
            Factura oVenta = obj_datos_factura.ObtenerVenta(numero);

            if(oVenta.id_factura != 0)
            {
                List<Factura_detalle> oDetalleVenta = obj_datos_factura.ObtenerDetalleVenta(oVenta.id_factura);
                oVenta.oFactura_Detalle = oDetalleVenta;
            }

            return oVenta;
        }
    }


}
