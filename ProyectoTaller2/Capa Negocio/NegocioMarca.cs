using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Negocio
{
    public class NegocioMarca
    {
        private DatosMarca objcd_Marca = new DatosMarca();

        public List<Marca> Listar()
        {
            return objcd_Marca.Listar();
        }

        public int Registrar(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.descripcion_marca == "")
            {
                Mensaje += "Es necesario la descripcion de la Marca\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Marca.Registrar(obj, out Mensaje);
            }
        }

        /*public bool Editar(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.descripcion_marca == "")
            {
                Mensaje += "Es necesario la descripcion de la Marca\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Marca.Editar(obj, out Mensaje);
            }

        }*/

        public bool Eliminar(Marca obj, out string Mensaje)
        {
            return objcd_Marca.Eliminar(obj, out Mensaje);
        }

    }
}
