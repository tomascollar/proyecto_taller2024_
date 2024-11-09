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

namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    public partial class Form_Editar_Cliente : Form
    {
        private int idCliente;
        private string nombre, apellido, telefono, direccion, email;
        private int dni;

        DialogResult ask;
        private Iform _form;
        public Form_Editar_Cliente(int idCliente, string nombre, string apellido, int dni, string telefono, string direccion, string email)
        {
            InitializeComponent();
            this.idCliente = idCliente; // Asignamos el ID del cliente
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.direccion = direccion;
            this.email = email;
        }

        private void Form_Editar_Cliente_Load(object sender, EventArgs e)
        {
            // Cargar los datos en los controles (TextBox)
            txtDni.Text = dni.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtEmail.Text = email;
        }

        public void CargarDatos(int idCliente, string nombre, string apellido, int dni, string telefono, string direccion, string email)
        {
            // Cargar los datos en los controles del formulario
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtDni.Text = dni.ToString();
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtEmail.Text = email;

            // Si necesitas almacenar el ID del cliente para futuras operaciones, puedes hacerlo en una propiedad pública o privada
            this.idCliente = idCliente;
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            // Crear una instancia de NegocioCliente
            var negocioCliente = new NegocioCliente();

            // Tomar los valores modificados de los TextBox
            string nuevoNombre = txtNombre.Text;
            string nuevoApellido = txtApellido.Text;
            int nuevoDni = Convert.ToInt32(txtDni.Text); // Asegúrate de convertir a int
            string nuevoTelefono = txtTelefono.Text;
            string nuevaDireccion = txtDireccion.Text;
            string nuevoEmail = txtEmail.Text;

            // Llamar al método para editar el cliente en la base de datos
            bool exito = negocioCliente.EditarCliente(idCliente, nuevoNombre, nuevoApellido, nuevoDni, nuevoTelefono, nuevaDireccion, nuevoEmail);

            if (exito)
            {
                MessageBox.Show("Cliente actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerrar el formulario de edición
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
