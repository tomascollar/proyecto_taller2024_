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
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Net.Mime.MediaTypeNames;


namespace ProyectoTaller2.CapaPresentacion.SuperAdmin
{
    
    public partial class FormRegistroCliente : Form
    {
        private Iform _form;

        DialogResult ask;
        public FormRegistroCliente(Iform form)
        {
            InitializeComponent();
            _form = form;
        }

        ErrorProvider errorP = new ErrorProvider();

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtDni, "Solo numeros");
            else
                errorP.Clear();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtTelefono, "Solo numeros");
            else
                errorP.Clear();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloLetras(e);
            if (!valida)
                errorP.SetError(txtNombre, "Solo letras");
            else
                errorP.Clear();
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloLetras(e);
            if (!valida)
                errorP.SetError(txtApellido, "Solo letras");
            else
                errorP.Clear();
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            bool validaDNI = Validar.txtVacios(txtDni);
            if (validaDNI)
                errorP.SetError(txtDni, "Debe completar este campo");
            else
                errorP.Clear();

            bool validaNombre = Validar.txtVacios(txtNombre);
            if (validaNombre)
                errorP.SetError(txtNombre, "Debe completar este campo");
            else
                errorP.Clear();

            bool validaApellido = Validar.txtVacios(txtApellido);
            if (validaApellido)
                errorP.SetError(txtApellido, "Debe completar este campo");
            else
                errorP.Clear();

            bool validaTelefono = Validar.txtVacios(txtTelefono);
            if (validaTelefono)
                errorP.SetError(txtTelefono, "Debe completar este campo");
            else
                errorP.Clear();

            bool validaDireccion = Validar.txtVacios(txtDireccion);
            if (validaDireccion)
                errorP.SetError(txtDireccion, "Debe completar este campo");
            else
                errorP.Clear();

            bool validaEmail = Validar.txtVacios(txtEmail);
            if (validaEmail)
                errorP.SetError(txtEmail, "Debe completar este campo");
            else
                errorP.Clear();

            bool correo = Validar.validarEmail(txtEmail.Text);

            if (!correo)
            {
                MessageBox.Show("Debe ingresar un email valido");
            }
            else { 
            
            if (!validaDireccion && !validaApellido && !validaTelefono && !validaDNI && !validaNombre && !validaEmail)
            {

                ask = MessageBox.Show("Seguro que desea insertar un nuevo Cliente?", "Confirmar Insercion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (ask == DialogResult.Yes)
            {
                MessageBox.Show("El cliente " + txtDni.Text +
                    " se insertó correctamente", "Guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

             

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int param_dni = Convert.ToInt32(txtDni.Text);
                string telefono = txtTelefono.Text;
                string direccion = txtDireccion.Text;
                string email = txtEmail.Text;

                string estado = "Activo";

                    var nuevoCliente = new NegocioCliente();
                    nuevoCliente.AgregarCliente(nombre, apellido, param_dni, telefono, direccion, email, estado);

                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtDni.Clear();
                    txtTelefono.Clear();
                    txtDireccion.Clear();
                    txtEmail.Clear();
                
                FormCliente form = new FormCliente(_form);
                _form.openChildForm(form);
            }
            }
        }
    } 
    
}
