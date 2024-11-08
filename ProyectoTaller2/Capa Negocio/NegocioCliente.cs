using ProyectoTaller2.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Negocio
{
    internal class NegocioCliente
    {

        private DatosCliente datos = new DatosCliente();

        public bool AgregarCliente(string nombre, string apellido, int dni, string telefono, string direccion, string email, string estado)
        {
            var obj = new clientes
            {
                nombre_cliente = nombre,
                apellido_cliente = apellido,
                DNI_cliente = dni,
                telefono_cliente = telefono,
                direccion_cliente = direccion,
                email_cliente = email,
                estado_cliente = estado
            };

            datos.InsertarCliente(obj);

            return true;
        }

        public List<clientes> ListarClientes()
        {
            var lst = datos.ObtenerClientes();
            return lst;
        }

    }
}
