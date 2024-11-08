using ProyectoTaller2.Capa_Entidades;
using ProyectoTaller2.Capa_Negocio;
using ProyectoTaller2.Capa_Presentacion.Vendedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2
{
    public partial class FormVenta : Form
    {
        private Usuario _Usuario;
        private Iform _form;
        FormProducto formularioPrincipal;
        public FormVenta(Iform form, Usuario oUsuario = null)
        {
            InitializeComponent();
            _form = form;

            _Usuario = oUsuario;
        }

        public FormVenta(Iform form, DataGridViewRow dtg)
        {
            InitializeComponent();
            _form = form;

            

            /*foreach(DataGridViewRow row in dtg.Rows)
            {
                dataGridVenta.Rows.Add();
                dataGridVenta.Rows[row.Index].Cells["Column1"].Value = row.Cells[0].Value;
                dataGridVenta.Rows[row.Index].Cells["Column2"].Value = row.Cells[1].Value;
                dataGridVenta.Rows[row.Index].Cells["Column3"].Value = row.Cells[2].Value;
                dataGridVenta.Rows[row.Index].Cells["Column4"].Value = row.Cells[3].Value;
                dataGridVenta.Rows[row.Index].Cells["Column5"].Value = row.Cells[4].Value;
                dataGridVenta.Rows[row.Index].Cells["Column6"].Value = row.Cells[5].Value;
                dataGridVenta.Rows[row.Index].Cells["Column7"].Value = row.Cells[6].Value;
            }*/

            if(dtg != null)
            {
                dataGridVenta.Rows.Add(
                dtg.Cells[0].Value,
                dtg.Cells[1].Value,
                dtg.Cells[2].Value,
                dtg.Cells[3].Value,
                dtg.Cells[4].Value,
                dtg.Cells[5].Value,
                dtg.Cells[6].Value
                // Agrega más celdas según sea necesario
            );
            }

            dataGridVenta.Columns[0].Width = 50;
            dataGridVenta.Columns[0].HeaderText = "ID";
            dataGridVenta.Columns[1].HeaderText = "Nombre";
            dataGridVenta.Columns[2].HeaderText = "Marca";
            dataGridVenta.Columns[3].HeaderText = "Stock";
            dataGridVenta.Columns[4].HeaderText = "Precio";
            dataGridVenta.Columns[5].HeaderText = "Descripcion";
            dataGridVenta.Columns[6].HeaderText = "Categoria";

        }

        public FormVenta(Iform form, DataGridView dtg, FormProducto formulario)
        {
            InitializeComponent();
            formularioPrincipal = formulario;
        }

        

        private void dataGridVenta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void dataGridVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* DataGridViewRow row = dataGridVenta.Rows[e.RowIndex];
            DataGridViewCell deleteCell = row.Cells["eliminarCarrito"];
            DataGridViewCell nombreCell = row.Cells["nombreProd"];



            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn columna = dataGridVenta.Columns[e.ColumnIndex];
                if (columna.Name != "eliminarCarrito")
                {

                    //desactivamos el evento click en celdas q no sean del tipo boton
                    dataGridVenta.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;

                }
                else {

                    if (string.IsNullOrEmpty(Convert.ToString(nombreCell.Value)))
                    {
                        deleteCell.ReadOnly = true;
                    }
                    else
                    {
                        //Desactivamos el read only asi podemos usar el boton
                        deleteCell.ReadOnly = false;
                        var msg = MessageBox.Show("Desea eliminar el producto?", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.Yes)
                        {

                            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridVenta.Columns["eliminarCarrito"].Index)
                            {
                                //Eliminamos la fila correspondiente
                                dataGridVenta.Rows.RemoveAt(e.RowIndex);

                            }
                            MessageBox.Show("Producto eliminado del carrito correctamente", "Quitar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }*/
        }


        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            if(txtBoxDni.Text == "")
            {
                MessageBox.Show("Debe ingresar el dni del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtBoxNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(dataGridVenta.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable detalle_venta = new DataTable();

            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("Precio", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("Subtotal", typeof(decimal));
            

            foreach(DataGridViewRow row in dataGridVenta.Rows)
            {
                detalle_venta.Rows.Add(new object[]
                {
                    row.Cells["IdProducto"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Subtotal"].Value.ToString()
                });
            }

            int id_correlativo = new NegocioFactura().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:0000}", id_correlativo);

            Factura oFactura = new Factura()
            {
                oUsuario = new Usuario() { id_usuario = _Usuario.id_usuario },
                tipo_documento = cboTipoDocumento.SelectedItem.ToString(),
                numero_documento = numeroDocumento,
                dni_cliente = txtBoxDni.Text,
                nombre_cliente = txtBoxNombre.Text,
                monto_total = Convert.ToDecimal(txtTotalAPagar.Text),
            };

            string mensaje = string.Empty;
            bool respuesta = new NegocioFactura().Registrar(oFactura, detalle_venta, out mensaje);

            if(respuesta)
            {
                var result = MessageBox.Show("Numero de venta generada:\n" + numeroDocumento +
                    "\n\n ¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if(result == DialogResult.Yes)
                    Clipboard.SetText(numeroDocumento);

                txtBoxDni.Text = "";
                txtBoxNombre.Text = "";
                dataGridVenta.Rows.Clear();
                txtTotalAPagar.Text = "0";
            }
            else
            {
                MessageBox.Show(mensaje , "Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void dataGridVenta_SelectionChanged(object sender, EventArgs e)
        {
           /* if(dataGridVenta.SelectedRows.Count > 0)
            {
                btnRealizarVenta.Enabled = true;
            }
            else
            {
                btnRealizarVenta.Enabled=false;
            }*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Desea cancelar esta venta?", "Cancelar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                dataGridVenta.Rows.Clear();
                txtTotalAPagar.Text = "0";
                txtBoxDni.Clear();
                txtBoxNombre.Clear();

                txtIdProd.Clear();
                txtCodProd.Clear();
                txtPrecioProducto.Clear();
                txtStockProducto.Clear();
                cantidadProducto.Value = 1;

            }

            //this.Close();
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.SelectedIndex = 0;
            
            // Suscribirse al evento del formulario principal para recibir notificaciones de productos agregados al carrito.
            if (formularioPrincipal != null)
            {
                formularioPrincipal.ProductoAgregadoAlCarrito += FormularioPrincipal_ProductoAgregadoAlCarrito;
            }

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void FormularioPrincipal_ProductoAgregadoAlCarrito(object sender, ProductoEventArgs e)
        {
            // Agregar el producto al DataGridView del carrito.
           // AgregarProductoAlCarrito(e.ProductoAgregado);
           // MessageBox.Show("Producto agregado al carrito");
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            // Form_ListaProductos form_ListaProductos = new Form_ListaProductos();
            // form_ListaProductos.ShowDialog();
            using (var modal = new Form_ListaProductos())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtIdProd.Text = modal._Producto.id_producto.ToString();
                    txtCodProd.Text = modal._Producto.codigo_producto.ToString();
                    txtProducto.Text = modal._Producto.nombre_producto.ToString();
                    txtPrecioProducto.Text = modal._Producto.precio.ToString();
                    txtStockProducto.Text = modal._Producto.stock.ToString();
                    cantidadProducto.Select();
                    
                }
                else
                {
                    txtCodProd.Select();
                }
            }

        }

        private void btnClienteVenta_Click(object sender, EventArgs e)
        {
           // Form_ListaClientes form_ListaClientes = new Form_ListaClientes();
           // form_ListaClientes.ShowDialog();

            using (var modal = new Form_ListaClientes())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    
                    txtBoxDni.Text = modal._cliente.DNI_cliente.ToString();
                    txtBoxNombre.Text = modal._cliente.nombre_cliente;
                    txtCodProd.Select();
                }
                else
                {
                    txtBoxDni.Select();
                }
            }

 
        }

        ErrorProvider errorP = new ErrorProvider();
        private void txtCodProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtCodProd, "Solo numeros");
            else
                errorP.Clear();
        }

        private void btnAgregarProductoVenta_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            if(txtIdProd.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioProducto.Text, out precio))
            {
                MessageBox.Show("Precio - Formato incorrecto", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioProducto.Select();
                return;
            }

            if(Convert.ToInt32(txtStockProducto.Text) < Convert.ToInt32(cantidadProducto.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dataGridVenta.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null &&  fila.Cells["IdProducto"].Value.ToString() == txtIdProd.Text)
                {
                    producto_existe = true;
                    break;
                }
            }


            if (!producto_existe)
            {

                 bool respuesta = new NegocioFactura().RestarStock(
                     Convert.ToInt32(txtIdProd.Text),
                     Convert.ToInt32(cantidadProducto.Value.ToString())
                     );

                 if (respuesta)
                 {
                     dataGridVenta.Rows.Add(new object[]
                     {
                      txtIdProd.Text,
                      txtProducto.Text,
                       txtPrecioProducto.Text,
                       cantidadProducto.Value.ToString(),
                       (cantidadProducto.Value * precio).ToString("0.00")

                      });

                     calcularTotal();
                     limpiarProducto();
                     txtCodProd.Select();
                 }
               /* dataGridVenta.Rows.Add(new object[]
                     {
                     txtIdProd.Text,
                     txtProducto.Text,
                      txtPrecioProducto.Text,
                      cantidadProducto.Value.ToString(),
                      (cantidadProducto.Value * precio).ToString("0.00")

                      });

                calcularTotal();
                limpiarProducto();
                txtCodProd.Select();*/

            }



        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dataGridVenta.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridVenta.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }

            txtTotalAPagar.Text = total.ToString("0.00");
        }

        private void limpiarProducto()
        {
            txtIdProd.Text = "";
            txtCodProd.Text = "";
            txtProducto.Text = "";
            txtPrecioProducto.Text = "";
            txtStockProducto.Text = "";
            cantidadProducto.Value = 1;

        }

        private void dataGridVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Tamaño deseado para la imagen en el botón
                int desiredWidth = 30;
                int desiredHeight = 20;

                // Escalar la imagen al tamaño deseado
                var resizedImage = new Bitmap(Properties.Resources.delete25, new Size(desiredWidth, desiredHeight));

                // Calcular posición para centrar la imagen
                var x = e.CellBounds.Left + (e.CellBounds.Width - desiredWidth) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - desiredHeight) / 2;

                e.Graphics.DrawImage(resizedImage, new Rectangle(x, y, desiredWidth, desiredHeight));
                e.Handled = true;

                // Liberar recursos de la imagen escalada
                resizedImage.Dispose();



                /*Esto funciona pero imagen grande
                var w = Properties.Resources.delete25.Width;
                var h = Properties.Resources.delete25.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 3;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 3;

                e.Graphics.DrawImage(Properties.Resources.delete25, new Rectangle(x, y, w, h));
                e.Handled = true;

                */
            }
        }

        private void dataGridVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridVenta.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {

                    bool respuesta = new NegocioFactura().SumarStock(
                        Convert.ToInt32(dataGridVenta.Rows[index].Cells["IdProducto"].Value.ToString()),
                        Convert.ToInt32(dataGridVenta.Rows[index].Cells["Cantidad"].Value.ToString())
                        );

                    if (respuesta)
                    {
                        dataGridVenta.Rows.RemoveAt(index);
                        calcularTotal();
                    }

                    
                }
            }
        }

        private void txtCodProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                productos oProducto = new NegocioProducto().ListarProductos().
                    Where(p => p.codigo_producto.ToString() == txtCodProd.Text && p.estado_producto == "Activo")
                    .FirstOrDefault();

                if (oProducto != null)
                {
                    txtCodProd.BackColor = Color.Honeydew;
                    txtIdProd.Text = oProducto.id_producto.ToString();
                    txtProducto.Text = oProducto.nombre_producto;
                    txtPrecioProducto.Text = oProducto.precio.ToString();
                    txtStockProducto.Text = oProducto.stock.ToString();

                    cantidadProducto.Select();
                }
                else
                {
                    MessageBox.Show("El producto no existe",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodProd.BackColor = Color.MistyRose;
                    txtIdProd.Text = "";
                    txtProducto.Text = "";
                    txtPrecioProducto.Text = "";
                    txtStockProducto.Text = "";
                    cantidadProducto.Value = 1;
                }
            }
        }
    }
}
