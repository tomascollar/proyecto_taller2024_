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
using System.Windows.Forms.DataVisualization.Charting;

namespace ProyectoTaller2.Capa_Presentacion.Administrador
{
    public partial class Reporte_ventas : Form
    {
        public Reporte_ventas()
        {
            InitializeComponent();
        }

        private void Reporte_ventas_Load(object sender, EventArgs e)
        {
            CargarGraficoVentasMensuales(); // grafico ventas mensuales
            CargarGrafico(); //Grafico producto mas vendido
            CargarClientesMasVentasEnBarras();  // Carga el gráfico de barras de los clientes con más ventas
            CargarCategoriasMasVendidasEnBarras();  // Carga el gráfico de líneas de las categorías de productos más vendidas
        }


        private void CargarGraficoVentasMensuales()
        {
            // Configuración inicial del gráfico
            chartVentas.Series.Clear();
            chartVentas.Titles.Add("Ventas Mensuales");

            Series series = chartVentas.Series.Add("Total Ventas");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.Blue;

            // Conexión a la base de datos y ejecución del procedimiento almacenado
            string connectionString = Conexion.cadena;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_ReporteVentasMensuales", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string mes = reader["Mes"].ToString();
                        int totalVentas = Convert.ToInt32(reader["TotalVentas"]);

                        // Agregar datos al gráfico
                        series.Points.AddXY(mes, totalVentas);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Personalización del gráfico
            chartVentas.ChartAreas[0].AxisX.Title = "Mes";
            chartVentas.ChartAreas[0].AxisY.Title = "Total de Ventas";
            chartVentas.ChartAreas[0].AxisX.Interval = 1;
        }

        private void CargarGrafico()
        {
            // Configuración de conexión a la base de datos
            string connectionString = Conexion.cadena; // Cambia esto por tu cadena de conexión

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Llamada al procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("sp_ProductosMasVendidos", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Ejecutar el procedimiento y obtener los resultados
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Configurar el gráfico
                            chart1.Series.Clear();
                            Series series = chart1.Series.Add("Productos Más Vendidos");
                            series.ChartType = SeriesChartType.Pie;

                            while (reader.Read())
                            {
                                string nombreProducto = reader["NombreProducto"].ToString();
                                int totalVendidos = Convert.ToInt32(reader["TotalVendidos"]);

                                // Agregar puntos de datos al gráfico
                                series.Points.AddXY(nombreProducto, totalVendidos);
                            }
                        }
                    }

                    // Opcional: Configuración adicional del gráfico
                    chart1.Titles.Clear();
                    chart1.Titles.Add("Productos Más Vendidos");
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.Series[0]["PieLabelStyle"] = "Outside";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el gráfico: " + ex.Message);
                }
            }
        }

        private void CargarClientesMasVentasEnBarras()
        {
            string connectionString = Conexion.cadena;
            string query = "EXEC sp_ClientesMasVentas"; // Llamamos al procedimiento almacenado

            // Conectar a la base de datos y ejecutar la consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Limpiar los datos previos del gráfico
                chartBarras.Series.Clear();
                chartBarras.ChartAreas[0].AxisX.Title = "Clientes";
                chartBarras.ChartAreas[0].AxisY.Title = "Total Gastado";

                // Crear la serie para el gráfico de barras
                var series = new Series("Clientes")
                {
                    ChartType = SeriesChartType.Bar, // Tipo de gráfico de barras
                    IsValueShownAsLabel = true // Para mostrar los valores sobre las barras
                };

                // Leer los resultados y agregar al gráfico
                while (reader.Read())
                {
                    string nombreCliente = reader["NombreCliente"].ToString();
                    decimal totalGastado = Convert.ToDecimal(reader["TotalGastado"]);

                    // Agregar los puntos al gráfico
                    series.Points.AddXY(nombreCliente, totalGastado);
                }

                chartBarras.Series.Add(series);
            }
        }

        private void CargarCategoriasMasVendidasEnBarras()
        {
            string connectionString = Conexion.cadena;
            string query = "EXEC sp_CategoriasMasVendidas"; // Llamamos al procedimiento almacenado

            // Conectar a la base de datos y ejecutar la consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Limpiar los datos previos del gráfico
                chartCategorias.Series.Clear();
                chartCategorias.ChartAreas[0].AxisX.Title = "Categorías";
                chartCategorias.ChartAreas[0].AxisY.Title = "Total Vendido";

                // Crear la serie para el gráfico de barras
                var series = new Series("Categorías")
                {
                    ChartType = SeriesChartType.Bar, // Cambiar a gráfico de barras
                    IsValueShownAsLabel = true // Para mostrar los valores sobre las barras
                };

                // Leer los resultados y agregar al gráfico
                while (reader.Read())
                {
                    string categoria = reader["Categoria"].ToString();
                    int totalVendidos = Convert.ToInt32(reader["TotalVendidos"]);

                    // Agregar los puntos al gráfico
                    series.Points.AddXY(categoria, totalVendidos);
                }

                chartCategorias.Series.Add(series);
            }
        }




        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
