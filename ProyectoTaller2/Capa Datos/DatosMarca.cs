using ProyectoTaller2.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Datos
{
    internal class DatosMarca
    {
        public void InsertarMarca(marca nuevaMarca)
        {
            using(var context = new proyecto_taller2Entities())
            {
                context.marca.Add(nuevaMarca);
                context.SaveChanges();
            }
        }

        public List<marca> ObtenerMarcas()
        {
            using (var context = new proyecto_taller2Entities())
            {
                return context.marca.ToList();
            }
        }

        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select id_marca,descripcion_marca,estado_marca from marca");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Marca()
                            {
                                id_marca = Convert.ToInt32(dr["id_marca"]),
                                descripcion_marca = dr["descripcion_marca"].ToString(),
                                estado_marca = dr["estado_marca"].ToString()
                            }); ;

                        }
                    }



                }
                catch (Exception ex)
                {
                    lista = new List<Marca>();
                }
            }

            return lista;
        }

        public bool Eliminar(Marca obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarMarca", oconexion);
                    cmd.Parameters.AddWithValue("IdMarca", obj.id_marca);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


        public int Registrar(Marca obj, out string Mensaje)
        {
            int idMarcaGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarMarca", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.descripcion_marca);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idMarcaGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }

            catch (Exception ex)
            {
                idMarcaGenerado = 0;
                Mensaje = ex.Message;
            }

            return idMarcaGenerado;
        }


    }   

}
