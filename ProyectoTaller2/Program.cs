using ProyectoTaller2.CapaPresentacion.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            formLogin mylogin = new formLogin();
            mylogin.Show(); 


                        //Este Codigo es para inicar con el formulario Vendedor
           //FormMainMenu menu = new FormMainMenu();   //Borrar estas lineas cuando
            //menu.Show();                             //quiera volver a poner el login 
                        

            //Administrador menu = new Administrador();
            //menu.Show();


            Application.Run();                            
        }
    }
}
