using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
//Libreria de los iconos
using FontAwesome.Sharp;
using ProyectoTaller2.Capa_Presentacion.Administrador;

namespace ProyectoTaller2.CapaPresentacion.Administrador
{

    //Defino una interfaz para poder abrir formularios dentro del panel desde otros formularios
   public interface Iform
    {
        void openChildForm(Form form);
    }

    //le paso al constructor la interfaz
    public partial class Form_Admin : Form, Iform
    {
        //Declaramos un campo para el boton ACTUAL
        private IconButton currentBtn;
        //Declaramos un PANEL para aplicar un borde izquierdo al boton
        private Panel leftBorderBtn;
        //Declaramos un campo de tipo Formulario para almacenar el formulario Hijo Activo
        private Form currentChildForm;

        //Constructor
        public Form_Admin()
        {
            InitializeComponent();
            //Inicializamos el Borde Izquierdo del boton
            leftBorderBtn = new Panel();
            //Asignamos un tamaño 7 de ANCHO y 60 de Alto
            leftBorderBtn.Size = new Size(7, 60);
            //Agregamos al PanelMenu el borde
            panelMenu.Controls.Add(leftBorderBtn);

            //Configuramos el Form
            this.Text = string.Empty;
            this.ControlBox = false;
            //Config que evita los parpadeos
            this.DoubleBuffered = true;
            //Configuramos que el maximizado sea hasta antes del total de la pantalla, para que tenga margen
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Estructura RGB para definir colores
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172, 126, 241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118, 176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95, 77, 221);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249, 88, 155);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);
        }

        //Metodos

        //Metodo para resaltar el BOTON activo
        private void ActivateButton(object senderBtn, System.Drawing.Color color)
        {
            //Si el boton es distinto de nulo
            if(senderBtn != null)
            {
                DisableButton();
                //BOTON

                //Converitmos el boton al mismo tipo
                currentBtn = (IconButton)senderBtn;
                //Cambiamos de color
                currentBtn.BackColor = System.Drawing.Color.FromArgb(37, 36, 81);
                //Cambiamos el color del texto
                currentBtn.ForeColor = color;
                //Alineamos el texto al centro
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                //Cambiamos el color del icono
                currentBtn.IconColor = color;
                //Cambiamos el lugar entre el texto y el icono
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //Alineamos el icono a la derecha
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //BORDE IZQUIERDO
                //Cambiamos el color de fondo
                leftBorderBtn.BackColor = color;
                //Asignamos una nueva ubicacion (Asignamos el valor del eje Y del boton como sitio del BordeIzquierdo)
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                //Lo hacemos visible
                leftBorderBtn.Visible = true;
                //Lo traemos al frente
                leftBorderBtn.BringToFront();

                //Icono del panel Titulo
                //Hacemos que el icono sea igual al icono del boton seleccionado
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                //Le cambiamos el color
                iconCurrentChildForm.IconColor = color;
                //Le cambiamos el texto al Label
                lblTitleChildForm.Text = currentBtn.Text;
            }
        }

        //Metodo para desactivar el resaltado del BOTON activo
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                //Ponemos a todo el BOTON a su version por defecto
                //Cambiamos de color
                currentBtn.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
                //Cambiamos el color del texto
                currentBtn.ForeColor = System.Drawing.Color.Gainsboro;
                //Alineamos el texto al centro
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                //Cambiamos el color del icono
                currentBtn.IconColor = System.Drawing.Color.Gainsboro;
                //Cambiamos el lugar entre el texto y el icono
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //Alineamos el icono a la derecha
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        //Configuramos Abrir Formularios dentro del Panel Principal

        //Si queremos abrir múltiples formularios, sólo hay que elimnar estas lineas de codigo
        public void openChildForm(Form childForm)
        {
            //Si el formulario actual es diferente a nulo[Esta abierto]
            if(currentChildForm != null)
            {
                //Lo cerramos
                currentChildForm.Close();
                //Para luego abrir otro que hemos seleccionado
            }
            currentChildForm = childForm;
            //Indicamos que el fomulario hijo actual no es de nivel superior
            childForm.TopLevel = false;
            //Quitamos el borde del formulario
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            //Agregamos los Formularios hijos al Panel de Escritorio
            panelDesktop.Controls.Add(childForm);
            //Asociamos los datos del formulario
            panelDesktop.Tag = childForm;
            //Traemos el formulario hacia el frente
            childForm.BringToFront();
            //Lo mostramos
            childForm.Show();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            openChildForm(new FormVendedoresAdmin());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            openChildForm(new FormProductosAdmin());

        }


      




        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            //Icono del panel Titulo
            //Hacemos que el icono sea igual al icono del boton seleccionado
            iconCurrentChildForm.IconChar = IconChar.Home;
            //Le cambiamos el color
            iconCurrentChildForm.IconColor = System.Drawing.Color.DarkOrchid;
            //Le asignamos el Label original
            lblTitleChildForm.Text = "Home";
        }

        //Evento arrastrar el formulario desde el panel de titulo

        //Libreria que permite mover el formulario a travez del evento del MOUSE
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]


        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Esta seguro que desea cerrar la sesión?", "Error", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation);

            if (ask != DialogResult.No)
            {
                this.Close();
                formLogin login = new formLogin();
                login.Show();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            openChildForm(new Clientes_admin());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            openChildForm(new Reporte_ventas());
        }
    }
}
