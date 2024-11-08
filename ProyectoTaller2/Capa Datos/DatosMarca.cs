using System;
using System.Collections.Generic;
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
    }
}
