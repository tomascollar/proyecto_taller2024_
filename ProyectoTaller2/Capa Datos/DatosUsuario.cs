using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProyectoTaller2
{
    public class DatosUsuario
    {
        public void InsertarUsuario(usuario nuevoUsuario)
        {
            using (var context = new proyecto_taller2Entities())
            {
                context.usuario.Add(nuevoUsuario);
                context.SaveChanges();
            }
        }

        

        public void EditarUsuario(usuario usuarioEditado)
        {
            using(var context = new proyecto_taller2Entities())
            {
                
            }
        }

        public List<usuario> ObtenerUsuarios()
        {
            using (var context = new proyecto_taller2Entities())
            {
                return context.usuario.ToList();
            }
        }


        public int ObtenerTipoUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            using (var context = new proyecto_taller2Entities())
            {
                var login = context.usuario
                .FirstOrDefault(u => u.usuario1 == nombreUsuario && u.contraseña == contraseñaUsuario);

                
                 if (login != null)
                {
                    return login.id_tipo_usuario; 
                }
                return -1;
               
                
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.id_usuario,u.nombre_usuario,u.apellido_usuario,u.telefono_usuario,u.usuario,u.contraseña,r.id_tipo_usuario,r.descripcion_tipo_usuario,u.estado_usuario from usuario u");
                    query.AppendLine("inner join tipo_usuario r on r.id_tipo_usuario = u.id_tipo_usuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                nombre_usuario = dr["nombre_usuario"].ToString(),
                                apellido_usuario = dr["apellido_usuario"].ToString(),
                                telefono_usuario = dr["telefono_usuario"].ToString(),
                                usuario = dr["usuario"].ToString(),
                                contraseña = dr["contraseña"].ToString(),
                                oTipo_Usuario = new Tipo_usuario() { id_tipo_usario = Convert.ToInt32(dr["id_tipo_usuario"]), descripcion_tipo_usuario = dr["descripcion_tipo_usuario"].ToString() },
                                estado_usuario = dr["estado_usuario"].ToString()
                            }); ;
                            
                        }
                    }



                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }

            return lista;
        } 
    }
}
