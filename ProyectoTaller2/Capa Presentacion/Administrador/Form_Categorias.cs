﻿using ProyectoTaller2.Capa_Datos;
using ProyectoTaller2.Capa_Entidades;
using ProyectoTaller2.Capa_Negocio;
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
    public partial class Form_Categorias : Form
    {
        public Form_Categorias()
        {
            InitializeComponent();
        }

        private void Form_Categorias_Load(object sender, EventArgs e)
        {

            //RELLENAR COMBO BOX CON FILTROS DE BUSQUEDA
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                if (columna.Visible == true)
                {
                    comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;


            //MOSTRAR TODAS LAS CATEGORIAS
            /* List<Categoria> lista = new NegocioCategoria().Listar();

             dataGridView1.AutoGenerateColumns = false;

             foreach (Categoria item in lista)
             {
                 dataGridView1.Rows.Add(new object[] {
                     item.id_categoria,
                     item.descripcion_categoria,
                     item.estado_categoria
             });
             }

             dataGridView1.ClearSelection();*/

            CargarCategorias();

        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Form_NuevaCategoria formNuevaCategoria = new Form_NuevaCategoria();

            // Mostrar el formulario como un cuadro de diálogo
            if (formNuevaCategoria.ShowDialog() == DialogResult.OK)
            {
                // Código para actualizar la lista de categorías después de registrar una nueva
                CargarCategorias(); // Llama al método que carga o actualiza el DataGridView
            }
        }

        private void btnEditaCategoria_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtiene el Id de la categoría seleccionada desde la columna "Id" del DataGridView
                int idCategoria = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Declara variables para el resultado y mensaje de salida del procedimiento almacenado
                bool resultado;
                string mensaje;

                // Llama al procedimiento almacenado
                using (SqlConnection conn = new SqlConnection(Conexion.cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                        // Parámetros de salida
                        SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(paramResultado);
                        cmd.Parameters.Add(paramMensaje);

                        // Abre la conexión y ejecuta el comando
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Obtiene los valores de los parámetros de salida
                        resultado = Convert.ToBoolean(paramResultado.Value);
                        mensaje = paramMensaje.Value.ToString();
                    }
                }

                // Muestra el mensaje de éxito o error basado en el resultado
                if (resultado)
                {
                    MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualiza el DataGridView para reflejar el cambio
                    //CargarCategorias(); // Método para recargar las categorías en el DataGridView
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CargarCategorias();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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
                int idCategoriaSeleccionada = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Llamar al método que reactivará el usuario en la base de datos
                ReactivarCategoria(idCategoriaSeleccionada);

                // Refrescar el DataGridView para mostrar el cambio
                //  CargarUsuarios(); // Este método debería volver a cargar los usuarios en el DataGridView

                MessageBox.Show("Categoria reactivada con éxito.");
            }

            CargarCategorias();
        }

        private void ReactivarCategoria(int idCategoria)
        {
            // Código para actualizar el estado del usuario en la base de datos
            string query = "UPDATE categoria SET estado_categoria = 'Activo' WHERE id_categoria = @id_categoria";

            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_categoria", idCategoria);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CargarCategorias()
        {
            // Limpia las filas actuales en el DataGridView
            dataGridView1.Rows.Clear();

            // Obtiene la lista de categorías desde la capa de negocio
            List<Categoria> lista = new NegocioCategoria().Listar();

            // Configura el DataGridView para que no genere columnas automáticamente
            dataGridView1.AutoGenerateColumns = false;

            // Agrega cada categoría a una nueva fila en el DataGridView
            foreach (Categoria item in lista)
            {
                dataGridView1.Rows.Add(new object[] {
            item.id_categoria,
            item.descripcion_categoria,
            item.estado_categoria
            });
            }

            // Limpia la selección del DataGridView después de cargar las categorías
            dataGridView1.ClearSelection();
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

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
