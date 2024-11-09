using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Datos
{
    internal class DatosProducto
    {
        public bool InsertarProducto(productos nuevoProducto)
        {
            /*using(var context = new proyecto_taller2Entities())
            {
                context.productos.Add(nuevoProducto);
                context.SaveChanges();
            }*/

            using (var context = new proyecto_taller2Entities())
            {
                // Verificar si el código ya existe
                var productoExistente = context.productos
                    .SingleOrDefault(p => p.codigo_producto == nuevoProducto.codigo_producto);

                if (productoExistente != null)
                {
                    return false; // Código ya existe
                }

                // Si no existe, agregar el nuevo producto
                context.productos.Add(nuevoProducto);
                context.SaveChanges();
                return true; // Inserción exitosa
            }

        }

        public List<productos> ObtenerProductos()
        {
            using (var context = new proyecto_taller2Entities())
            {

                  return context.productos.ToList();// Esto funciona bien


                //esto es prueba 

            }

           
        }

        public class ProductoViewModel
        {
            public int ProductoId { get; set; }
            // Otros campos de productos
            public string DescripcionMarca { get; set; }
        }
    }
}
