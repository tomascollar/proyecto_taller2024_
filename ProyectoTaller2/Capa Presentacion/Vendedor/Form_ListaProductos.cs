using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2.Capa_Presentacion.Vendedor
{
    public partial class Form_ListaProductos : Form
    {
        public productos _Producto { get; set; }  
        public Form_ListaProductos()
        {
            InitializeComponent();
        }

        private void Form_ListaProductos_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dataGridListaProductos.Columns)
            {
                comboListarProducto.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            comboListarProducto.DisplayMember = "Texto";
            comboListarProducto.ValueMember = "Valor";
           // comboListarProducto.SelectedIndex = 0;



            using (var context = new proyecto_taller2Entities())
            {
                var query = from p in context.productos
                            join m in context.marca on p.id_marca equals m.id_marca
                            join c in context.categoria on p.id_categoria equals c.id_categoria
                            where p.stock > 0
                            select new
                            {
                                idprod = p.id_producto,
                                codigoproducto = p.codigo_producto,
                                nombre = p.nombre_producto,        
                                categoria = c.descripcion_categoria,
                                stock = p.stock,
                                precio = p.precio,
                                descripcion = p.descripcion,
                                desc_marca = m.descripcion_marca
                            };
                dataGridListaProductos.DataSource = query.ToList();
            }

            this.formato();

        }

        private void formato()
        {
            dataGridListaProductos.Columns[0].Width = 50;
            dataGridListaProductos.Columns[0].HeaderText = "Id";
            dataGridListaProductos.Columns[1].HeaderText = "Codigo";
            dataGridListaProductos.Columns[2].HeaderText = "Nombre";
            dataGridListaProductos.Columns[3].HeaderText = "Categoria";
            dataGridListaProductos.Columns[4].Visible = false;
            dataGridListaProductos.Columns[5].Visible = false;
            dataGridListaProductos.Columns[6].Visible = false;
            dataGridListaProductos.Columns[7].Visible = false;


            //dataGridListaProductos.Columns[3].HeaderText = "Precio";
        }

        ErrorProvider errorP = new ErrorProvider();
        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedItem = comboListarProducto.SelectedItem.ToString();

            if (selectedItem == "Codigo")
            {
                bool valida = Validar.soloNumeros(e);
                if (!valida)
                    errorP.SetError(txtBuscarProducto, "Solo numeros");
                else
                    errorP.Clear();
            }
            else
            {
                bool valida = Validar.soloLetras(e);
                if (!valida)
                    errorP.SetError(txtBuscarProducto, "Solo letras");
                else
                    errorP.Clear();
            }
        }

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            bool validaTxt = Validar.txtVacios(txtBuscarProducto);
            if (validaTxt)
                errorP.SetError(txtBuscarProducto, "Debe completar este campo");
            else
                errorP.Clear();

            string columnaFiltro = ((OpcionCombo)comboListarProducto.SelectedItem).Valor.ToString();

            if (dataGridListaProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridListaProductos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscarProducto.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Text = "";
            foreach (DataGridViewRow row in dataGridListaProductos.Rows)
            {
                row.Visible = true;
            }
        }

        private void dataGridListaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn >= 0)
            {
                _Producto = new productos()
                {
                    id_producto = Convert.ToInt32(dataGridListaProductos.Rows[iRow].Cells[0].Value),
                    codigo_producto = Convert.ToInt32(dataGridListaProductos.Rows[iRow].Cells[1].Value),
                    nombre_producto = dataGridListaProductos.Rows[iRow].Cells[2].Value.ToString(),
                    precio = Convert.ToDouble(dataGridListaProductos.Rows[iRow].Cells[5].Value),
                    stock = Convert.ToInt32(dataGridListaProductos.Rows[iRow].Cells[4].Value)

                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
