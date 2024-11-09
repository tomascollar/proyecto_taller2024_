using ProyectoTaller2.Capa_Datos;
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

namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    public partial class FormVentasPorVendedor : Form
    {

        private int idUsuarioVendedor;
        public FormVentasPorVendedor(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioVendedor = idUsuario;
        }

        private void FormVentasPorVendedor_Load(object sender, EventArgs e)
        {
            // Llama a un método para cargar las ventas del vendedor al abrir el formulario
            CargarVentasVendedor();
        }

        private void CargarVentasVendedor()
        {
            // Aquí llam0 al procedimiento almacenado `sp_ReporteVentasPorVendedor`
            // y paso el `idUsuarioVendedor` como parámetro

            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_ReporteVentasPorVendedor", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_usuario", idUsuarioVendedor);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable ventasTable = new DataTable();
                adapter.Fill(ventasTable);

                // Asigna los resultados al DataGridView
                dataGridView1.DataSource = ventasTable;
            }
        }
    }
}
