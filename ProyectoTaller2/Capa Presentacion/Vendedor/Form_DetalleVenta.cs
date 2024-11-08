using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using ProyectoTaller2.Capa_Entidades;
using ProyectoTaller2.Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller2.Capa_Presentacion.Vendedor
{
    public partial class Form_DetalleVenta : Form
    {
        public Form_DetalleVenta()
        {
            InitializeComponent();
        }

        private string numeroDocumento;

        public Form_DetalleVenta(string numeroDocumento)
        {
            InitializeComponent();
            this.numeroDocumento = numeroDocumento;
        }

        private void Form_DetalleVenta_Load(object sender, EventArgs e)
        {
            //txtBusquedaDoc.Select();
            CargarDetalleVenta(numeroDocumento);
            txtBusquedaDoc.Text = numeroDocumento;
        }
        private void btnClienteVenta_Click(object sender, EventArgs e)
        {
            Factura oVenta = new NegocioFactura().ObtenerVenta(txtBusquedaDoc.Text);

            if(oVenta.id_factura != 0)
            {
                txtIdCliente.Text = oVenta.numero_documento;
                txtFecha.Text = oVenta.fecha_registro.ToString();
                txtBoxDocumento.Text = oVenta.tipo_documento;
                txtBoxUsuarioDetalle.Text = oVenta.oUsuario.nombre_usuario;


                txtBoxDni.Text = oVenta.dni_cliente;
                txtBoxNombre.Text = oVenta.nombre_cliente;

                dataGridDetalle.Rows.Clear();

                foreach(Factura_detalle dv in oVenta.oFactura_Detalle)
                {
                    dataGridDetalle.Rows.Add(new object[] { dv.oProducto.nombre_producto, dv.precioVenta, dv.cantidad, dv.subTotal });

                }

                txtTotalAPagar.Text = oVenta.monto_total.ToString("0.00");
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtBoxDni.Text = "";
            txtBoxDocumento.Text = "";
            txtBoxNombre.Text = "";
            txtBoxUsuarioDetalle.Text = "";

            dataGridDetalle.Rows.Clear();
            txtBusquedaDoc.Text = "";
            txtIdCliente.Text = "";
            txtTotalAPagar.Text = "0.00";
        }

         private void btngenerarPdf_Click(object sender, EventArgs e)
        {
            if(txtBoxDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Texto_html = Properties.Resources.PlantillaVenta.ToString();



            Texto_html = Texto_html.Replace("@nombrenegocio", "La Taberna".ToUpper());
            Texto_html = Texto_html.Replace("@docnegocio", "20-41612231-9");
            Texto_html = Texto_html.Replace("@direcnegocio", "Catamarca 635");

            Texto_html = Texto_html.Replace("@tipodocumento", txtBoxDocumento?.Text.ToUpper() ?? string.Empty);
            Texto_html = Texto_html.Replace("@numerodocumento", txtBusquedaDoc?.Text ?? string.Empty);
            Texto_html = Texto_html.Replace("@doccliente", txtBoxDni?.Text ?? string.Empty);
            Texto_html = Texto_html.Replace("@nombrecliente", txtBoxNombre?.Text ?? string.Empty);
            Texto_html = Texto_html.Replace("@fecharegistro", txtFecha?.Text ?? string.Empty);
            Texto_html = Texto_html.Replace("@usuarioregistro", txtBoxUsuarioDetalle?.Text ?? string.Empty);

            string filas = string.Empty;


            foreach (DataGridViewRow row in dataGridDetalle.Rows)
            {
                string producto = row.Cells["Producto"]?.Value?.ToString() ?? string.Empty;
                string precio = row.Cells["Precio"]?.Value?.ToString() ?? string.Empty;
                string cantidad = row.Cells["Cantidad"]?.Value?.ToString() ?? string.Empty;
                string subtotal = row.Cells["SubTotal"]?.Value?.ToString() ?? string.Empty;

                filas += "<tr>";
                filas += $"<td>{System.Net.WebUtility.HtmlEncode(producto)}</td>";
                filas += $"<td>{System.Net.WebUtility.HtmlEncode(precio)}</td>";
                filas += $"<td>{System.Net.WebUtility.HtmlEncode(cantidad)}</td>";
                filas += $"<td>{System.Net.WebUtility.HtmlEncode(subtotal)}</td>";
                filas += "</tr>";
            }

            Texto_html = Texto_html.Replace("@filas", filas);
            Texto_html = Texto_html.Replace("@montototal", txtTotalAPagar.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtBusquedaDoc.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if(savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

 


                    // Convertir la imagen de Resources a un arreglo de bytes
                    byte[] byteImage;
                    bool obtenido = false;

                    try
                    {
                        using (var ms = new System.IO.MemoryStream())
                        {
                            // Reemplaza "NombreDeLaImagen" con el nombre exacto de la imagen en Resources
                            Properties.Resources.tabernaazul.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byteImage = ms.ToArray();
                            obtenido = true;
                        }
                    }
                    catch
                    {
                        byteImage = null;
                        obtenido = false;
                    }

                    // Verificar si se obtuvo la imagen correctamente
                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                     using (StringReader sr = new StringReader(Texto_html))
                    {
                       XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void CargarDetalleVenta(string numeroDocumento)
        {
            Factura oVenta = new NegocioFactura().ObtenerVenta(numeroDocumento);

            if (oVenta.id_factura != 0)
            {
                txtIdCliente.Text = oVenta.numero_documento;
                txtFecha.Text = oVenta.fecha_registro.ToString();
                txtBoxDocumento.Text = oVenta.tipo_documento;
                txtBoxUsuarioDetalle.Text = oVenta.oUsuario.nombre_usuario;
                txtBoxDni.Text = oVenta.dni_cliente;
                txtBoxNombre.Text = oVenta.nombre_cliente;

                dataGridDetalle.Rows.Clear();

                foreach (Factura_detalle dv in oVenta.oFactura_Detalle)
                {
                    dataGridDetalle.Rows.Add(new object[] { dv.oProducto.nombre_producto, dv.precioVenta, dv.cantidad, dv.subTotal });
                }

                txtTotalAPagar.Text = oVenta.monto_total.ToString("0.00");
            }
            else
            {
                MessageBox.Show("No se encontró una venta con el número de documento proporcionado.");
            }
        }
    }
}
