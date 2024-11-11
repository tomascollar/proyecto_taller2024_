using ProyectoTaller2.Capa_Entidades;
using ProyectoTaller2.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    public partial class Form_NuevaCategoria : Form
    {
        private NegocioCategoria objNegocioCategoria;

        public Form_NuevaCategoria()
        {
            InitializeComponent();
            objNegocioCategoria = new NegocioCategoria();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Crea una instancia de la clase Categoria y establece su descripción
            Categoria nuevaCategoria = new Categoria
            {
                descripcion_categoria = textBox1.Text.Trim() // Suponiendo que el textbox se llama txtDescripcionCategoria
            };

            // Variable para capturar el mensaje de salida
            string mensaje;

            // Llama al método Registrar de la capa de negocio
            int resultado = objNegocioCategoria.Registrar(nuevaCategoria, out mensaje);

            // Verifica si el resultado es exitoso o muestra el mensaje de error
            if (resultado > 0)
            {
                MessageBox.Show("Categoría registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
