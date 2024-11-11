using ProyectoTaller2.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoTaller2.Capa_Datos
{
    public class DatosReportes
    {
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> lista= new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                tipo_documento = dr["tipo_documento"].ToString(),
                                numero_documento = dr["numero_documento"].ToString(),
                                monto_total = dr["monto_total"].ToString(),
                                NombreUsuario = dr["NombreUsuario"].ToString(),
                                dni_cliente = dr["dni_cliente"].ToString(),
                                nombre_cliente = dr["nombre_cliente"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex) 
                {
                    lista = new List<ReporteVenta>();
                    MessageBox.Show("No se realizo correctamente la lectura");

                }
            }
            return lista;
        }
    }
}
