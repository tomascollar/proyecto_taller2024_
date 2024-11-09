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

            if (dataGridProductos.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dataGridProductos.SelectedRows[0].Cells["idprod"].Value);

                using (var context = new proyecto_taller2Entities())
                {
                    // Buscar el producto en la base de datos
                    var producto = context.productos.SingleOrDefault(p => p.id_producto == idProducto);

                    if (producto != null)
                    {
                        // Actualizar los campos del producto con los valores de los TextBox y ComboBox
                        producto.nombre_producto = txtNombreProd.Text;
                        producto.stock = int.Parse(txtStockProd.Text);
                        producto.precio = double.Parse(txtPrecioProd.Text);
                        producto.descripcion = txtDescripProd.Text;

                        // Obtener la marca seleccionada
                        string descMarcaSeleccionada = comboMarca.Text;
                        var marca = context.marca.SingleOrDefault(m => m.descripcion_marca == descMarcaSeleccionada);
                        if (marca != null)
                        {
                            producto.id_marca = marca.id_marca;
                        }

                        // Obtener la categoría seleccionada
                        string descCategoriaSeleccionada = comboCategoriaProd.Text;
                        var categoria = context.categoria.SingleOrDefault(c => c.descripcion_categoria == descCategoriaSeleccionada);
                        if (categoria != null)
                        {
                            producto.id_categoria = categoria.id_categoria;
                        }

                        // Guardar cambios en la base de datos
                        context.SaveChanges();

                        MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNombreProd.Text = "";
                        txtDescripProd.Text = "";
                        txtPrecioProd.Text = "";
                        txtStockProd.Text = "";
                        comboCategoriaProd.SelectedIndex = -1;
                        comboMarca.SelectedIndex = -1;



                        // Recargar el DataGridView
                        cargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para editar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void dataGridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboMarca.Text = dataGridProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtStockProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrecioProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDescripProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboCategoriaProd.Text = dataGridProductos.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void FormProductosAdmin_Load(object sender, EventArgs e)
        {
            LlenarCombos();
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

            this.formato();
            dataGridProductos.ClearSelection();

            // Pintar las filas con stock 0
            foreach (DataGridViewRow row in dataGridProductos.Rows)
            {
                int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                if (stock == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White; // Cambia el texto a blanco para visibilidad
                }
            }

        }

        private void formato()
        {
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
                // Desactiva temporalmente el modo de administración de divisa
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridProductos.DataSource];
                currencyManager.SuspendBinding();

                foreach (DataGridViewRow row in dataGridProductos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textBox1.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }

                // Reactiva el modo de administración de divisa
                currencyManager.ResumeBinding();
            }
        }

        private void dataGridProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridProductos.Rows)
            {
                int stock = Convert.ToInt32(row.Cells["stock"].Value);
                if (stock == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White; // Cambia el texto a blanco para visibilidad
                }
            }
        }
    }
}
