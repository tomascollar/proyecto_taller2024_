namespace ProyectoTaller2.Capa_Presentacion.Vendedor
{
    partial class Form_DetalleVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusquedaDoc = new System.Windows.Forms.TextBox();
            this.btnClienteVenta = new FontAwesome.Sharp.IconButton();
            this.groupBoxVenta = new System.Windows.Forms.GroupBox();
            this.txtBoxUsuarioDetalle = new System.Windows.Forms.TextBox();
            this.txtBoxDocumento = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxDni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridDetalle = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalAPagar = new System.Windows.Forms.TextBox();
            this.btngenerarPdf = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarFiltro = new FontAwesome.Sharp.IconButton();
            this.groupBoxVenta.SuspendLayout();
            this.groupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Factura Detalle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(446, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero Documento:";
            // 
            // txtBusquedaDoc
            // 
            this.txtBusquedaDoc.Location = new System.Drawing.Point(582, 25);
            this.txtBusquedaDoc.Name = "txtBusquedaDoc";
            this.txtBusquedaDoc.Size = new System.Drawing.Size(118, 20);
            this.txtBusquedaDoc.TabIndex = 3;
            // 
            // btnClienteVenta
            // 
            this.btnClienteVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClienteVenta.ForeColor = System.Drawing.Color.White;
            this.btnClienteVenta.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnClienteVenta.IconColor = System.Drawing.Color.White;
            this.btnClienteVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClienteVenta.IconSize = 20;
            this.btnClienteVenta.Location = new System.Drawing.Point(706, 19);
            this.btnClienteVenta.Name = "btnClienteVenta";
            this.btnClienteVenta.Size = new System.Drawing.Size(28, 29);
            this.btnClienteVenta.TabIndex = 5;
            this.btnClienteVenta.UseVisualStyleBackColor = true;
            this.btnClienteVenta.Click += new System.EventHandler(this.btnClienteVenta_Click);
            // 
            // groupBoxVenta
            // 
            this.groupBoxVenta.Controls.Add(this.txtBoxUsuarioDetalle);
            this.groupBoxVenta.Controls.Add(this.txtBoxDocumento);
            this.groupBoxVenta.Controls.Add(this.txtFecha);
            this.groupBoxVenta.Controls.Add(this.label4);
            this.groupBoxVenta.Controls.Add(this.label10);
            this.groupBoxVenta.Controls.Add(this.label1);
            this.groupBoxVenta.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVenta.ForeColor = System.Drawing.Color.White;
            this.groupBoxVenta.Location = new System.Drawing.Point(51, 62);
            this.groupBoxVenta.Name = "groupBoxVenta";
            this.groupBoxVenta.Size = new System.Drawing.Size(720, 71);
            this.groupBoxVenta.TabIndex = 7;
            this.groupBoxVenta.TabStop = false;
            this.groupBoxVenta.Text = "Informacion Venta";
            // 
            // txtBoxUsuarioDetalle
            // 
            this.txtBoxUsuarioDetalle.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUsuarioDetalle.Location = new System.Drawing.Point(470, 41);
            this.txtBoxUsuarioDetalle.Name = "txtBoxUsuarioDetalle";
            this.txtBoxUsuarioDetalle.ReadOnly = true;
            this.txtBoxUsuarioDetalle.Size = new System.Drawing.Size(163, 25);
            this.txtBoxUsuarioDetalle.TabIndex = 1;
            this.txtBoxUsuarioDetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxDocumento
            // 
            this.txtBoxDocumento.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDocumento.Location = new System.Drawing.Point(254, 40);
            this.txtBoxDocumento.Name = "txtBoxDocumento";
            this.txtBoxDocumento.ReadOnly = true;
            this.txtBoxDocumento.Size = new System.Drawing.Size(191, 25);
            this.txtBoxDocumento.TabIndex = 1;
            this.txtBoxDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(11, 41);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(166, 25);
            this.txtFecha.TabIndex = 1;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(466, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Usuario:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(250, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tipo Documentacion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Documento:";
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Controls.Add(this.txtIdCliente);
            this.groupBoxCliente.Controls.Add(this.txtBoxNombre);
            this.groupBoxCliente.Controls.Add(this.label5);
            this.groupBoxCliente.Controls.Add(this.txtBoxDni);
            this.groupBoxCliente.Controls.Add(this.label6);
            this.groupBoxCliente.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCliente.ForeColor = System.Drawing.Color.White;
            this.groupBoxCliente.Location = new System.Drawing.Point(52, 139);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(720, 72);
            this.groupBoxCliente.TabIndex = 8;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Informacion Cliente";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(636, 43);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(60, 25);
            this.txtIdCliente.TabIndex = 5;
            this.txtIdCliente.Visible = false;
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNombre.Location = new System.Drawing.Point(254, 41);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.ReadOnly = true;
            this.txtBoxNombre.Size = new System.Drawing.Size(164, 25);
            this.txtBoxNombre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(250, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre del Cliente:";
            // 
            // txtBoxDni
            // 
            this.txtBoxDni.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDni.Location = new System.Drawing.Point(11, 43);
            this.txtBoxDni.Name = "txtBoxDni";
            this.txtBoxDni.ReadOnly = true;
            this.txtBoxDni.Size = new System.Drawing.Size(219, 25);
            this.txtBoxDni.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Documento del Cliente:";
            // 
            // dataGridDetalle
            // 
            this.dataGridDetalle.AllowUserToAddRows = false;
            this.dataGridDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDetalle.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.SubTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDetalle.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDetalle.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridDetalle.Location = new System.Drawing.Point(52, 217);
            this.dataGridDetalle.Name = "dataGridDetalle";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridDetalle.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDetalle.Size = new System.Drawing.Size(720, 196);
            this.dataGridDetalle.TabIndex = 14;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 432);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 22);
            this.label9.TabIndex = 15;
            this.label9.Text = "Total:";
            // 
            // txtTotalAPagar
            // 
            this.txtTotalAPagar.Location = new System.Drawing.Point(111, 434);
            this.txtTotalAPagar.Name = "txtTotalAPagar";
            this.txtTotalAPagar.ReadOnly = true;
            this.txtTotalAPagar.Size = new System.Drawing.Size(118, 20);
            this.txtTotalAPagar.TabIndex = 16;
            this.txtTotalAPagar.Text = "0";
            // 
            // btngenerarPdf
            // 
            this.btngenerarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenerarPdf.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenerarPdf.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btngenerarPdf.IconColor = System.Drawing.Color.White;
            this.btngenerarPdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btngenerarPdf.IconSize = 30;
            this.btngenerarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngenerarPdf.Location = new System.Drawing.Point(647, 421);
            this.btngenerarPdf.Name = "btngenerarPdf";
            this.btngenerarPdf.Size = new System.Drawing.Size(124, 35);
            this.btngenerarPdf.TabIndex = 17;
            this.btngenerarPdf.Text = "Generar PDF";
            this.btngenerarPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btngenerarPdf.UseVisualStyleBackColor = true;
            this.btngenerarPdf.Click += new System.EventHandler(this.btngenerarPdf_Click);
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltro.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiarFiltro.IconColor = System.Drawing.Color.White;
            this.btnLimpiarFiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarFiltro.IconSize = 20;
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(740, 19);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(27, 29);
            this.btnLimpiarFiltro.TabIndex = 18;
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // Form_DetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(824, 468);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.btngenerarPdf);
            this.Controls.Add(this.txtTotalAPagar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridDetalle);
            this.Controls.Add(this.groupBoxCliente);
            this.Controls.Add(this.groupBoxVenta);
            this.Controls.Add(this.btnClienteVenta);
            this.Controls.Add(this.txtBusquedaDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form_DetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_DetalleVenta";
            this.Load += new System.EventHandler(this.Form_DetalleVenta_Load);
            this.groupBoxVenta.ResumeLayout(false);
            this.groupBoxVenta.PerformLayout();
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusquedaDoc;
        private FontAwesome.Sharp.IconButton btnClienteVenta;
        private System.Windows.Forms.GroupBox groupBoxVenta;
        private System.Windows.Forms.TextBox txtBoxUsuarioDetalle;
        private System.Windows.Forms.TextBox txtBoxDocumento;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxCliente;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxDni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridDetalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalAPagar;
        private FontAwesome.Sharp.IconButton btngenerarPdf;
        private FontAwesome.Sharp.IconButton btnLimpiarFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}