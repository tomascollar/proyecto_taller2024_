using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Datos
{
    internal class DatosProducto
    {
        public void InsertarProducto(productos nuevoProducto)
        {
            using(var context = new proyecto_taller2Entities())
            {
                context.productos.Add(nuevoProducto);
                context.SaveChanges();
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
