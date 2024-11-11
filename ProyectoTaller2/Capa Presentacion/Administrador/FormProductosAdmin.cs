using iTextSharp.text.pdf.codec.wmf;
using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Entidades;
using ProyectoTaller2.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
                // Obtener el estado del producto seleccionado
                string estado = dataGridProductos.SelectedRows[0].Cells["estadoprod"].Value.ToString();

                // Si el producto está inactivo, habilitar solo el botón de reactivar y deshabilitar los demás
                if (estado == "Inactivo")
                {
                    btnEliminarProd.Enabled = false;
                    btnEditarProd.Enabled = false;
                    btnReactivar.Visible = true;
                    btnReactivar.Enabled = true;
                }
                else
                {
                    // Si el producto está activo, habilitar los botones de eliminar y editar, y ocultar el botón de reactivar
                    btnEliminarProd.Enabled = true;
                    btnEditarProd.Enabled = true;
                    btnReactivar.Visible = false;
                }

            }
            else
            {
                btnEliminarProd.Enabled = false;
                btnEditarProd.Enabled = false;
                btnReactivar.Visible = false;
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
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idProducto = Convert.ToInt32(dataGridProductos.SelectedRows[0].Cells["idprod"].Value);

                // Confirmar la eliminación
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Llamar al método para realizar la baja lógica
                    DarDeBajaProducto(idProducto);

                    // Recargar los productos para reflejar los cambios
                    cargarProductos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
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
            /* using(var context = new proyecto_taller2Entities())
             {
                 var categorias = context.categoria.Select(c => c.descripcion_categoria).ToList();
                 comboCategoriaProd.DataSource = categorias;
                 comboCategoriaProd.SelectedIndex = -1;

                 var marcas = context.marca.Select(m => m.descripcion_marca).ToList();
                 comboMarca.DataSource = marcas;
                 comboMarca.SelectedIndex = -1;

             }*/

            // Cargar marcas activas en el combo box
            comboMarca.DataSource = ObtenerMarcasActivas();
            comboMarca.DisplayMember = "descripcion_marca";
            comboMarca.ValueMember = "id_marca";
            comboMarca.SelectedIndex = -1;


            // Cargar categorías activas en el combo box
            comboCategoriaProd.DataSource = ObtenerCategoriasActivas();
            comboCategoriaProd.DisplayMember = "descripcion_categoria";
            comboCategoriaProd.ValueMember = "id_categoria";            
            comboCategoriaProd.SelectedIndex = -1;

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
                                categoria = c.descripcion_categoria,
                                estadoprod = p.estado_producto
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
            dataGridProductos.Columns[0].Visible = false;
            dataGridProductos.Columns[1].HeaderText = "Codigo";
            dataGridProductos.Columns[2].HeaderText = "Nombre";
            dataGridProductos.Columns[3].HeaderText = "Marca";
            dataGridProductos.Columns[4].HeaderText = "Stock";
            dataGridProductos.Columns[5].HeaderText = "Precio";
            dataGridProductos.Columns[6].HeaderText = "Descripcion";
            dataGridProductos.Columns[7].HeaderText = "Categoria";
            dataGridProductos.Columns[8].HeaderText = "Estado del producto";
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
                // Obtener el estado del producto
                string estado = row.Cells["estadoprod"].Value.ToString();

                // Si el producto está inactivo, colorear toda la fila en gris
                if (estado == "Inactivo")
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Si el producto está activo, verificar si el stock es 0 y colorear solo la celda de stock
                    int stock = Convert.ToInt32(row.Cells["stock"].Value);
                    if (stock == 0)
                    {
                        row.Cells["stock"].Style.BackColor = Color.Red;
                        row.Cells["stock"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        // Restablecer el estilo de la celda de stock si no es 0
                        row.Cells["stock"].Style.BackColor = dataGridProductos.DefaultCellStyle.BackColor;
                        row.Cells["stock"].Style.ForeColor = dataGridProductos.DefaultCellStyle.ForeColor;
                    }

                    // Restablecer el estilo de la fila para productos activos
                    row.DefaultCellStyle.BackColor = dataGridProductos.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dataGridProductos.DefaultCellStyle.ForeColor;
                }


            }
        }

        private void DarDeBajaProducto(int idProducto)
        {
            using (var context = new proyecto_taller2Entities())
            {
                // Buscar el producto en la base de datos
                var producto = context.productos.FirstOrDefault(p => p.id_producto == idProducto);
                if (producto != null)
                {
                    // Cambiar el estado del producto a "Inactivo"
                    producto.estado_producto = "Inactivo";

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto seleccionado.");
                }
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idProducto = Convert.ToInt32(dataGridProductos.SelectedRows[0].Cells["idprod"].Value);

                // Confirmar la reactivación
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas reactivar este producto?",
                                                    "Confirmar reactivación",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Llamar al método para reactivar el producto
                    ReactivarProducto(idProducto);

                    // Recargar los productos para reflejar los cambios
                    cargarProductos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para reactivar.");
            }
        }

        private void ReactivarProducto(int idProducto)
        {
            using (var context = new proyecto_taller2Entities())
            {
                // Buscar el producto en la base de datos
                var producto = context.productos.FirstOrDefault(p => p.id_producto == idProducto);
                if (producto != null)
                {
                    // Cambiar el estado del producto a "Activo"
                    producto.estado_producto = "Activo";

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto seleccionado.");
                }
            }
        }

        public List<Categoria> ObtenerCategoriasActivas()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_categoria, descripcion_categoria FROM categoria WHERE estado_categoria = 'Activo'", conexion);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaCategorias.Add(new Categoria
                        {
                            id_categoria = Convert.ToInt32(dr["id_categoria"]),
                            descripcion_categoria = dr["descripcion_categoria"].ToString()
                        });
                    }
                }
            }
            return listaCategorias;
        }

        public List<Marca> ObtenerMarcasActivas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_marca, descripcion_marca FROM marca WHERE estado_marca = 'Activo'", conexion);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaMarcas.Add(new Marca
                        {
                            id_marca = Convert.ToInt32(dr["id_marca"]),
                            descripcion_marca = dr["descripcion_marca"].ToString()
                        });
                    }
                }
            }
            return listaMarcas;
        }

    }


}
