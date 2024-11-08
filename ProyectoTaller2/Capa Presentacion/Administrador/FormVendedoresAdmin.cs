using ProyectoTaller2.Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    public partial class FormVendedoresAdmin : Form
    {
        public FormVendedoresAdmin()
        {
            InitializeComponent();

            btnVerVentas.Enabled = false;
        }
        private void FormVendedoresAdmin_Load(object sender, EventArgs e)
        {
            CargarVendedores();

            foreach (DataGridViewColumn columna in dataGridVendedores.Columns)
            {
                comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridVendedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridVendedores.SelectedRows.Count > 0)
            {
                btnVerVentas.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string columnaFiltro = ((OpcionCombo)comboBox1.SelectedItem).Valor.ToString();

            if (dataGridVendedores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridVendedores.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtNombreVendedor.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void CargarVendedores()
        {
            var negocioVendedor = new NegocioUsuario();
            var datos = negocioVendedor.ListarVendedores();

            dataGridVendedores.DataSource = datos;

            this.formato();
        }



        private void dataGridUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex >= 0) // Reemplaza con el índice de la columna deseada.
            {
                // Verifica el valor de la celda en la columna deseada.
                if (e.Value != null)
                {
                    int valor = Convert.ToInt32(e.Value);

                    // Asigna el texto correspondiente en función del valor.
                    switch (valor)
                    {
                        case 1:
                            e.Value = "superadmin";
                            break;
                        case 2:
                            e.Value = "admin";
                            break;
                        case 3:
                            e.Value = "vendedor";
                            break;
                        default:
                            // Deja el valor original si no coincide con ninguno de los casos.
                            break;
                    }

                    // Indica que se ha formateado la celda.
                    e.FormattingApplied = true;
                }
            }
        }

        private void formato()
        {
            
            dataGridVendedores.Columns[0].HeaderText = "ID";
            dataGridVendedores.Columns[1].HeaderText = "Nombre";
            dataGridVendedores.Columns[2].HeaderText = "Apellido";
            dataGridVendedores.Columns[3].HeaderText = "Telefono";
            dataGridVendedores.Columns[4].HeaderText = "Usuario";
            dataGridVendedores.Columns[5].HeaderText = "Contraseña";
            dataGridVendedores.Columns[6].HeaderText = "Tipo de Usuario";

        }

        ErrorProvider errorP = new ErrorProvider();
        private void txtNombreVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtNombreVendedor.Text = "";
            foreach (DataGridViewRow row in dataGridVendedores.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            // Obtén el `id_usuario` del vendedor seleccionado en el DataGridView

            /*
            if (dataGridVendedores.SelectedRows.Count > 0)
            {
                int idUsuarioSeleccionado = Convert.ToInt32(dataGridVendedores.SelectedRows[0].Cells["id_usuario"].Value);

                // Abre el formulario de ventas pasando el `id_usuario` seleccionado
                FormVentasPorVendedor ventasVendedorForm = new FormVentasPorVendedor(idUsuarioSeleccionado);
                ventasVendedorForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un vendedor.");
            }*/
            // -------LO DE ARRIBA FUNCIONA BIEN-----
            // Obtén el `id_usuario` del vendedor seleccionado en el DataGridView
            if (dataGridVendedores.SelectedRows.Count > 0)
            {
                int idUsuarioSeleccionado = Convert.ToInt32(dataGridVendedores.SelectedRows[0].Cells["id_usuario"].Value);

                // Verifica si el vendedor tiene ventas registradas
                if (VerificarVentasRegistradas(idUsuarioSeleccionado))
                {
                    // Si tiene ventas, abre el formulario para mostrarlas
                    FormVentasPorVendedor ventasVendedorForm = new FormVentasPorVendedor(idUsuarioSeleccionado);
                    ventasVendedorForm.ShowDialog();
                }
                else
                {
                    // Si no tiene ventas, muestra un mensaje
                    MessageBox.Show("El vendedor seleccionado aún no posee ventas registradas.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un vendedor.");
            }
        }

        private bool VerificarVentasRegistradas(int idUsuario)
        {
            bool tieneVentas = false;

            // Reemplaza "tu_conexion" con tu cadena de conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "SELECT COUNT(*) FROM factura WHERE id_usuario = @id_usuario", connection);
                command.Parameters.AddWithValue("@id_usuario", idUsuario);

                int ventasCount = Convert.ToInt32(command.ExecuteScalar());
                tieneVentas = ventasCount > 0; // Si el conteo es mayor a 0, tiene ventas
            }

            return tieneVentas;
        }
    }
}
