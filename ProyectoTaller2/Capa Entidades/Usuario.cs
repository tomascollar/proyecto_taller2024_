using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Entidades
{
    public class Usuario
    {

        public int id_usuario {  get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string telefono_usuario { get; set; }
        public string usuario {  get; set; }
        public string contraseña { get; set; }
        public Tipo_usuario oTipo_Usuario { get; set; }
        public string estado_usuario { get; set; }

    }
}
