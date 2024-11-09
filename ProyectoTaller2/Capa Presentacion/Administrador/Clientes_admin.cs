using Org.BouncyCastle.Asn1.X509;
using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Negocio;
using ProyectoTaller2.Capa_Presentacion.Administrador;
using ProyectoTaller2.Capa_Presentacion.Vendedor;
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

namespace ProyectoTaller2.CapaPresentacion.Administrador
{

    
    public partial class Clientes_admin : Form
    {

        //defino el _form que va a guardar el form recibido como parametro
        //para poder utilizar la interfaz
        private Iform _form;

       /* public Clientes_admin()
        {
            InitializeComponent();

        }*/

        public Clientes_admin(Iform form)
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


        private void Clientes_admin_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            CargarClientes();

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string estadoCliente = dataGridView1.SelectedRows[0].Cells[7].Value.ToString(); // Columna 7 es el índice 6
                if (estadoCliente.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    // Muestra el botón de reactivación si el estado es "Inactivo"
                    btnReactivar.Visible = true;
                }
                else
                {
                    // Oculta el botón si el estado no es "Inactivo"
                    btnReactivar.Visible = false;
                }

                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                // Si no hay fila seleccionada, ocultamos el botón
                btnReactivar.Visible = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        ErrorProvider errorP = new ErrorProvider();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)comboBox1.SelectedItem).Valor.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                // Desactiva temporalmente el modo de administración de divisa
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscarDni.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }

                // Reactiva el modo de administración de divisa
                currencyManager.ResumeBinding();
            }
        }

        private void txtBuscarDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtBuscarDni, "Solo numeros");
            else
                errorP.Clear();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado una fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtén el id_cliente de la fila seleccionada
                int idCliente = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Suponiendo que el id_cliente está en la primera columna (índice 0)

                // Llama al procedimiento almacenado para hacer la baja lógica
                EjecutarBajaLogicaCliente(idCliente);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente.");
            }
        }


        private void EjecutarBajaLogicaCliente(int idCliente)
        {
            try
            {
                // Define la cadena de conexión a la base de datos
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=proyecto_taller2;Integrated Security=True";

                // Establece la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crea el comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("sp_BajaLogicaCliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Añade el parámetro @id_cliente al comando
                        command.Parameters.AddWithValue("@id_cliente", idCliente);

                        // Ejecuta el procedimiento almacenado
                        command.ExecuteNonQuery();
                    }
                }

                // Muestra un mensaje de éxito y actualiza el DataGridView
                MessageBox.Show("Cliente dado de baja exitosamente.");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dar de baja el cliente: {ex.Message}");
            }
        }


        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBuscarDni.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
             if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener los datos de la fila seleccionada
                var idCliente = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Asumiendo que el ID está en la primera columna
                var nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                var apellido = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                var dni = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
                var telefono = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                var direccion = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                var email = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                // Abrir el formulario de edición y pasar los datos al formulario de edición
                Form_Editar_Cliente formEditar = new Form_Editar_Cliente(idCliente, nombre, apellido, dni, telefono, direccion, email);
                formEditar.ShowDialog(); // Abrir el formulario de edición
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado
                int idClienteSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                // Llamar al método que reactivará el usuario en la base de datos
                ReactivarCliente(idClienteSeleccionado);

                // Refrescar el DataGridView para mostrar el cambio
                //  CargarUsuarios(); // Este método debería volver a cargar los usuarios en el DataGridView

                MessageBox.Show("Cliente reactivado con éxito.");
            }
        }

        private void ReactivarCliente(int idCliente)
        {
            // Código para actualizar el estado del usuario en la base de datos
            string query = "UPDATE clientes SET estado_cliente = 'Activo' WHERE id_cliente = @id_cliente";

            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_cliente", idCliente);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la columna actual es la de índice 7
            if (e.ColumnIndex == 7)
            {
                // Obtiene el valor de la celda en la columna de índice 7
                string estado = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Si el estado es "Inactivo", cambia el color de la fila a rojo
                if (estado == "Inactivo")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; // Para que el texto sea legible
                }
                else
                {
                    // Restaura el color si es otro estado (opcional)
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
    
}
