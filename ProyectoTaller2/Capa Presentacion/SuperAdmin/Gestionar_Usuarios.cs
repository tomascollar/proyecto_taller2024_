using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
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
            // Verifica si al menos una fila está seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Habilita los botones si hay al menos una fila seleccionada
                btnEditaUsuario.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                // Deshabilita los botones si no hay ninguna fila seleccionada
                btnEditaUsuario.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            _form.openChildForm(new Agregar_Usuario(_form));
        }

        private void CargarUsuarios()
        {
            var negocioUsuario = new NegocioUsuario();

            var datos = negocioUsuario.ListarUsuario();

            dataGridUsuarios.DataSource = datos;
            this.formato();

            //dataGridUsuarios.RowPrePaint += dataGridUsuarios_RowPrePaint;




        }

        private void Gestionar_Usuarios_Load(object sender, EventArgs e)
        {
            //creo instancia del contexto de datos
           // CargarUsuarios();

           // dataGridUsuarios.ClearSelection();


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
                comboBox1.Items.RemoveAt(comboBox1.Items.Count - 1);
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
        }

        private void formato()
        {
            //dataGridUsuarios.Columns[0].Visible = false;
            dataGridUsuarios.Columns[0].HeaderText = "ID";
            dataGridUsuarios.Columns[1].HeaderText = "Nombre";
            dataGridUsuarios.Columns[2].HeaderText = "Apellido";
            dataGridUsuarios.Columns[3].HeaderText = "Telefono";
            dataGridUsuarios.Columns[4].HeaderText = "Usuario";
            dataGridUsuarios.Columns[5].HeaderText = "Contraseña";
            dataGridUsuarios.Columns[6].HeaderText = "Tipo de Usuario";
            dataGridUsuarios.Columns[7].HeaderText = "Estado";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int posicion = dataGridView1.CurrentRow.Index;

            var msg = MessageBox.Show("Seguro desea eliminar este usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {

                //dataGridUsuarios.Rows.RemoveAt(posicion);
                dataGridView1[8, posicion].Value = "Inactivo";
                dataGridView1.Rows[posicion].DefaultCellStyle.BackColor = Color.Red;

            }
        }
        
        private void dataGridUsuarios_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
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
            foreach (DataGridViewRow row in dataGridUsuarios.Rows)
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

    }
}
