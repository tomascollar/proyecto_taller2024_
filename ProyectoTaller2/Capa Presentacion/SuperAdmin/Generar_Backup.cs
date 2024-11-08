using ProyectoTaller2.CapaPresentacion.SuperAdmin;
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

namespace ProyectoTaller2.Capa_Presentacion.SuperAdmin
{
    public partial class Generar_Backup : Form
    {
        private InterfaceSuper _form;
        public Generar_Backup(InterfaceSuper form)
        {
            InitializeComponent();
            _form = form;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // Define la ruta del archivo de backup
                string backupPath = @"D:\BACKUPS_DB\db_proyecto.bak"; // Cambia la ruta según tus necesidades

                // Establece la cadena de conexión a la base de datos
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=proyecto_taller2;Integrated Security=True";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Comando para generar el backup
                    string query = $"BACKUP DATABASE [proyecto_taller2] TO DISK = '{backupPath}'";

                    // Ejecuta el comando SQL
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Backup generado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el backup: {ex.Message}");
            }
        }
    }
}
