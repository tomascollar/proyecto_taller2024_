using ProyectoTaller2.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    public partial class FormProductosAdmin : Form
    {

       


        public FormProductosAdmin()
        {
            InitializeComponent();
            //Desactivamos los botones del inicio ya que no hay ninguna columna seleccionada
            btnEliminarProd.Enabled = false;
            btnEditarProd.Enabled = false;

            //_form = form;
        }



        private void dataGridProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                btnEliminarProd.Enabled = true;
                btnEditarProd.Enabled = true;
                //btnAgregarProd.Enabled = false;

            }
            else
            {
                btnEliminarProd.Enabled = false;
                btnEditarProd.Enabled = false;
            }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            Form_AgregarProducto _form = new Form_AgregarProducto();
            _form.ShowDialog();


            /*   if (string.IsNullOrEmpty(txtNombreProd.Text) || string.IsNullOrEmpty(txtStockProd.Text) ||
                   string.IsNullOrEmpty(txtPrecioProd.Text) || string.IsNullOrEmpty(txtDescripProd.Text) ||
                   comboMarca.SelectedItem == null || comboCategoriaProd.SelectedItem == null ) {

                   MessageBox.Show("Debe completar todos los campos","Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


                       var nuevoProd = new NegocioProducto();
                       nuevoProd.AgregarProducto(nombre, idMarca, stock, precio, descripcion, idCategoria);

                       txtDescripProd.Clear();
                       comboMarca.SelectedIndex = -1;
                       txtNombreProd.Clear();
                       txtPrecioProd.Clear();
                       txtStockProd.Clear();
                       comboCategoriaProd.SelectedIndex = -1;

                       dataGridProductos.Refresh();
            */

            //HAsta aca funcionaba bien

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

    
        

        ErrorProvider errorP =  new ErrorProvider();
     //   private CapaPresentacion.Administrador.Form_Admin form_Admin;

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

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            int filaSeleccionada;
            filaSeleccionada = dataGridProductos.CurrentRow.Index;
            
            var msg = MessageBox.Show("Seguro desea eliminar este producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {


                dataGridProductos.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.Red;
                
            }
        }

        private void btnEditarProd_Click(object sender, EventArgs e)
        {

            int filaSeleccionada;
            filaSeleccionada = dataGridProductos.CurrentRow.Index;

            if (string.IsNullOrEmpty(txtNombreProd.Text) || string.IsNullOrEmpty(txtStockProd.Text) ||
                string.IsNullOrEmpty(txtPrecioProd.Text) || string.IsNullOrEmpty(txtDescripProd.Text) ||
                comboMarca.SelectedItem == null || comboCategoriaProd.SelectedItem == null)
            {

                MessageBox.Show("Debe completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var msg = MessageBox.Show("Esta seguro que desea editar este producto con los campos escritos?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    var nombre = txtNombreProd.Text;
                    var marca = comboMarca.SelectedItem;
                    var stock = Convert.ToInt32(txtStockProd.Text);
                    var descrip = txtDescripProd.Text;
                    var precio = Convert.ToInt32(txtPrecioProd.Text);
                    var categoria = comboCategoriaProd.SelectedItem;

                    dataGridProductos[1, filaSeleccionada].Value = nombre;
                    dataGridProductos[2, filaSeleccionada].Value = marca;
                    dataGridProductos[3, filaSeleccionada].Value = stock;
                    dataGridProductos[4, filaSeleccionada].Value = precio;
                    dataGridProductos[5, filaSeleccionada].Value = descrip;
                    dataGridProductos[6, filaSeleccionada].Value = categoria;
 

                    

                    txtNombreProd.Clear();
                    comboMarca.SelectedItem = null;
                    txtStockProd.Clear();
                    txtDescripProd.Clear();
                    txtPrecioProd.Clear();
                    comboCategoriaProd.SelectedItem = null;

                }

            }
        }

        private void dataGridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboMarca.Text = dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtStockProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrecioProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDescripProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboCategoriaProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void FormProductosAdmin_Load(object sender, EventArgs e)
        {
            //LlenarCombos();
            cargarProductos();

            foreach (DataGridViewColumn columna in dataGridProductos.Columns)
            {
                comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;

        }

        private void LlenarCombos()
        {
            using(var context = new proyecto_taller2Entities())
            {
                var categorias = context.categoria.Select(c => c.descripcion_categoria).ToList();
                comboCategoriaProd.DataSource = categorias;
                comboCategoriaProd.SelectedIndex = -1;

                var marcas = context.marca.Select(m => m.descripcion_marca).ToList();
                comboMarca.DataSource = marcas;
                comboMarca.SelectedIndex = -1;

            }
            
        }

        private void cargarProductos()
        {
            var negocioProducto = new NegocioProducto();
            var datos = negocioProducto.ListarProductos();

            using (var context = new proyecto_taller2Entities())
            {
                var query = from p in context.productos 
                            join m in context.marca on p.id_marca equals m.id_marca
                            join c in context.categoria on p.id_categoria equals c.id_categoria
                            select new
                            {
                                idprod = p.id_producto,
                                codigoproducto = p.codigo_producto,
                                nombre = p.nombre_producto,
                                desc_marca = m.descripcion_marca,
                                stock = p.stock,
                                precio = p.precio,
                                descripcion = p.descripcion,
                                categoria = c.descripcion_categoria
                            };
                dataGridProductos.DataSource = query.ToList();
            }


              //  dataGridProductos.DataSource = datos;

            

            this.formato();

            dataGridProductos.ClearSelection();
        }

        private void formato()
        {

            //dataGridProductos.Columns[7].Visible = false;
            //dataGridProductos.Columns[8].Visible = false;
            //dataGridProductos.Columns[9].Visible = false;
            dataGridProductos.Columns[0].Width = 50;
            dataGridProductos.Columns[0].HeaderText = "Id";
            dataGridProductos.Columns[1].HeaderText = "Codigo";
            dataGridProductos.Columns[2].HeaderText = "Nombre";
            dataGridProductos.Columns[3].HeaderText = "Marca";
            dataGridProductos.Columns[4].HeaderText = "Stock";
            dataGridProductos.Columns[5].HeaderText = "Precio";
            dataGridProductos.Columns[6].HeaderText = "Descripcion";
            dataGridProductos.Columns[7].HeaderText = "Categoria";




        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (DataGridViewRow row in dataGridProductos.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)comboBox1.SelectedItem).Valor.ToString();

            if (dataGridProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridProductos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textBox1.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }
    }
}
