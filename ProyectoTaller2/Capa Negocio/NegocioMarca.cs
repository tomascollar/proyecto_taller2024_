using ProyectoTaller2.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Negocio
{
    internal class NegocioMarca
    {

        private DatosMarca datos = new DatosMarca();

        public bool AgregarMarca(string param_descripcion)
        {
            var obj = new marca
            {
                descripcion_marca = param_descripcion
            };

            datos.InsertarMarca(obj);
            return true;
        }

        public List<marca> ListarMarcas()
        {
            var lst = datos.ObtenerMarcas();
            return lst;
        }

    }
}
