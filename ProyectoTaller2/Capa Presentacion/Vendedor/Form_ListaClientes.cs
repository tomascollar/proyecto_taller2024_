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

namespace ProyectoTaller2.Capa_Presentacion.Vendedor
{
    public partial class Form_ListaClientes : Form
    {

        public clientes _cliente {  get; set; }

        ErrorProvider errorP = new ErrorProvider();
        public Form_ListaClientes()
        {
            InitializeComponent();
        }

        private void Form_ListaClientes_Load(object sender, EventArgs e)
        {
            comboListarCliente.SelectedIndex = 0;
            //CargarClientes();

            List<clientes> lista = new NegocioCliente().ListarClientes();

            foreach (clientes item in lista)
            {
                if(item.estado_cliente == "Activo")
                    dataGridView1.Rows.Add(new object[] { item.DNI_cliente, item.nombre_cliente });
            }
        }

        private void CargarClientes()
        {
            var negocioCliente = new NegocioCliente();

            var datos = negocioCliente.ListarClientes();

            dataGridView1.DataSource = datos;
            this.formato();
        }

        private void formato()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].HeaderText = "DNI";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
           // dataGridView1.Columns[8].Visible = false;

        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedItem = comboListarCliente.SelectedItem.ToString();

            if(selectedItem == "DNI")
            {
                bool valida = Validar.soloNumeros(e);
                if (!valida)
                    errorP.SetError(txtBuscarCliente, "Solo numeros");
                else
                    errorP.Clear();
            }
            else
            {
                bool valida = Validar.soloLetras(e);
                if (!valida)
                    errorP.SetError(txtBuscarCliente, "Solo letras");
                else
                    errorP.Clear();
            }


        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            bool validaVacio = Validar.txtVacios(txtBuscarCliente);
            if (validaVacio)
                errorP.SetError(txtBuscarCliente, "Debe completar este campo");
            else
                errorP.Clear();

            string columnaFiltro = ((OpcionCombo)comboListarCliente.SelectedItem).Valor.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscarCliente.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }

            // string columnaFiltro = 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn >= 0)
            {
                _cliente = new clientes()
                {
                    DNI_cliente = Convert.ToInt32(dataGridView1.Rows[iRow].Cells["columna_DNI"].Value),
                    nombre_cliente = dataGridView1.Rows[iRow].Cells["columna_Nombre"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Text = "";
            foreach (DataGridView row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
