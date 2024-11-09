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
    public partial class Backup_Restore : Form
    {

        private InterfaceSuper _form;
        public Backup_Restore(InterfaceSuper form)
        {
            InitializeComponent();
            _form = form;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

            // _form.openChildForm(new Generar_Backup(_form));

            try
            {
                // Obtengo la fecha y hora actual para usar en el nombre del archivo
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                // Define la ruta del archivo de backup
                string backupPath = $@"C:\backup_DB\db_proyecto_{timestamp}.bak"; // Cambia la ruta según tus necesidades

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

                    MessageBox.Show($"Backup generado exitosamente en la ruta:\n{backupPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el backup: {ex.Message}");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            //_form.openChildForm(new Restaurar_Backup());

            try
            {
                // Abre el cuadro de diálogo para seleccionar el archivo de respaldo
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos de respaldo (*.bak)|*.bak"; // Filtra solo los archivos .bak
                openFileDialog.Title = "Seleccionar archivo de respaldo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Ruta del archivo de respaldo seleccionado
                    string backupFilePath = openFileDialog.FileName;

                    // Establece la cadena de conexión a la base de datos
                    string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"; // Usamos "master" para restaurar

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Prepara el comando SQL para restaurar la base de datos
                        string query = $@"
                    RESTORE DATABASE [proyecto_taller2]
                    FROM DISK = '{backupFilePath}'
                    WITH REPLACE, RECOVERY;"; // WITH REPLACE sobrescribe la base de datos existente

                        // Ejecuta el comando SQL
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Base de datos restaurada exitosamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar la base de datos: {ex.Message}");
            }
        }
    }
}
