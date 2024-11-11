using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using ProyectoTaller2.Capa_Entidades;
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

namespace ProyectoTaller2.Capa_Presentacion.Vendedor
{
    public partial class FormVentasRegistradas : Form
    {

        private Iform _form;

        public FormVentasRegistradas(Iform form)
        {
            InitializeComponent();
            _form = form;
        }

        private void FormVentasRegistradas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dataGridReporteVentas.Columns)
            {
                comboBox1.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            comboBox1.DisplayMember = "Texto";
            comboBox1.ValueMember = "Valor";
            comboBox1.SelectedIndex = 0;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dataGridReporteVentas.SelectedRows.Count > 0)
            {
                // Supón que la columna "NumeroDocumento" contiene el número de documento en la fila seleccionada
                string numeroDocumento = dataGridReporteVentas.SelectedRows[0].Cells["NumeroDocumento"].Value.ToString();

                // Crea una instancia de detalle_venta y pásale el número de documento
                Form_DetalleVenta detalleForm = new Form_DetalleVenta(numeroDocumento);
                detalleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una venta para ver el detalle.");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridReporteVentas.SelectedRows.Count > 0)
            {
                btnVerDetalle.Enabled=true;
            }
            else
            {
                btnVerDetalle.Enabled=false;
            }
        }

        private void btnBuscarReporte_Click(object sender, EventArgs e)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            lista = new NegocioReporte().Venta(txtFechaInicio.Value.ToString(),txtFechafin.Value.ToString());

            dataGridReporteVentas.Rows.Clear();

            foreach (ReporteVenta rv in lista)
            {
                dataGridReporteVentas.Rows.Add(new object[]
                {
                    rv.FechaRegistro,
                    rv.tipo_documento,
                    rv.numero_documento,
                    rv.monto_total,
                    rv.NombreUsuario,
                    rv.dni_cliente,
                    rv.nombre_cliente
                });
            }
        }

        private void btngenerarPdf_Click(object sender, EventArgs e)
        {
            if (dataGridReporteVentas.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach(DataGridViewColumn columna in dataGridReporteVentas.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach(DataGridViewRow row in dataGridReporteVentas.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                        });
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if(savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte","MEnsaje",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)comboBox1.SelectedItem).Valor.ToString();

            if(dataGridReporteVentas.Rows.Count > 0 )
            {
                foreach(DataGridViewRow row in dataGridReporteVentas.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                         row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach(DataGridViewRow row in dataGridReporteVentas.Rows)
            {
                row.Visible = true;
            }

        }


        private Dictionary<string, string> columnaMapeo = new Dictionary<string, string>
        {
              { "Nombre Producto", "NombreProducto" }
        };

       /* private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaVisible = comboBox1.SelectedItem.ToString();
            string columnaFiltro = columnaMapeo.ContainsKey(columnaVisible) ? columnaMapeo[columnaVisible] : columnaVisible;

            if (dataGridReporteVentas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridReporteVentas.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }*/

    }
}
