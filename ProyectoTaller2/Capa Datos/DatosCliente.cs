using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoTaller2.Capa_Datos
{
    internal class DatosCliente
    {
        public void InsertarCliente(clientes nuevoCliente)
        {
            using(var context = new proyecto_taller2Entities())
            {
                context.clientes.Add(nuevoCliente);
                context.SaveChanges();
            }
        }

        public List<clientes> ObtenerClientes()
        {
            using(var context = new proyecto_taller2Entities())
            {
                return context.clientes.ToList();
            }
        }


    }
}
