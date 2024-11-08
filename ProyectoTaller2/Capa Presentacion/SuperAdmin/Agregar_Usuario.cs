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
    public partial class Agregar_Usuario : Form
    {

        private InterfaceSuper _form;
        DialogResult ask;
        public Agregar_Usuario(InterfaceSuper form)
        {
            InitializeComponent();
            _form = form;
        }

        private void Agregar_Usuario_Load(object sender, EventArgs e)
        {
            LlenarCombo();
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

        private void botonAgregaUsuario_Click(object sender, EventArgs e)
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


            if ( !validaApellido && !validaTelefono && !validaNombre && !validaPass && !validaUsuario && comboBoxTipo.SelectedIndex != -1)
            {
                ask = MessageBox.Show("Seguro que desea insertar un nuevo Cliente?", "Confirmar Insercion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos","Campos Vacios",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (ask == DialogResult.Yes)
            {
                MessageBox.Show("El Usuario "  + txtNombre.Text +
                    " se insertó correctamente", "Guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string telefono = txtTelefono.Text;
                string usuario = txtUsuario.Text;
                string pw = txtPass.Text;
                int tipo;
                string estado = "Activo";

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
  
               

                var nuevo_usuario = new NegocioUsuario();

                nuevo_usuario.AgregarUsuario(nombre, apellido, telefono, usuario, pw, tipo, estado);


                txtApellido.Clear();
                txtTelefono.Clear();
                txtNombre.Clear();
                txtPass.Clear();
                txtUsuario.Clear();

                Gestionar_Usuarios form = new Gestionar_Usuarios(_form);
                _form.openChildForm(form);

            }

        }


        private void LlenarCombo()
        {
            var list = new List<string>() { "vendedor", "admin", "superadmin" };
            comboBoxTipo.DataSource = list;

            comboBoxTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private AutoCompleteStringCollection CargarDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            datos.Add("vendedor");
            datos.Add("admin");
            datos.Add("superadmin");

            return datos;
        }
    }
}
