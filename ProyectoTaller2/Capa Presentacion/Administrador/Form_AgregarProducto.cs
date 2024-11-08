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
    public partial class Form_AgregarProducto : Form
    {

        private Iform _form;
        public Form_AgregarProducto()
        {
            InitializeComponent();

           // _form = form;
        }

        private void Form_AgregarProducto_Load(object sender, EventArgs e)
        {
            LlenarCombos();
        }

        private void LlenarCombos()
        {
            using (var context = new proyecto_taller2Entities())
            {
                var categorias = context.categoria.Select(c => c.descripcion_categoria).ToList();
                comboCategoriaProd.DataSource = categorias;
                comboCategoriaProd.SelectedIndex = -1;

                var marcas = context.marca.Select(m => m.descripcion_marca).ToList();
                comboMarca.DataSource = marcas;
                comboMarca.SelectedIndex = -1;

            }

        }

        ErrorProvider errorP = new ErrorProvider();
        private CapaPresentacion.Administrador.Form_Admin form_Admin;

        private void txtStockProd_KeyPress(object sed, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtStockProd, "Solo numeros");
            else
                errorP.Clear();
        }

        private void txtPrecioProd_KeyPress(object sed, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtPrecioProd, "Solo numeros");
            else
                errorP.Clear();
        }
        private void botonAgregarProd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreProd.Text) || string.IsNullOrEmpty(txtStockProd.Text) ||
                string.IsNullOrEmpty(txtPrecioProd.Text) || string.IsNullOrEmpty(txtDescripProd.Text) ||
                comboMarca.SelectedItem == null || comboCategoriaProd.SelectedItem == null)
            {

                MessageBox.Show("Debe completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msg = MessageBox.Show("Esta seguro de añadir este producto?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    MessageBox.Show("El producto se agrego correctamente", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string nombre = txtNombreProd.Text;
                    string descripcion = txtDescripProd.Text;
                    int stock = Convert.ToInt32(txtStockProd.Text);
                    double precio = Convert.ToDouble(txtPrecioProd.Text);
                    int codigo = Convert.ToInt32(txtCodigoProd.Text);
                    //falta resolver marca
                    //falta resolver categoria
                    //var categoriaSeleccionada = (categoria)comboCategoriaProd.SelectedItem;
                    //int idCategoria = categoriaSeleccionada.id_categoria;

                    var context = new proyecto_taller2Entities();
                    string descCategoriaSeleccionada = comboCategoriaProd.SelectedItem.ToString();

                    categoria categoriaSeleccionada = context.categoria.SingleOrDefault(c => c.descripcion_categoria == descCategoriaSeleccionada);

                    int idCategoria = categoriaSeleccionada.id_categoria;


                    string descMarca = comboMarca.SelectedItem.ToString();

                    marca marcaSeleccionada = context.marca.SingleOrDefault(c => c.descripcion_marca == descMarca);

                    int idMarca = marcaSeleccionada.id_marca;

                    string estado = "Activo";

                    var nuevoProd = new NegocioProducto();
                    nuevoProd.AgregarProducto(codigo, nombre, idMarca, stock, precio, descripcion, idCategoria, estado);

                    txtDescripProd.Clear();
                    comboMarca.SelectedIndex = -1;
                    txtNombreProd.Clear();
                    txtPrecioProd.Clear();
                    txtStockProd.Clear();
                    comboCategoriaProd.SelectedIndex = -1;
                    txtCodigoProd.Clear();

                    this.Close();
                  //  dataGridProductos.Refresh();

                    /*
                    var nombre = txtNombreProd.Text;
                    var marca = txtMarcaProd.Text;
                    var stock = txtStockProd.Text;
                    var descrip = txtDescripProd.Text;
                    var precio = Convert.ToInt32(txtPrecioProd.Text);
                    var categoria = comboCategoriaProd.SelectedItem;

                    dataGridProductos.Rows.Add(nombre, marca, stock, precio, descrip, categoria);
                    

                    txtNombreProd.Clear();
                    txtMarcaProd.Clear();
                    txtStockProd.Clear();
                    txtDescripProd.Clear();
                    txtPrecioProd.Clear();
                    comboCategoriaProd.SelectedItem = null;
                    */

                }

            }
        }
    }
}
