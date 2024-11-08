using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Negocio
{
    public class NegocioReporte
    {
        private DatosReportes objcd_reporte = new DatosReportes();

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            return objcd_reporte.Venta(fechainicio, fechafin);
        }
    }
}
