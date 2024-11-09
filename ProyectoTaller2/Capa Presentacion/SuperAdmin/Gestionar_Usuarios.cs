using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Entidades;
using ProyectoTaller2.Capa_Presentacion.Administrador;
using ProyectoTaller2.CapaPresentacion.SuperAdmin;

namespace ProyectoTaller2.Capa_Presentacion.SuperAdmin
{
    public partial class Gestionar_Usuarios : Form
    {

        private InterfaceSuper _form;

        public Gestionar_Usuarios(InterfaceSuper form)
        {
            InitializeComponent();
            _form = form;

            //Desactivamos los botones del inicio ya que no hay ninguna columna seleccionada
           // btnEditaUsuario.Enabled = false;
           // btnEliminar.Enabled = false;
                  
        }      

        private void dataGridUsuarios_SelectionChanged(object sender, EventArgs e)
        {

            
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            _form.openChildForm(new Agregar_Usuario(_form));
        }

        private void CargarUsuarios()
        {
            //Mostrar los usuarios
            List<Usuario> listaUsuario = new NegocioUsuario().Listar();

            dataGridView1.AutoGenerateColumns = false;

            foreach (Usuario item in listaUsuario)
            {
                dataGridView1.Rows.Add(new object[] {item.id_usuario, item.nombre_usuario, item.apellido_usuario,
             item.telefono_usuario,item.usuario,item.contraseña,
              item.oTipo_Usuario.id_tipo_usario,item.oTipo_Usuario.descripcion_tipo_usuario,
              item.estado_usuario
            });

            }

        }

        private void Gestionar_Usuarios_Load(object sender, EventArgs e)
        {
            //creo instancia del contexto de datos
            // CargarUsuarios();
            
            // dataGridUsuarios.ClearSelection();
            dataGridUsuarios.Visible = false;


            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                if(columna.Visible == true)
                {
                    comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }                
            }
            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;
            
            if(comboBox1.Items.Count > 0)
            {
               // comboBox1.Items.RemoveAt(comboBox1.Items.Count - 1);
            }

            //Mostrar los usuarios
            List<Usuario> listaUsuario = new NegocioUsuario().Listar();

            dataGridView1.AutoGenerateColumns = false;

            foreach (Usuario item in listaUsuario)
            {
                dataGridView1.Rows.Add(new object[] {item.id_usuario, item.nombre_usuario, item.apellido_usuario,
             item.telefono_usuario,item.usuario,item.contraseña,
              item.oTipo_Usuario.id_tipo_usario,item.oTipo_Usuario.descripcion_tipo_usuario,
              item.estado_usuario
            });
            }

            dataGridView1.ClearSelection();
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtén el ID del usuario seleccionado
                int idUsuarioSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdUsuario"].Value);

                // Confirmar la baja lógica
                var confirmResult = MessageBox.Show("¿Estás seguro de dar de baja este usuario?",
                                                    "Confirmar baja lógica",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Conexión a la base de datos y ejecución del procedimiento
                    using (SqlConnection connection = new SqlConnection(Conexion.cadena))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("sp_BajaLogicaUsuario", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@id_usuario", idUsuarioSeleccionado);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Actualiza el DataGridView después de la baja lógica
                    MessageBox.Show("El usuario ha sido dado de baja.");

                    dataGridView1.Refresh();
                  
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para darlo de baja.");
            }
        }
        
        private void dataGridUsuarios_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }


        private void dataGridUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (e.ColumnIndex == 6 && e.RowIndex >= 0) // Reemplaza con el índice de la columna deseada.
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
            }*/

            // Verifica si la columna actual es la de "estado_usuario"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Estado")
            {
                // Obtiene el valor de la celda
                string estado = dataGridView1.Rows[e.RowIndex].Cells["Estado"].Value?.ToString();

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
        

        ErrorProvider errorP =  new ErrorProvider();


        private void btnEditaUsuario_Click(object sender, EventArgs e)
        {
            /* ESTO FUNCIONA
             * if(dataGridUsuarios.SelectedRows.Count > 0)
            {
                //Obtengo la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridUsuarios.SelectedRows[0];

                //Obtengo los valores de las celdas
                string id = filaSeleccionada.Cells[0].Value.ToString();
                string nombre = filaSeleccionada.Cells[1].Value.ToString();
                string apellido = filaSeleccionada.Cells[2].Value.ToString();
                string telefono = filaSeleccionada.Cells[3].Value.ToString();
                string usuario = filaSeleccionada.Cells[4].Value.ToString();
                string contraseña = filaSeleccionada.Cells[5].Value.ToString();
                string user_type = filaSeleccionada.Cells[6].Value.ToString();

                //Creo una instancia del formulario de edicion
                Editar_Usuario editarform = new Editar_Usuario(_form);

                //Paso los datos al formulario
                editarform.CargarDatos(id, nombre, apellido, telefono, usuario, contraseña, user_type);

                //Muestro el formulario
                editarform.ShowDialog();
            }
            */

            //Lo de arriba funciona BIEN, ahora voy a probar para el datagrid NUEVO

            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Obtengo la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                //Obtengo los valores de las celdas
                string id = filaSeleccionada.Cells[0].Value.ToString();
                string nombre = filaSeleccionada.Cells[1].Value.ToString();
                string apellido = filaSeleccionada.Cells[2].Value.ToString();
                string telefono = filaSeleccionada.Cells[3].Value.ToString();
                string usuario = filaSeleccionada.Cells[4].Value.ToString();
                string contraseña = filaSeleccionada.Cells[5].Value.ToString();
                string user_type = filaSeleccionada.Cells[6].Value.ToString();

                //Creo una instancia del formulario de edicion
                Editar_Usuario editarform = new Editar_Usuario(_form);

                //Paso los datos al formulario
                editarform.CargarDatos(id, nombre, apellido, telefono, usuario, contraseña, user_type);

                //Muestro el formulario
                editarform.ShowDialog();
            }

            //Arriba de esto codigo nuevo(para borrar en caso de error), abajo de esto el codigo que funcionaba bien
            // Editar_Usuario editarform = new Editar_Usuario(_form);
            // editarform.Show();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string columnaFiltro = ((OpcionCombo)comboBox1.SelectedItem).Valor.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el estado del usuario seleccionado
                string estadoUsuario = dataGridView1.SelectedRows[0].Cells["Estado"].Value.ToString();

                // Mostrar el botón solo si el usuario está 'Inactivo'
                btnReactivar.Visible = estadoUsuario == "Inactivo";
            }
            else
            {
                // Ocultar el botón si no hay ninguna fila seleccionada
                btnReactivar.Visible = false;
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado
                int idUsuarioSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdUsuario"].Value);

                // Llamar al método que reactivará el usuario en la base de datos
                ReactivarUsuario(idUsuarioSeleccionado);

                // Refrescar el DataGridView para mostrar el cambio
              //  CargarUsuarios(); // Este método debería volver a cargar los usuarios en el DataGridView
                
                MessageBox.Show("Usuario reactivado con éxito.");
            }
        }

        private void ReactivarUsuario(int idUsuario)
        {
            // Código para actualizar el estado del usuario en la base de datos
            string query = "UPDATE usuario SET estado_usuario = 'Activo' WHERE id_usuario = @id_usuario";

            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_usuario", idUsuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
