using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Entidades
{
    public class Cliente
    {
        public int id_cliente {  get; set; }
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public int DNI_cliente { get; set; }
        public string telefono_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string email_cliente { get; set; }
        public string estado_cliente { get; set; }

    }
}
