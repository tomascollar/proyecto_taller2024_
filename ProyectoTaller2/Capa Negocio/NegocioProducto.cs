using ProyectoTaller2.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Negocio
{
    internal class NegocioProducto
    {

        private DatosProducto datos = new DatosProducto();

        public bool AgregarProducto(int codigo ,string nombre, int marca, int param_stock, double param_precio, string param_descripcion, int categoria, string estado)
        {
            var obj = new productos
            {
                codigo_producto = codigo,
                nombre_producto = nombre,
                id_marca = marca,
                stock = param_stock,
                precio = param_precio,
                descripcion = param_descripcion,
                id_categoria = categoria,
                estado_producto = estado

            };

            /*datos.InsertarProducto(obj);
            return true;*/

            return datos.InsertarProducto(obj);
        }

        public List<productos> ListarProductos()
        {
            var lst = datos.ObtenerProductos();
            return lst;
        }
    }
}
