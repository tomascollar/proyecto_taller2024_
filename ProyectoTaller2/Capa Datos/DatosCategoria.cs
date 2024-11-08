using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Datos
{
    internal class DatosCategoria
    {
        public void InsertarCategoria(categoria nuevaCategoria)
        {
            using(var context = new proyecto_taller2Entities())
            {
                context.categoria.Add(nuevaCategoria);
                context.SaveChanges();
            }
        }

        public List<categoria> ObtenerCategorias()
        {
            using (var context = new proyecto_taller2Entities())
            {
                return context.categoria.ToList();

            }
        }
    }
}
