using ProyectoTaller2.CapaPresentacion.Administrador;
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
    public partial class Editar_Cliente : Form
    {

        DialogResult ask;
        private Iform _form;
        public Editar_Cliente(Iform form)
        {
            InitializeComponent();
            _form = form;
        }

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
                errorP.SetError(txtNombre, "Solo numeros");
            else
                errorP.Clear();
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloLetras(e);
            if (!valida)
                errorP.SetError(txtApellido, "Solo numeros");
            else
                errorP.Clear();
        }


        ErrorProvider errorP = new ErrorProvider();
        private void btnEditarCliente_Click(object sender, EventArgs e)
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
            else
            {

                if (!validaDireccion && !validaApellido && !validaTelefono && !validaDNI && !validaNombre && !validaEmail)
                {

                    ask = MessageBox.Show("Seguro que desea editar este Cliente?", "Confirmar Insercion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (ask == DialogResult.Yes)
                {
                    int dni = Convert.ToInt32(txtDni.Text);
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string telefono = txtTelefono.Text;
                    string direccion = txtDireccion.Text;
                    string email = txtEmail.Text;

                    proyecto_taller2Entities contexto = new proyecto_taller2Entities();

                    int user_dni = Convert.ToInt32(txtDni.Text);

                    var datos = from clientes in contexto.clientes
                                where clientes.DNI_cliente == user_dni
                                select clientes;

                    if(datos.Count() > 0)
                    {
                        clientes encontrado = datos.First();
                        encontrado.DNI_cliente = dni;
                        encontrado.nombre_cliente = nombre;
                        encontrado.apellido_cliente = apellido;
                        encontrado.telefono_cliente = telefono;
                        encontrado.direccion_cliente = direccion;
                        encontrado.email_cliente = email;
                    }
                    else
                    {
                        MessageBox.Show("no se ha podido encontrar al usuario");
                    }

                    try
                    {
                        if (contexto.SaveChanges() == 1)
                        {
                            MessageBox.Show("El Usuario " + txtNombre.Text +
                        " se edito correctamente", "Guardar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("no se pudo editar");
                    }

                    txtApellido.Clear();
                    txtDni.Clear();
                    txtNombre.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    txtEmail.Clear();

                    this.Close();

                    FormCliente form = new FormCliente(_form);
                    _form.openChildForm(form);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Seguro desea cancelar la edicion?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void CargarDatos(string DNI, string nombre, string apellido, string telefono, string direccion, string email)
        {
            txtDni.Text = DNI;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtEmail.Text = email;
        }
    }
}
