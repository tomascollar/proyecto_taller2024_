using ProyectoTaller2.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Datos
{
    public class DatosFactura
    {
        public void InsertarVenta(factura nuevaFactura)
        {
            using(var context = new proyecto_taller2Entities())
            {
                context.factura.Add(nuevaFactura);
                context.SaveChanges();
            }
        }

        public List<factura> ObtenerVentas()
        {
            using(var context = new proyecto_taller2Entities())
            {
                return context.factura.ToList();
            }
        }

        public bool RestarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using(SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update productos set stock = stock - @cantidad where id_producto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update productos set stock = stock + @cantidad " +
                        "where id_producto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public int ObtenerCorrelativo()
        {
            int id_correlativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from factura");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    id_correlativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    id_correlativo = 0;
                }
            }

            return id_correlativo;
        }
            


            

        public bool Registrar(Factura obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion);
                    cmd.Parameters.AddWithValue("id_usuario", obj.oUsuario.id_usuario);
                    cmd.Parameters.AddWithValue("tipo_documento", obj.tipo_documento);
                    cmd.Parameters.AddWithValue("numero_documento", obj.numero_documento);
                    cmd.Parameters.AddWithValue("dni_cliente", obj.dni_cliente);
                    cmd.Parameters.AddWithValue("nombre_cliente", obj.nombre_cliente);
                    cmd.Parameters.AddWithValue("monto_total", obj.monto_total);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex) 
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }
            return Respuesta;
        } 

        public Factura ObtenerVenta(string numero)
        {
            Factura obj = new Factura();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select v.id_factura, u.nombre_usuario, v.dni_cliente, v.nombre_cliente");
                    query.AppendLine(",v.tipo_documento, v.numero_documento, v.monto_total,");
                    query.AppendLine("convert(char(10),v.fecha_registro,103)[fecha_registro]");
                    query.AppendLine("from factura v");
                    query.AppendLine("inner join usuario u on u.id_usuario = v.id_usuario");
                    query.AppendLine("where v.numero_documento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            DateTime fechaRegistro;

                            DateTime.TryParseExact(dr["fecha_registro"].ToString(), "dd/MM/yyyy",
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None, out fechaRegistro);
                            obj = new Factura()
                            {
                                id_factura = int.Parse(dr["id_factura"].ToString()),
                                oUsuario = new Usuario() { nombre_usuario = dr["nombre_usuario"].ToString() },
                                dni_cliente = dr["dni_cliente"].ToString(),
                                nombre_cliente = dr["nombre_cliente"].ToString(),
                                tipo_documento = dr["tipo_documento"].ToString(),
                                numero_documento = dr["numero_documento"].ToString(),
                                monto_total = Convert.ToDecimal(dr["monto_total"].ToString()),
                                fecha_registro = fechaRegistro.Date

                            };
                        }
                    }
                }
                catch
                {
                    obj = new Factura();
                }
            }
                return obj;
        }

        public List<Factura_detalle> ObtenerDetalleVenta(int idVenta)
        {
            List<Factura_detalle> oLista = new List<Factura_detalle>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.nombre_producto, dv.precioVenta,dv.cantidad, dv.subTotal");
                    query.AppendLine("from factura_detalle dv");
                    query.AppendLine("inner join productos p on p.id_producto = dv.id_producto");
                    query.AppendLine("where dv.id_factura = @idventa");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idventa", idVenta);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Factura_detalle()
                            {
                                oProducto = new Producto() { nombre_producto = dr["nombre_producto"].ToString() },
                                precioVenta = Convert.ToDecimal(dr["precioVenta"].ToString()),
                                cantidad = Convert.ToInt32(dr["cantidad"].ToString()),
                                subTotal = Convert.ToDecimal(dr["subTotal"].ToString())

                            });
                        }
                    }

                }
                catch
                {
                    oLista = new List<Factura_detalle>();
                }
            }
             return oLista;
        } 
    }
}
