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
    public partial class Form_NuevaMarca : Form
    {

        private NegocioMarca objNegocioMarca;
        public Form_NuevaMarca()
        {
            InitializeComponent();
            objNegocioMarca = new NegocioMarca();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Crea una instancia de la clase Marca y establece su descripción
            Marca nuevaMarca = new Marca
            {
                descripcion_marca = textBox1.Text.Trim() // Suponiendo que el textbox se llama txtDescripcionMarca
            };

            // Variable para capturar el mensaje de salida
            string mensaje;

            // Llama al método Registrar de la capa de negocio
            int resultado = objNegocioMarca.Registrar(nuevaMarca, out mensaje);

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
