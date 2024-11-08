using ProyectoTaller2.CapaPresentacion.SuperAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2.Capa_Presentacion.SuperAdmin
{
    public partial class Editar_Usuario : Form
    {

        private InterfaceSuper _form;
        
        DialogResult ask;
        public Editar_Usuario(InterfaceSuper form)
        {
            InitializeComponent();
            _form = form;
            
        }

        public void CargarDatos(string id, string nombre, string apellido, string telefono, string usuario, string contraseña, string tipo_user)
        {
            txtID.Text = id;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtTelefono.Text = telefono;
            txtUsuario.Text = usuario;
            txtPass.Text = contraseña;
           //comboBoxTipo.Text = tipo_user;

           // comboBoxTipo.SelectedIndex = 1;

            if(tipo_user == "1")
            {
                comboBoxTipo.SelectedIndex = 2;
            }
            else if (tipo_user == "2")
            {
                comboBoxTipo.SelectedIndex = 1;
            }
            else
            {
                comboBoxTipo.SelectedIndex = 0;
            }
            

        }


        ErrorProvider errorP = new ErrorProvider();

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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = Validar.soloNumeros(e);
            if (!valida)
                errorP.SetError(txtTelefono, "Solo numeros");
            else
                errorP.Clear();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
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

            bool validaUsuario = Validar.txtVacios(txtUsuario);
            if (validaUsuario)
                errorP.SetError(txtUsuario, "Debe completar este campo");
            else
                errorP.Clear();

            bool validaPass = Validar.txtVacios(txtPass);
            if (validaPass)
                errorP.SetError(txtPass, "Debe completar este campo");
            else
                errorP.Clear();


            if (!validaApellido && !validaTelefono && !validaNombre && !validaPass && !validaUsuario && comboBoxTipo.SelectedIndex != -1)
            {
                ask = MessageBox.Show("Seguro que desea editar el usuario?", "Confirmar Edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (ask == DialogResult.Yes)
            {



                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string telefono = txtTelefono.Text;
                string usuariotxt = txtUsuario.Text;
                string pw = txtPass.Text;
                int tipo;

                if (comboBoxTipo.Text == "superadmin")
                {
                    tipo = 1;
                }
                else
                {
                    if (comboBoxTipo.Text == "admin")
                    {
                        tipo = 2;
                    }
                    else
                    {
                        tipo = 3;
                    }
                }

                /*
                var edit_usuario = new NegocioUsuario();
                edit_usuario.EditarUsuario(nombre, apellido, telefono, usuario, pw, tipo);
                */

                
                

                proyecto_taller2Entities contexto = new proyecto_taller2Entities();

                int user_id = Convert.ToInt32(txtID.Text);

                var datos = from usuario in contexto.usuario
                            where usuario.id_usuario == user_id
                            select usuario;

                if(datos.Count() > 0)
                {
                    usuario encontrado = datos.First();
                    encontrado.nombre_usuario = txtNombre.Text;
                    encontrado.apellido_usuario = txtApellido.Text;
                    encontrado.telefono_usuario = txtTelefono.Text;
                    encontrado.usuario1 = txtUsuario.Text;
                    encontrado.contraseña = txtPass.Text;
                    encontrado.id_tipo_usuario = tipo;

                }
                else
                {
                    MessageBox.Show("no se ha podido encontrar al usuario");
                }

                try
                {
                    if(contexto.SaveChanges() == 1)
                    {
                        MessageBox.Show("El Usuario " + txtNombre.Text +
                    " se edito correctamente", "Guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("no se pudo editar");
                }                
                                

                txtApellido.Clear();
                txtTelefono.Clear();
                txtNombre.Clear();
                txtPass.Clear();
                txtUsuario.Clear();

                this.Close();
                
                Gestionar_Usuarios form = new Gestionar_Usuarios(_form);
                _form.openChildForm(form);
            }
        }

        private void Editar_Usuario_Load(object sender, EventArgs e)
        {
            //LlenarCombo();
        }

        private void LlenarCombo()
        {
            var list = new List<string>() { "vendedor", "admin", "superadmin" };
            comboBoxTipo.DataSource = list;

            comboBoxTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Desea cancelar la edicion?","Cancelar edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                this.Close();
            }


        }
    }

}
