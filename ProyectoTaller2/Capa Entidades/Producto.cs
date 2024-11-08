using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller2.Capa_Entidades
{
    public class Producto
    {
        public int id_producto {  get; set; }
        public string nombre_producto { get; set; }
        public Marca oMarca { get; set; }
        public int stock {  get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public Categoria oCategoria { get; set; }
        public string estado_producto { get; set; }
        public int codigo_producto { get; set; }

        

    }
}
