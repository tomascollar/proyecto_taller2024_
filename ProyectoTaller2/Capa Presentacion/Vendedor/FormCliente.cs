using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ProyectoTaller2.CapaPresentacion.SuperAdmin;
using ProyectoTaller2.Capa_Presentacion.Vendedor;
using ProyectoTaller2.Capa_Negocio;

namespace ProyectoTaller2
{
    public partial class FormCliente : Form
    {
        //defino el _form que va a guardar el form recibido como parametro
        //para poder utilizar la interfaz
        private Iform _form;

        public FormCliente(Iform form)
        {
            InitializeComponent();
            _form = form;
        }

        private void CargarClientes()
        {
            var negocioCliente = new NegocioCliente();

            var datos = negocioCliente.ListarClientes();

            dataGridView1.DataSource = datos;
            this.formato();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;

        }

        private void formato()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NOMBRE";
            dataGridView1.Columns[2].HeaderText = "APELLIDO";
            dataGridView1.Columns[3].HeaderText = "DNI";
            dataGridView1.Columns[4].HeaderText = "TELEFONO";
            dataGridView1.Columns[5].HeaderText = "DIRECCION";
            dataGridView1.Columns[6].HeaderText = "EMAIL";
            dataGridView1.Columns[7].HeaderText = "ESTADO";
            //dataGridView1.Columns[8].Visible = false;

        }


        ErrorProvider errorP = new ErrorProvider();

        private void txtDniCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool valida = Validar.txtVacios(txtCliente);
            if (valida)
                errorP.SetError(txtCliente, "Debe completar este campo");
            else
                errorP.Clear();

            string columnaFiltro = ((OpcionCombo)comboBox1.SelectedItem).Valor.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                // Desactiva temporalmente el modo de administración de divisa
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtCliente.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }

                // Reactiva el modo de administración de divisa
                currencyManager.ResumeBinding();
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _form.openChildForm(new FormRegistroCliente(_form));
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Obtengo la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                //Obtengo los valores de las celdas
               // string id = filaSeleccionada.Cells[1].Value.ToString();
                string nombre = filaSeleccionada.Cells[1].Value.ToString();
                string apellido = filaSeleccionada.Cells[2].Value.ToString();
                string DNI = filaSeleccionada.Cells[3].Value.ToString();
                string telefono = filaSeleccionada.Cells[4].Value.ToString();
                string direccion = filaSeleccionada.Cells[5].Value.ToString();
                string email = filaSeleccionada.Cells[6].Value.ToString();
               // string estado = filaSeleccionada.Cells[7].Value.ToString();

                // Creo una instacion del formulario de edicion
                Editar_Cliente editar_ = new Editar_Cliente(_form);

                //paso los datos al formulario
                editar_.CargarDatos(DNI, nombre, apellido, telefono, direccion, email);
                editar_.ShowDialog();
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
